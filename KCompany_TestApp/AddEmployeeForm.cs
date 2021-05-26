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
    public partial class AddEmployeeForm : KCompany_TestApp.EmployeeForm
    {
        public AddEmployeeForm()
        {
            InitializeComponent();

            dateTimePicker_dateOfBirth.Value = new DateTime(DateTime.Today.Year - InputValidators.MinAgeRequired, 1, 1);
            ClearTextBoxes();
        }

        private void button_addNewEmployee_Click(object sender, EventArgs e)
        {
            if (!ValidateInputElements()) return;

            Empoyee recruit = new Empoyee
            {
                DepartmentID = Guid.Parse(treeView_departments.SelectedNode.Name),
                SurName = tB_SurName.Text,
                FirstName = tB_FirstName.Text,
                Patronymic = tB_Patronymic.Text,
                DateOfBirth = dateTimePicker_dateOfBirth.Value,
                DocSeries = tB_DocSeries.Text,
                DocNumber = tB_DocNumber.Text,
                Position = tB_Position.Text,
            };

            using (var db = new TestDBEntities())
            {
                //Check if recruit allready exists
                var query = from r in db.Empoyee
                            select r;
                foreach (var emp in query)
                {
                    if (!emp.HasEmptyDocFields() && !recruit.HasEmptyDocFields() && emp.HasSameDocsAs(recruit))
                    {
                        MessageBox.Show("Сотрудник с такими же номером и серией документов уже существует.\n\n" +
                                        $"Расположение: \"{emp.Department.Name}\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                //Checks for already existing employee the personal data and same documents   
                foreach (var emp in query)
                {
                    if (emp.HasSamePersonalInfoAs(recruit) && emp.HasSameDocsAs(recruit))
                    {
                        MessageBox.Show("Сотрудник с указанными личными данными уже существует.\n\n" +
                                        $"Расположение: \"{emp.Department.Name}\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                foreach (var emp in query)
                {
                    if (!emp.HasSamePersonalInfoAs(recruit)) continue;
                    var confirmationResult = MessageBox.Show("Сотрудник с такими же ФИО и датой рождения уже существует в базе данных (данные документов отличаются)\n" +
                                                             $"Расположение: \"{emp.Department.Name}\"\n\n" +
                                                             "Продолжить?", "Возможное дублирование записи", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (confirmationResult == DialogResult.Cancel) return;
                    break;
                }

                db.Empoyee.Add(recruit);
                db.SaveChanges();
                ((MainForm)Owner).FillEmployeesDataGridFromDB();
                MessageBox.Show("Новый работник успешно добавлен в базу", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTextBoxes();
            }
        }

        private void AddEmployeeForm_Shown(object sender, EventArgs e)
        {
            if (Owner == null) return;
            FillEmployeeDepartmentTreeView(((MainForm)Owner).SelectedDepartmentID);
        }
    }
}