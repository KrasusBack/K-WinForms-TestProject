using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KCompany_TestApp
{
    public partial class MainForm : Form
    {
        bool employeeButtonsEnabled = true;
        public MainForm()
        {
            InitializeComponent();

            dataGridView_employees.Rows.Clear();
            FormElementsHandlers.DepartmentsTreeViewFillFromDB(treeView_departments);
            treeView_departments.Select();

            bool depExists = treeView_departments.Nodes.Count > 0;
            //Changing selecting node will trigger dataGrid upd (and its buttons with it)
            if (depExists) treeView_departments.SelectedNode = treeView_departments.Nodes[0];
            else ChangeEmployeeButtonsEnableState_ChangeAndDelete(false);
            
            ChangeDepartmentButtonsEnableState(depExists);
            button_addEmployee.Enabled = depExists;
        }

        public string SelectedDepartmentID => treeView_departments.SelectedNode?.Name;

        public void FillEmployeesDataGridFromDB()
        {
            dataGridView_employees.ClearSelection();
            dataGridView_employees.Rows.Clear();

            if (treeView_departments.SelectedNode == null) return;

            //Filling order: SurName, FirstName, Position, Age, BirthDay, DocSeries, DocNumber
            using (var db = new TestDBEntities())
            {
                var query = from b in db.Empoyee
                            where b.DepartmentID.ToString() == treeView_departments.SelectedNode.Name
                            orderby b.SurName, b.FirstName, b.Patronymic, b.Position, b.DateOfBirth
                            select b;

                foreach (var employee in query)
                {
                    var birthday = employee.DateOfBirth;
                    int age = Tools.GetAgeBasedOnBirthDay(birthday);

                    dataGridView_employees.Rows.Add(employee.SurName, employee.FirstName, employee.Patronymic,
                                                    employee.Position, age, employee.DateOfBirth.ToString("dd.MM.yyyy"),
                                                    employee.DocSeries, employee.DocNumber);
                }
            }

            dataGridView_employees.Update();
            ChangeEmployeeButtonsEnableState_ChangeAndDelete(dataGridView_employees.Rows?.Count>0);
        }

        public void FillDepartmentTreeViewFromDB()
        {
            FormElementsHandlers.DepartmentsTreeViewFillFromDB(treeView_departments);
            bool depExists = treeView_departments.Nodes.Count > 0;
            if (depExists) treeView_departments.SelectedNode = treeView_departments.Nodes[0];
            ChangeDepartmentButtonsEnableState(depExists);
            button_addEmployee.Enabled = depExists;
        }

        private void treeView_departments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FillEmployeesDataGridFromDB();
            bool depSelected = treeView_departments.SelectedNode != null;
            ChangeDepartmentButtonsEnableState(depSelected);
            button_addEmployee.Enabled = depSelected;
        }

        private void button_addEmployee_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm { Owner = this };
            addEmployeeForm.Show();
        }

        private void dataGridView_employees_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_employees.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
        }

        private void dataGridView_employees_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_employees.Rows[e.RowIndex].DefaultCellStyle.BackColor = dataGridView_employees.DefaultCellStyle.BackColor;
        }

        private Empoyee DataCellsToEmployee(DataGridViewCellCollection cellCollection)
        {
            if (cellCollection?.Count == 0) return null;
            //Filling order: SurName, FirstName, Position, Age, BirthDay, DocSeries, DocNumber
            var dateNumbs = cellCollection[5].Value.ToString().Split('.');
            Empoyee restoredEmp = new Empoyee
            {
                SurName = cellCollection[0].Value.ToString(),
                FirstName = cellCollection[1].Value.ToString(),
                Patronymic = cellCollection[2].Value?.ToString(),
                Position = cellCollection[3].Value.ToString(),
                DateOfBirth = new DateTime(Convert.ToInt32(dateNumbs[2]), Convert.ToInt32(dateNumbs[1]), Convert.ToInt32(dateNumbs[0])),
                DocSeries = cellCollection[6].Value.ToString(),
                DocNumber = cellCollection[7].Value.ToString(),
                DepartmentID = Guid.Parse(treeView_departments.SelectedNode.Name)
            };

            return restoredEmp;
        }

        private Empoyee GetEmployeeFromTheDataGrid()
        {
            int empIndex = dataGridView_employees.SelectedCells[0].RowIndex;
            var empDataCells = dataGridView_employees.Rows[empIndex].Cells;

            return DataCellsToEmployee(empDataCells);
        }
        private void button_deleteEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridView_employees.SelectedCells.Count == 0)
                MessageBox.Show("Сначала выберите сотрудника в таблице", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            Empoyee selectedEmp = GetEmployeeFromTheDataGrid();
            if (selectedEmp == null)
            {
                MessageBox.Show("Сотрудник не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FillEmployeesDataGridFromDB();
                dataGridView_employees.Update();
                return;
            }

            string empBaseInfo = $"{selectedEmp.SurName} {selectedEmp.FirstName[0]}.";
            if (!string.IsNullOrEmpty(selectedEmp.Patronymic))
                empBaseInfo += $"{selectedEmp.Patronymic[0]}.";
            empBaseInfo += $" ({selectedEmp.DateOfBirth:dd.MM.yyyy} д.р.)";
            var confirmationResult = MessageBox.Show($"Вы собираетесь удалить сотрудника\n{empBaseInfo}\n\n" +
                                                     $"Вы уверены?", "Подтверждение удаления",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (confirmationResult != DialogResult.Yes) return;

            using (var db = new TestDBEntities())
            {
                var query = (from b in db.Empoyee
                             select b).ToArray();

                List<Empoyee> results = new List<Empoyee>();
                foreach (var emp in query)
                {
                    if (emp.HasSamePersonalInfoAs(selectedEmp))
                        results.Add(emp);
                }

                int resultsCount = results.Count();
                if (resultsCount == 0)
                {
                    MessageBox.Show("Выбранный сотрудник не найден в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FillEmployeesDataGridFromDB();
                    return;
                }
                else if (resultsCount >= 1)
                {
                    db.Empoyee.Remove(results[0]);
                    db.SaveChanges();
                    FillEmployeesDataGridFromDB();
                    MessageBox.Show("Запись о сотруднике успешно удалена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void ChangeDepartmentButtonsEnableState(bool state)
        {
            button_deleteDepartment.Enabled = state;
            button_editDepartment.Enabled = state;
        }
        private void ChangeEmployeeButtonsEnableState_ChangeAndDelete(bool state)
        {
            button_deleteEmployee.Enabled = state;
            button_editEmployee.Enabled = state;
            employeeButtonsEnabled = state;
        }
        private void dataGridView_employees_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_employees.SelectedCells.Count == 0)
            {
                if (employeeButtonsEnabled)
                {
                    ChangeEmployeeButtonsEnableState_ChangeAndDelete(false);
                }
            }
            else
            {
                if (!employeeButtonsEnabled)
                {
                    ChangeEmployeeButtonsEnableState_ChangeAndDelete(true);
                }
            }
        }

        private void button_editEmployee_Click(object sender, EventArgs e)
        {
            var selectedEmp = GetEmployeeFromTheDataGrid();
            if (selectedEmp == null)
            {
                MessageBox.Show("Сначала выберите сотрудника в таблице", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedEmp.DepartmentID = Guid.Parse(treeView_departments.SelectedNode.Name);
            EditEmployeeForm editEmployeeForm = new EditEmployeeForm(selectedEmp);
            editEmployeeForm.Owner = this;
            editEmployeeForm.Show();
        }

        private void button_editDepartment_Click(object sender, EventArgs e)
        {
            if (treeView_departments.SelectedNode == null)
            {
                MessageBox.Show("Сначала выберите отдел", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EditDepartmentForm departmentForm = new EditDepartmentForm(treeView_departments.SelectedNode);
            departmentForm.Owner = this;
            departmentForm.Show();
        }

        private void button_addDepartment_Click(object sender, EventArgs e)
        {
            AddDepartmentForm addDepForm = new AddDepartmentForm(treeView_departments.SelectedNode?.Name);
            addDepForm.Owner = this;
            addDepForm.Show();
        }

        private void button_deleteDepartment_Click(object sender, EventArgs e)
        {
            if (treeView_departments.SelectedNode == null)
            {
                MessageBox.Show("Сначала выберите отдел", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Checks for selected dep in DB
            using (var db = new TestDBEntities())
            {
                Guid selectedDepID = Guid.Parse(treeView_departments.SelectedNode.Name);
                var queryTargetDep = from d in db.Department
                                     where d.ID == selectedDepID
                                     select d;
                if (queryTargetDep.Count() == 0)
                {
                    MessageBox.Show("Выбранный отдел не найден в базе данных. Попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FillDepartmentTreeViewFromDB();
                    return;
                }
                var queryDepChildren = from d in db.Department
                                       where d.ParentDepartmentID == selectedDepID
                                       select d;
                if (queryDepChildren.Count() > 0)
                {
                    MessageBox.Show("Нельзя удалить отдел содержащий подотделы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var depName = treeView_departments.SelectedNode.Text;
                var confirmRes = MessageBox.Show($"Вы собираетесь удалить отдел\n{depName}\n\n" +
                                                         $"Вы уверены?", "Подтверждение удаления",
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (confirmRes != DialogResult.Yes) return;

                var queryDepEmployees = from emp in db.Empoyee
                                        where emp.DepartmentID == selectedDepID
                                        select emp;
                if (queryDepEmployees.Count() > 0)
                {
                    if (MessageBox.Show(
                        $"В данном отделе есть сотрудники. "
                        + $"Отдел можно удалить только вместе с их записями.\n\n"
                        + $"Удалить отдел вместе с его сотрудниками?", "Подтверждение удаления",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2) == DialogResult.Cancel) return;
                    db.Empoyee.RemoveRange(queryDepEmployees);
                }

                db.Department.Remove(queryTargetDep.First());
                db.SaveChanges();
                FillEmployeesDataGridFromDB();
                FillDepartmentTreeViewFromDB();
                MessageBox.Show("Запись об отделе успешно удалена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
