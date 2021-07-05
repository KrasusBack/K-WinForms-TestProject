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
    public partial class EditEmployeeForm : KCompany_TestApp.EmployeeForm
    {
        Empoyee origEmp;
        public EditEmployeeForm(Empoyee selectedEmp)
        {
            InitializeComponent();

            origEmp = selectedEmp;
            FillFields();
            FillEmployeeDepartmentTreeView(origEmp.DepartmentID.ToString());
        }

        private void FillFields()
        {
            tB_SurName.Text = origEmp.SurName;
            tB_FirstName.Text = origEmp.FirstName;
            tB_Patronymic.Text = origEmp.Patronymic;
            tB_DocNumber.Text = origEmp.DocNumber;
            tB_DocSeries.Text = origEmp.DocSeries;
            tB_Position.Text = origEmp.Position;
            dateTimePicker_dateOfBirth.Value = origEmp.DateOfBirth;
        }

        private bool CheckIfEmployeeDataFieldsHaveChanged()
        {
            if (tB_SurName.Text != origEmp.SurName) return true;
            if (tB_FirstName.Text != origEmp.FirstName) return true;
            if (tB_Patronymic.Text != origEmp.Patronymic) return true;
            if (tB_DocNumber.Text != origEmp.DocNumber) return true;
            if (tB_DocSeries.Text != origEmp.DocSeries) return true;
            if (tB_Position.Text != origEmp.Position) return true;
            if (dateTimePicker_dateOfBirth.Value != origEmp.DateOfBirth) return true;
            if (treeView_departments.SelectedNode.Name != origEmp.DepartmentID.ToString()) return true;
            return false;
        }

        private void EditEmployeeForm_Load(object sender, EventArgs e)
        {
            Owner.Enabled = false;
        }

        private void EditEmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((MainForm)Owner).FillEmployeesDataGridFromDB();
            Owner.Enabled = true;
        }

        private void button_addNewEmployee_Click(object sender, EventArgs e)
        {
            if (!ValidateInputElements()) return;
            if (!CheckIfEmployeeDataFieldsHaveChanged())
            {
                MessageBox.Show("Сначала следует внести изменения в данные работника", "Нет внесенных изменений", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmationResult = MessageBox.Show("Вы уверены что хотите сохранить изменения?", "Подтверждение изменений",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (confirmationResult != DialogResult.Yes) return;

            using (var db = new TestDBEntities())
            {
                var query = from r in db.Empoyee
                            select r;

                //Finds original emp
                Empoyee editedEmployee = null;
                foreach (var emp in query)
                {
                    if (emp.HasSamePersonalInfoAs(origEmp) && emp.HasSameDocsAs(origEmp))
                    {
                        editedEmployee = emp;
                        break;
                    }
                }
                if (editedEmployee == null)
                {
                    MessageBox.Show("Сотрудник отсутствует в базе. Попробуйте снова", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ((MainForm)Owner).FillEmployeesDataGridFromDB();
                    Close();
                    return;
                }

                editedEmployee.DocSeries = tB_DocSeries.Text;
                editedEmployee.DocNumber = tB_DocNumber.Text;
                //Checks for existing duplicate of edited employee 
                foreach (var emp in query)
                {
                    if (emp.ID == editedEmployee.ID) continue;
                    if (!emp.HasEmptyDocFields() && !editedEmployee.HasEmptyDocFields() && emp.HasSameDocsAs(editedEmployee))
                    {
                        MessageBox.Show("Сотрудник с указанными номером и серией документов уже существует в базе\n\n" +
                                        $"Расположение: \"{emp.Department.Name}\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                editedEmployee.SurName = tB_SurName.Text;
                editedEmployee.FirstName = tB_FirstName.Text;
                editedEmployee.Patronymic = tB_Patronymic.Text;
                editedEmployee.DateOfBirth = dateTimePicker_dateOfBirth.Value;

                foreach (var emp in query)
                {
                    if (emp.ID == editedEmployee.ID) continue;
                    //Checks for already existing employee the personal data and same documents  
                    if (emp.HasSamePersonalInfoAs(editedEmployee) && emp.HasSameDocsAs(editedEmployee))
                    {
                        MessageBox.Show("Сотрудник с указанными личными данными уже существует.\n\n" +
                                        $"Расположение: \"{emp.Department.Name}\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                foreach (var emp in query)
                {
                    if (!emp.HasSamePersonalInfoAs(editedEmployee)) continue;
                    var confirmResult = MessageBox.Show("Сотрудник с указанными ФИО и датой рождения уже существует в базе данных (данные документов отличаются)\n\n" +
                                                         $"Расположение: \"{emp.Department.Name}\"\n\n" +
                                                        "Продолжить?", "Возможное дублирование записи", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (confirmResult == DialogResult.Cancel) return;
                    break;
                }

                editedEmployee.DepartmentID = Guid.Parse(treeView_departments.SelectedNode.Name);
                editedEmployee.Position = tB_Position.Text;

                db.SaveChanges();
                ((MainForm)Owner).FillEmployeesDataGridFromDB();
                MessageBox.Show("Информация о работнике обновлена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
