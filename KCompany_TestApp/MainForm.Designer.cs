
namespace KCompany_TestApp
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.treeView_departments = new System.Windows.Forms.TreeView();
            this.button_editDepartment = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView_employees = new System.Windows.Forms.DataGridView();
            this.SurName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.button_addEmployee = new System.Windows.Forms.Button();
            this.button_editEmployee = new System.Windows.Forms.Button();
            this.button_deleteEmployee = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.button_addDepartment = new System.Windows.Forms.Button();
            this.button_deleteDepartment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_employees)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView_departments
            // 
            this.treeView_departments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView_departments.HideSelection = false;
            this.treeView_departments.Location = new System.Drawing.Point(12, 42);
            this.treeView_departments.Name = "treeView_departments";
            this.treeView_departments.Size = new System.Drawing.Size(414, 343);
            this.treeView_departments.TabIndex = 0;
            this.treeView_departments.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_departments_AfterSelect);
            // 
            // button_editDepartment
            // 
            this.button_editDepartment.Location = new System.Drawing.Point(248, 5);
            this.button_editDepartment.Name = "button_editDepartment";
            this.button_editDepartment.Size = new System.Drawing.Size(98, 32);
            this.button_editDepartment.TabIndex = 2;
            this.button_editDepartment.Text = "Редактировать";
            this.toolTip.SetToolTip(this.button_editDepartment, "Просмотр / изменение информации о выбранном отделе");
            this.button_editDepartment.UseVisualStyleBackColor = true;
            this.button_editDepartment.Click += new System.EventHandler(this.button_editDepartment_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Структура предприятия";
            // 
            // dataGridView_employees
            // 
            this.dataGridView_employees.AllowUserToAddRows = false;
            this.dataGridView_employees.AllowUserToDeleteRows = false;
            this.dataGridView_employees.AllowUserToResizeColumns = false;
            this.dataGridView_employees.AllowUserToResizeRows = false;
            this.dataGridView_employees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_employees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SurName,
            this.FirstName,
            this.Patronymic,
            this.Position,
            this.Age,
            this.DateOfBirth,
            this.DocSeries,
            this.DocNumber});
            this.dataGridView_employees.Location = new System.Drawing.Point(432, 42);
            this.dataGridView_employees.Name = "dataGridView_employees";
            this.dataGridView_employees.ReadOnly = true;
            this.dataGridView_employees.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView_employees.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView_employees.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_employees.Size = new System.Drawing.Size(801, 343);
            this.dataGridView_employees.TabIndex = 4;
            this.dataGridView_employees.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_employees_RowEnter);
            this.dataGridView_employees.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_employees_RowLeave);
            this.dataGridView_employees.SelectionChanged += new System.EventHandler(this.dataGridView_employees_SelectionChanged);
            // 
            // SurName
            // 
            this.SurName.HeaderText = "Фамилия";
            this.SurName.Name = "SurName";
            this.SurName.ReadOnly = true;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "Имя";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // Patronymic
            // 
            this.Patronymic.HeaderText = "Отчество";
            this.Patronymic.Name = "Patronymic";
            this.Patronymic.ReadOnly = true;
            // 
            // Position
            // 
            this.Position.HeaderText = "Должность";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            this.Position.Width = 125;
            // 
            // Age
            // 
            this.Age.HeaderText = "Возраст";
            this.Age.Name = "Age";
            this.Age.ReadOnly = true;
            this.Age.Width = 75;
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.HeaderText = "Дата рождения";
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.ReadOnly = true;
            this.DateOfBirth.Width = 85;
            // 
            // DocSeries
            // 
            this.DocSeries.HeaderText = "Серия документа";
            this.DocSeries.Name = "DocSeries";
            this.DocSeries.ReadOnly = true;
            this.DocSeries.Width = 90;
            // 
            // DocNumber
            // 
            this.DocNumber.HeaderText = "Номер документа";
            this.DocNumber.Name = "DocNumber";
            this.DocNumber.ReadOnly = true;
            this.DocNumber.Width = 95;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(428, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Список сотрудников";
            // 
            // button_addEmployee
            // 
            this.button_addEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_addEmployee.Location = new System.Drawing.Point(740, 5);
            this.button_addEmployee.Name = "button_addEmployee";
            this.button_addEmployee.Size = new System.Drawing.Size(32, 32);
            this.button_addEmployee.TabIndex = 7;
            this.button_addEmployee.Text = "+";
            this.toolTip.SetToolTip(this.button_addEmployee, "Добавить нового сотрудника");
            this.button_addEmployee.UseVisualStyleBackColor = true;
            this.button_addEmployee.Click += new System.EventHandler(this.button_addEmployee_Click);
            // 
            // button_editEmployee
            // 
            this.button_editEmployee.Location = new System.Drawing.Point(636, 5);
            this.button_editEmployee.Name = "button_editEmployee";
            this.button_editEmployee.Size = new System.Drawing.Size(98, 32);
            this.button_editEmployee.TabIndex = 6;
            this.button_editEmployee.Text = "Редактировать";
            this.toolTip.SetToolTip(this.button_editEmployee, "Редактировать данные выбранного сотрудника");
            this.button_editEmployee.UseVisualStyleBackColor = true;
            this.button_editEmployee.Click += new System.EventHandler(this.button_editEmployee_Click);
            // 
            // button_deleteEmployee
            // 
            this.button_deleteEmployee.Font = new System.Drawing.Font("Lay\'s", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_deleteEmployee.Location = new System.Drawing.Point(598, 5);
            this.button_deleteEmployee.Name = "button_deleteEmployee";
            this.button_deleteEmployee.Size = new System.Drawing.Size(32, 32);
            this.button_deleteEmployee.TabIndex = 5;
            this.button_deleteEmployee.Text = "-";
            this.toolTip.SetToolTip(this.button_deleteEmployee, "Удалить выбранного сотрудника");
            this.button_deleteEmployee.UseVisualStyleBackColor = true;
            this.button_deleteEmployee.Click += new System.EventHandler(this.button_deleteEmployee_Click);
            // 
            // button_addDepartment
            // 
            this.button_addDepartment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_addDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_addDepartment.Location = new System.Drawing.Point(352, 5);
            this.button_addDepartment.Name = "button_addDepartment";
            this.button_addDepartment.Size = new System.Drawing.Size(32, 32);
            this.button_addDepartment.TabIndex = 3;
            this.button_addDepartment.Text = "+";
            this.toolTip.SetToolTip(this.button_addDepartment, "Добавить новый отдел");
            this.button_addDepartment.UseVisualStyleBackColor = true;
            this.button_addDepartment.Click += new System.EventHandler(this.button_addDepartment_Click);
            // 
            // button_deleteDepartment
            // 
            this.button_deleteDepartment.Font = new System.Drawing.Font("Lay\'s", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_deleteDepartment.Location = new System.Drawing.Point(210, 5);
            this.button_deleteDepartment.Name = "button_deleteDepartment";
            this.button_deleteDepartment.Size = new System.Drawing.Size(32, 32);
            this.button_deleteDepartment.TabIndex = 1;
            this.button_deleteDepartment.Text = "-";
            this.toolTip.SetToolTip(this.button_deleteDepartment, "Удалить выделенный отдел");
            this.button_deleteDepartment.UseVisualStyleBackColor = true;
            this.button_deleteDepartment.Click += new System.EventHandler(this.button_deleteDepartment_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1247, 397);
            this.Controls.Add(this.button_deleteDepartment);
            this.Controls.Add(this.button_addDepartment);
            this.Controls.Add(this.button_deleteEmployee);
            this.Controls.Add(this.button_editEmployee);
            this.Controls.Add(this.button_addEmployee);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView_employees);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_editDepartment);
            this.Controls.Add(this.treeView_departments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Tag = "";
            this.Text = "Предприятие";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_employees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_departments;
        private System.Windows.Forms.Button button_editDepartment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView_employees;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_addEmployee;
        private System.Windows.Forms.Button button_editEmployee;
        private System.Windows.Forms.Button button_deleteEmployee;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocSeries;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocNumber;
        private System.Windows.Forms.Button button_addDepartment;
        private System.Windows.Forms.Button button_deleteDepartment;
    }
}

