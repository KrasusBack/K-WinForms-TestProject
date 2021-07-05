
namespace KCompany_TestApp
{
    partial class EditDepartmentForm
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
            this.button_depParentHelpInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView_departments
            // 
            this.treeView_departments.LineColor = System.Drawing.Color.Black;
            // 
            // button_checkAndApply
            // 
            this.button_checkAndApply.Text = "Сохранить изменения";
            this.button_checkAndApply.Click += new System.EventHandler(this.button_checkAndApply_Click);
            // 
            // checkBox_IncludeParentDep
            // 
            this.toolTip.SetToolTip(this.checkBox_IncludeParentDep, "Определяет наличие у отдела родительского подразделения.");
            // 
            // button_depParentHelpInfo
            // 
            this.button_depParentHelpInfo.Cursor = System.Windows.Forms.Cursors.Help;
            this.button_depParentHelpInfo.Location = new System.Drawing.Point(200, 54);
            this.button_depParentHelpInfo.Name = "button_depParentHelpInfo";
            this.button_depParentHelpInfo.Size = new System.Drawing.Size(23, 23);
            this.button_depParentHelpInfo.TabIndex = 4;
            this.button_depParentHelpInfo.Text = "?";
            this.toolTip.SetToolTip(this.button_depParentHelpInfo, "Информация о выборе родительских подразделений");
            this.button_depParentHelpInfo.UseVisualStyleBackColor = true;
            this.button_depParentHelpInfo.Click += new System.EventHandler(this.button_depParentHelpInfo_Click);
            // 
            // EditDepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(521, 319);
            this.Controls.Add(this.button_depParentHelpInfo);
            this.Name = "EditDepartmentForm";
            this.Text = "Редактировани отдела";
            this.Controls.SetChildIndex(this.treeView_departments, 0);
            this.Controls.SetChildIndex(this.tB_Name, 0);
            this.Controls.SetChildIndex(this.tB_Code, 0);
            this.Controls.SetChildIndex(this.button_checkAndApply, 0);
            this.Controls.SetChildIndex(this.checkBox_IncludeParentDep, 0);
            this.Controls.SetChildIndex(this.button_depParentHelpInfo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_depParentHelpInfo;
    }
}
