using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace KCompany_TestApp
{
    class ElementValidationHandlers
    {
        /// <summary>
        /// Checks that TB.Text is filled and contains only russian letters
        /// </summary>
        public static bool TB_EmployeeNameValidator(TextBox tB, ErrorProvider errorProvider, CancelEventArgs e, bool fieldRequired = false)
        {
            if (fieldRequired && tB.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider.SetError(tB, "Поле должно быть заполнено");
                return false;
            }

            if (!InputValidators.InRussian(tB.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(tB, "Допустимы только русские буквы");
                return false;
            }
            e.Cancel = false;
            errorProvider.SetError(tB, string.Empty);
            return true;
        }

        public static bool TB_IsNotEmptyValidator(TextBox tB, ErrorProvider errorProvider, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tB.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(tB, "Поле должно быть заполнено");
                return false;
            }
            e.Cancel = false;
            errorProvider.SetError(tB, string.Empty);
            return true;
        }
        /// <summary>
        /// Checks for empty field first
        /// </summary>
        public static bool TB_StartWithALetter(TextBox tB, ErrorProvider errorProvider, CancelEventArgs e, bool requiredField = true)
        {
            if (requiredField && !TB_IsNotEmptyValidator(tB, errorProvider, e)) return false;
            if (tB.Text.Length > 0 && !char.IsLetter(tB.Text[0]))
            {
                e.Cancel = true;
                errorProvider.SetError(tB, "Поле должно начинаться с буквы");
                return false;
            }
            e.Cancel = false;
            errorProvider.SetError(tB, string.Empty);
            return true;
        }

        /// <summary>
        /// Checks that TB.Text only contains latin letters or numbers
        /// </summary>
        public static bool TB_DocDataValidator(TextBox tB, ErrorProvider errorProvider, CancelEventArgs e, int requiredLength = -1, bool fieldRequired = false)
        {
            if (!fieldRequired && string.IsNullOrEmpty(tB.Text))
            {
                e.Cancel = false;
                errorProvider.SetError(tB, "");
                return true;
            }
            if (!InputValidators.IsNumberAndOrLatin(tB.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(tB, "Допустимы только цифры и буквы латинского алфавита");
                return false;
            }
            else if (requiredLength > 0 && tB.Text.Length != requiredLength)
            {
                e.Cancel = true;
                errorProvider.SetError(tB, $"Значение должно состоять из {requiredLength} символов");
                return false;
            }

            e.Cancel = false;
            errorProvider.SetError(tB, string.Empty);
            return true;
        }

        public static bool DTPicker_RequiredAgeValidator(DateTimePicker dTP, ErrorProvider errorProvider, CancelEventArgs e)
        {
            int minAge = 14; //Based on the law
            int maxAge = 150; //Based on (sort of) common sense

            if (InputValidators.AgeValidator(dTP.Value, minAge, maxAge))
            {
                e.Cancel = false;
                errorProvider.SetError(dTP, string.Empty);
                return true;
            }
            e.Cancel = true;
            errorProvider.SetError(dTP, $"Возраст сотрудника должен быть в " +
                                        $"диапазоне от {minAge} до {maxAge}");
            return false;
        }

        /// <summary>
        /// Checks if element is picked in TreeView 
        /// </summary>
        public static bool TreeView_PickValidator(TreeView tV, ErrorProvider errorProvider, CancelEventArgs e)
        {
            if (tV.SelectedNode == null)
            {
                e.Cancel = true;
                errorProvider.SetError(tV, $"Необходимо выбрать отдел");
                return false;
            }

            e.Cancel = false;
            errorProvider.SetError(tV, string.Empty);
            return true;
        }
    }
}
