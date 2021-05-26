
namespace KCompany_TestApp
{
    partial class DepartmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeView_departments = new System.Windows.Forms.TreeView();
            this.label9 = new System.Windows.Forms.Label();
            this.tB_Code = new System.Windows.Forms.TextBox();
            this.tB_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_checkAndApply = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBox_IncludeParentDep = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView_departments
            // 
            this.treeView_departments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView_departments.HideSelection = false;
            this.treeView_departments.Location = new System.Drawing.Point(15, 83);
            this.treeView_departments.Name = "treeView_departments";
            this.treeView_departments.Size = new System.Drawing.Size(489, 187);
            this.treeView_departments.TabIndex = 10;
            this.treeView_departments.Validating += new System.ComponentModel.CancelEventHandler(this.treeView_departments_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(293, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Мнемокод";
            // 
            // tB_Code
            // 
            this.tB_Code.Location = new System.Drawing.Point(296, 25);
            this.tB_Code.MaxLength = 10;
            this.tB_Code.Name = "tB_Code";
            this.tB_Code.Size = new System.Drawing.Size(141, 20);
            this.tB_Code.TabIndex = 2;
            this.tB_Code.Validating += new System.ComponentModel.CancelEventHandler(this.tB_Code_Validating);
            // 
            // tB_Name
            // 
            this.tB_Name.Location = new System.Drawing.Point(15, 25);
            this.tB_Name.MaxLength = 50;
            this.tB_Name.Name = "tB_Name";
            this.tB_Name.Size = new System.Drawing.Size(261, 20);
            this.tB_Name.TabIndex = 1;
            this.tB_Name.Validating += new System.ComponentModel.CancelEventHandler(this.tB_Name_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Название отдела*";
            // 
            // button_checkAndApply
            // 
            this.button_checkAndApply.Location = new System.Drawing.Point(360, 280);
            this.button_checkAndApply.Name = "button_checkAndApply";
            this.button_checkAndApply.Size = new System.Drawing.Size(141, 30);
            this.button_checkAndApply.TabIndex = 20;
            this.button_checkAndApply.Text = "Применить";
            this.button_checkAndApply.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 0;
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // checkBox_IncludeParentDep
            // 
            this.checkBox_IncludeParentDep.AutoSize = true;
            this.checkBox_IncludeParentDep.Location = new System.Drawing.Point(15, 58);
            this.checkBox_IncludeParentDep.Name = "checkBox_IncludeParentDep";
            this.checkBox_IncludeParentDep.Size = new System.Drawing.Size(179, 17);
            this.checkBox_IncludeParentDep.TabIndex = 3;
            this.checkBox_IncludeParentDep.Text = "Родительское подразделение";
            this.toolTip.SetToolTip(this.checkBox_IncludeParentDep, "Определяет наличие у отдела родительского подразделения.");
            this.checkBox_IncludeParentDep.UseVisualStyleBackColor = true;
            this.checkBox_IncludeParentDep.CheckedChanged += new System.EventHandler(this.checkBox_IncludeParentDep_CheckedChanged);
            // 
            // DepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(521, 319);
            this.Controls.Add(this.checkBox_IncludeParentDep);
            this.Controls.Add(this.button_checkAndApply);
            this.Controls.Add(this.tB_Code);
            this.Controls.Add(this.tB_Name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.treeView_departments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DepartmentForm";
            this.Text = "Базовая форма отдела";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DepartmentForm_FormClosed);
            this.Load += new System.EventHandler(this.DepartmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TreeView treeView_departments;
        protected System.Windows.Forms.TextBox tB_Code;
        protected System.Windows.Forms.TextBox tB_Name;
        protected System.Windows.Forms.Button button_checkAndApply;
        protected System.Windows.Forms.CheckBox checkBox_IncludeParentDep;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        protected System.Windows.Forms.ToolTip toolTip;
    }
}