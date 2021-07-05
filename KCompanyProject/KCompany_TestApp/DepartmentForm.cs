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
    public partial class DepartmentForm : Form
    {
        public DepartmentForm()
        {
            InitializeComponent();
        }

        //To allow closing form on focused input element with failed validation
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            if (Owner == null) return;
            Owner.Enabled = false;
        }

        #region Input elements validation
        private void DepartmentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Owner == null) return;
            Owner.Enabled = true;
        }

        private void tB_Name_Validating(object sender, CancelEventArgs e)
        {
            if (ElementValidationHandlers.TB_StartWithALetter(tB_Name, errorProvider, e))
                tB_Name.Text = Tools.ToOfficialNameFormat(tB_Name.Text, false);
        }

        private void tB_Code_Validating(object sender, CancelEventArgs e)
        {
            if (ElementValidationHandlers.TB_StartWithALetter(tB_Code, errorProvider, e, false))
                tB_Code.Text = tB_Code.Text.ToUpper();
        }

        private void treeView_departments_Validating(object sender, CancelEventArgs e)
        {
            if (!checkBox_IncludeParentDep.Checked) return;
            if (!checkBox_IncludeParentDep.Enabled) return;
            if (!ElementValidationHandlers.TreeView_PickValidator(treeView_departments, errorProvider, e)) return;

            if (treeView_departments.SelectedNode == null)
            {
                e.Cancel = true;
                errorProvider.SetError(treeView_departments, $"Выберите родительский отдел");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(treeView_departments, string.Empty);
            }
        }

        #endregion

        /// <summary>
        /// Calls validation methods in elements with input information. If unsuccessful, calls "Check inputs" message.
        /// </summary>
        /// <returns>Validation result</returns>
        protected bool ValidateInputElements()
        {
            if (ValidateChildren(ValidationConstraints.ImmediateChildren | ValidationConstraints.Enabled)) return true;  
            MessageBox.Show("Проверьте правильность заполнения полей", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void checkBox_IncludeParentDep_CheckedChanged(object sender, EventArgs e)
        {
            UpdateParentDepTVBasedOnCheckBoxEnabledStatus();
        }

        protected void UpdateParentDepTVBasedOnCheckBoxEnabledStatus()
        {
            if (checkBox_IncludeParentDep.Checked)
            {
                treeView_departments.Enabled = true;
                treeView_departments.BackColor = SystemColors.Window;
            }
            else
            {
                treeView_departments.Enabled = false;
                treeView_departments.BackColor = SystemColors.Control;
            }
        }

    }
}
