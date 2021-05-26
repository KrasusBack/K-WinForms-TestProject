using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace KCompany_TestApp
{
    public partial class EditDepartmentForm : KCompany_TestApp.DepartmentForm
    {
        Department origDep = null;
        bool origParentDepChBState = false;

        public EditDepartmentForm(TreeNode selectedDep)
        {
            InitializeComponent();

            Text = $"Редактирование отдела [{selectedDep.Text}]";
            tB_Code.Clear();
            tB_Name.Clear();

            Guid origDepID = Guid.Parse(selectedDep.Name);
            FillOrigDep(origDepID);

            FillFields();
            origParentDepChBState = checkBox_IncludeParentDep.Checked;
        }

        private void FillOrigDep(Guid origDepID)
        {
            origDep = FindOriginalDepartment(origDepID);
            if (origDep == null)
            {
                MessageBox.Show("Данный отдел не найден в базе. Попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((MainForm)Owner).FillDepartmentTreeViewFromDB();
                Close();
            }
        }
        private Department FindOriginalDepartment(Guid origDepID)
        {
            using (var db = new TestDBEntities())
            {
                var query = from d in db.Department
                            where d.ID == origDepID
                            select d;

                if (query.Count() == 0) return null;
                return query.First();
            }
        }

        private void FillFields()
        {
            tB_Code.Text = origDep.Code;
            tB_Name.Text = origDep.Name;

            FormElementsHandlers.DepartmentsTreeViewFillFromDB(treeView_departments, false);

            var selectedDepNode = treeView_departments.Nodes.Find(origDep.ID.ToString(), true)[0];
            var selectedDepNodeParent = selectedDepNode?.Parent;
            //Prevents from self parenting and from becoming a child of its children
            selectedDepNode.Remove();
            if (treeView_departments.Nodes.Count == 0)
            {
                checkBox_IncludeParentDep.Checked = false;
                checkBox_IncludeParentDep.Enabled = false;
            }
            else if (selectedDepNodeParent != null)
            {
                treeView_departments.SelectedNode = selectedDepNodeParent;
                checkBox_IncludeParentDep.Checked = true;
            }

            UpdateParentDepTVBasedOnCheckBoxEnabledStatus();
        }

        private bool InputFieldsHaveChanged()
        {
            if (tB_Name.Text != origDep.Name) return true;
            if (tB_Code.Text != origDep.Code) return true;
            if (checkBox_IncludeParentDep.Checked != origParentDepChBState) return true;
            if (checkBox_IncludeParentDep.Checked && 
                treeView_departments.SelectedNode?.Name != origDep.ParentDepartmentID?.ToString()) return true;
            return false;
        }

        private void button_checkAndApply_Click(object sender, EventArgs e)
        {
            if (!ValidateInputElements()) return;
            if (!InputFieldsHaveChanged())
            {
                MessageBox.Show("Сначала следует внести изменения в данные отдела", "Нет внесенных изменений", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmationResult = MessageBox.Show("Вы уверены что хотите сохранить изменения?", "Подтверждение изменений",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (confirmationResult != DialogResult.Yes) return;

            using (var db = new TestDBEntities())
            {
                var query = from d in db.Department
                            select d;

                //Checks if original dep exist
                Department existingDep = null;
                foreach (var dep in query)
                {
                    if (!dep.Equals(origDep)) continue;
                    existingDep = dep;
                    break;
                }
                if (existingDep == null)
                {
                    MessageBox.Show("Данный отдел не найден в базе. Попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
                //Checks for dep with the same data as edited one
                foreach (var dep in query)
                {
                    if (dep.ID == existingDep.ID) continue;
                    if (dep.Name == tB_Name.Text)
                    {
                        MessageBox.Show("Отдел с таким названием уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!string.IsNullOrEmpty(tB_Code.Text) && dep.Code == tB_Code.Text)
                    {
                        MessageBox.Show($"Введенный код подразделения уже используется отделом [{dep.Name}]", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                existingDep.Name = tB_Name.Text;
                existingDep.Code = tB_Code.Text;
                if (checkBox_IncludeParentDep.Checked)
                    existingDep.ParentDepartmentID = Guid.Parse(treeView_departments.SelectedNode.Name);
                else existingDep.ParentDepartmentID = null;

                db.SaveChanges();
                var mainForm = (MainForm)Owner;
                mainForm.FillDepartmentTreeViewFromDB();
                mainForm.FillEmployeesDataGridFromDB();

                MessageBox.Show("Информация об отделе успешно изменена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void button_depParentHelpInfo_Click(object sender, EventArgs e)
        {
            string helpMessage = "Родительским подразделением не может являться: \n" +
                                 "- Сам отдел\n" +
                                 "- Его подотделы\n" +
                                 "По этой причине указанные выше отделы отсутствуют в списке доступных для выбора";
            MessageBox.Show(helpMessage, "Информация о выборе родительских подразделений", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
