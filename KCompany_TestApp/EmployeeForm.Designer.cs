
namespace KCompany_TestApp
{
    partial class EmployeeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tB_SurName = new System.Windows.Forms.TextBox();
            this.tB_FirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tB_Patronymic = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tB_DocNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tB_DocSeries = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tB_Position = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button_addNewEmployee = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dateTimePicker_dateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.treeView_departments = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия*";
            // 
            // tB_SurName
            // 
            this.tB_SurName.Location = new System.Drawing.Point(14, 77);
            this.tB_SurName.MaxLength = 50;
            this.tB_SurName.Name = "tB_SurName";
            this.tB_SurName.Size = new System.Drawing.Size(261, 20);
            this.tB_SurName.TabIndex = 0;
            this.tB_SurName.Validating += new System.ComponentModel.CancelEventHandler(this.tB_SurName_Validating);
            // 
            // tB_FirstName
            // 
            this.tB_FirstName.Location = new System.Drawing.Point(14, 116);
            this.tB_FirstName.MaxLength = 50;
            this.tB_FirstName.Name = "tB_FirstName";
            this.tB_FirstName.Size = new System.Drawing.Size(261, 20);
            this.tB_FirstName.TabIndex = 1;
            this.tB_FirstName.Validating += new System.ComponentModel.CancelEventHandler(this.tB_FirstName_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя*";
            // 
            // tB_Patronymic
            // 
            this.tB_Patronymic.Location = new System.Drawing.Point(14, 155);
            this.tB_Patronymic.MaxLength = 50;
            this.tB_Patronymic.Name = "tB_Patronymic";
            this.tB_Patronymic.Size = new System.Drawing.Size(261, 20);
            this.tB_Patronymic.TabIndex = 2;
            this.tB_Patronymic.Validating += new System.ComponentModel.CancelEventHandler(this.tB_Patronymic_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Отчество";
            // 
            // tB_DocNumber
            // 
            this.tB_DocNumber.Location = new System.Drawing.Point(295, 155);
            this.tB_DocNumber.MaxLength = 6;
            this.tB_DocNumber.Name = "tB_DocNumber";
            this.tB_DocNumber.Size = new System.Drawing.Size(141, 20);
            this.tB_DocNumber.TabIndex = 5;
            this.tB_DocNumber.Validating += new System.ComponentModel.CancelEventHandler(this.tB_DocNumber_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Номер документа";
            // 
            // tB_DocSeries
            // 
            this.tB_DocSeries.Location = new System.Drawing.Point(295, 116);
            this.tB_DocSeries.MaxLength = 4;
            this.tB_DocSeries.Name = "tB_DocSeries";
            this.tB_DocSeries.Size = new System.Drawing.Size(141, 20);
            this.tB_DocSeries.TabIndex = 4;
            this.tB_DocSeries.Validating += new System.ComponentModel.CancelEventHandler(this.tB_DocSeries_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(292, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Серия документа";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(292, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Дата рождения*";
            // 
            // tB_Position
            // 
            this.tB_Position.Location = new System.Drawing.Point(14, 232);
            this.tB_Position.MaxLength = 50;
            this.tB_Position.Name = "tB_Position";
            this.tB_Position.Size = new System.Drawing.Size(422, 20);
            this.tB_Position.TabIndex = 7;
            this.tB_Position.Validating += new System.ComponentModel.CancelEventHandler(this.tB_Position_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Название должности*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 257);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Отдел*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Личные данные";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(10, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Должность";
            // 
            // button_addNewEmployee
            // 
            this.button_addNewEmployee.Location = new System.Drawing.Point(295, 468);
            this.button_addNewEmployee.Name = "button_addNewEmployee";
            this.button_addNewEmployee.Size = new System.Drawing.Size(141, 30);
            this.button_addNewEmployee.TabIndex = 20;
            this.button_addNewEmployee.Text = "Применить изменения";
            this.button_addNewEmployee.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(318, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Помеченные звездочкой (*) поля обязательны к заполнению";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 0;
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // dateTimePicker_dateOfBirth
            // 
            this.dateTimePicker_dateOfBirth.Location = new System.Drawing.Point(295, 77);
            this.dateTimePicker_dateOfBirth.Name = "dateTimePicker_dateOfBirth";
            this.dateTimePicker_dateOfBirth.Size = new System.Drawing.Size(141, 20);
            this.dateTimePicker_dateOfBirth.TabIndex = 3;
            this.dateTimePicker_dateOfBirth.Value = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_dateOfBirth.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimePicker_dateOfBirth_Validating);
            // 
            // treeView_departments
            // 
            this.treeView_departments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView_departments.HideSelection = false;
            this.treeView_departments.Location = new System.Drawing.Point(14, 273);
            this.treeView_departments.Name = "treeView_departments";
            this.treeView_departments.Size = new System.Drawing.Size(422, 187);
            this.treeView_departments.TabIndex = 25;
            this.treeView_departments.Validating += new System.ComponentModel.CancelEventHandler(this.treeView_departments_Validating);
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(454, 510);
            this.Controls.Add(this.treeView_departments);
            this.Controls.Add(this.dateTimePicker_dateOfBirth);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button_addNewEmployee);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tB_Position);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tB_DocNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tB_DocSeries);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tB_Patronymic);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tB_FirstName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tB_SurName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeForm";
            this.Text = "Сотрудник";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EmployeeForm_FormClosed);
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        protected System.Windows.Forms.TextBox tB_SurName;
        protected System.Windows.Forms.TextBox tB_FirstName;
        protected System.Windows.Forms.TextBox tB_Patronymic;
        protected System.Windows.Forms.TextBox tB_DocNumber;
        protected System.Windows.Forms.TextBox tB_DocSeries;
        protected System.Windows.Forms.TextBox tB_Position;
        protected System.Windows.Forms.Button button_addNewEmployee;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        protected System.Windows.Forms.DateTimePicker dateTimePicker_dateOfBirth;
        protected System.Windows.Forms.TreeView treeView_departments;
    }
}