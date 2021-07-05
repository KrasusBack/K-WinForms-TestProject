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
    public partial class AddDepartmentForm : KCompany_TestApp.DepartmentForm
    {
        public AddDepartmentForm(string selectedDepartmentID)
        {
            InitializeComponent();

            tB_Code.Clear();
            tB_Name.Clear();

            if (string.IsNullOrEmpty(selectedDepartmentID))
            {
                checkBox_IncludeParentDep.Checked = false;
                checkBox_IncludeParentDep.Enabled = false;
            }
            else
            {
                FormElementsHandlers.DepartmentsTreeViewFillFromDB(treeView_departments, false);
                FormElementsHandlers.SelectDepartmentNode(selectedDepartmentID, treeView_departments);
                if (treeView_departments.SelectedNode == null)
                {
                    MessageBox.Show("Возникла внутренняя ошибка при поиске родительского отдела. Попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MainForm mainForm = (MainForm)Owner;
                    mainForm.FillDepartmentTreeViewFromDB();
                    mainForm.FillEmployeesDataGridFromDB();
                    Close();
                    return;
                }
                checkBox_IncludeParentDep.Checked = true;
            }
            UpdateParentDepTVBasedOnCheckBoxEnabledStatus();
        }

        private void button_checkAndApply_Click(object sender, EventArgs e)
        {
            if (!ValidateInputElements()) return;

            var newDep = new Department
            {
                Name = tB_Name.Text,
                Code = tB_Code.Text
            };

            using (var db = new TestDBEntities())
            {
                var query = from d in db.Department
                            select d;

                foreach (var dep in query)
                {
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

                newDep.ID = Guid.NewGuid();
                if (!checkBox_IncludeParentDep.Checked) newDep.ParentDepartmentID = null;
                else newDep.ParentDepartmentID = Guid.Parse(treeView_departments.SelectedNode.Name);

                db.Department.Add(newDep);
                db.SaveChanges();
            }

            MainForm mainForm = (MainForm)Owner;
            mainForm.FillDepartmentTreeViewFromDB();
            mainForm.FillEmployeesDataGridFromDB();

            MessageBox.Show("Отдел успешно добавлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

    }
}
