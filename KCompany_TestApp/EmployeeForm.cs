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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        //To allow close form on focused input element with failed validation
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Owner == null) return;
            ((MainForm)Owner).FillEmployeesDataGridFromDB();
            Owner.Enabled = true;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            if (Owner == null) return;
            Owner.Enabled = false;
        }


        #region Input fields validation
        private void tB_SurName_Validating(object sender, CancelEventArgs e)
        {
            if (ElementValidationHandlers.TB_EmployeeNameValidator(tB_SurName, errorProvider, e, true))
                tB_SurName.Text = Tools.ToOfficialNameFormat(tB_SurName.Text);
        }

        private void tB_FirstName_Validating(object sender, CancelEventArgs e)
        {
            if (ElementValidationHandlers.TB_EmployeeNameValidator(tB_FirstName, errorProvider, e, true))
                tB_FirstName.Text = Tools.ToOfficialNameFormat(tB_FirstName.Text);
        }

        private void tB_Patronymic_Validating(object sender, CancelEventArgs e)
        {
            if (ElementValidationHandlers.TB_EmployeeNameValidator(tB_Patronymic, errorProvider, e))
                tB_Patronymic.Text = Tools.ToOfficialNameFormat(tB_Patronymic.Text);
        }

        private void tB_DocSeries_Validating(object sender, CancelEventArgs e)
        {
            if (ElementValidationHandlers.TB_DocDataValidator(tB_DocSeries, errorProvider, e, 4))
                tB_DocSeries.Text = tB_DocSeries.Text.ToUpper();
        }

        private void tB_DocNumber_Validating(object sender, CancelEventArgs e)
        {
            if (ElementValidationHandlers.TB_DocDataValidator(tB_DocNumber, errorProvider, e, 6))
                tB_DocNumber.Text = tB_DocNumber.Text.ToUpper();
        }

        private void dateTimePicker_dateOfBirth_Validating(object sender, CancelEventArgs e)
        {
            ElementValidationHandlers.DTPicker_RequiredAgeValidator(dateTimePicker_dateOfBirth, errorProvider, e);
        }

        private void tB_Position_Validating(object sender, CancelEventArgs e)
        {
            if (ElementValidationHandlers.TB_StartWithALetter(tB_Position, errorProvider, e))
                tB_Position.Text = Tools.ToOfficialNameFormat(tB_Position.Text, false);
        }

        private void treeView_departments_Validating(object sender, CancelEventArgs e)
        {
            ElementValidationHandlers.TreeView_PickValidator(treeView_departments, errorProvider, e);
        }
        #endregion 

        /// <summary>
        /// Calls validation methods in elements with input information. If unsuccessful, calls "Check inputs" message.
        /// </summary>
        /// <returns>Validation result</returns>
        protected bool ValidateInputElements()
        {
            if (!ValidateChildren(ValidationConstraints.ImmediateChildren | ValidationConstraints.Enabled))
            {
                MessageBox.Show("Проверьте правильность заполнения полей", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        protected void FillEmployeeDepartmentTreeView(string selectedDepIDInMainForm)
        {
            FormElementsHandlers.DepartmentsTreeViewFillFromDB(treeView_departments);
            FormElementsHandlers.SelectDepartmentNode(selectedDepIDInMainForm, treeView_departments);
        }
        protected void ClearTextBoxes()
        {
            tB_SurName.Clear();
            tB_FirstName.Clear();
            tB_Patronymic.Clear();
            tB_DocNumber.Clear();
            tB_DocSeries.Clear();
            tB_Position.Clear();
        }
    }
}
