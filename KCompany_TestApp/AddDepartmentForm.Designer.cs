
namespace KCompany_TestApp
{
    partial class AddDepartmentForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView_departments
            // 
            this.treeView_departments.LineColor = System.Drawing.Color.Black;
            // 
            // button_checkAndApply
            // 
            this.button_checkAndApply.Text = "Добавить отдел";
            this.button_checkAndApply.Click += new System.EventHandler(this.button_checkAndApply_Click);
            // 
            // checkBox_IncludeParentDep
            // 
            this.toolTip.SetToolTip(this.checkBox_IncludeParentDep, "Определяет наличие у отдела родительского подразделения.");
            // 
            // AddDepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(521, 319);
            this.Name = "AddDepartmentForm";
            this.Text = "Добавление нового отдела";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
