namespace demo2
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView tasksGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        // Dispose method to clean up any resources
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Initialize components of the form
        private void InitializeComponent()
        {
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.priorityComboBox = new System.Windows.Forms.ComboBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.tasksGridView = new System.Windows.Forms.DataGridView();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Location = new System.Drawing.Point(20, 30);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.projectNameTextBox.TabIndex = 0;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(20, 73);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(200, 20);
            this.descriptionTextBox.TabIndex = 1;
            // 
            // priorityComboBox
            // 
            this.priorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priorityComboBox.Items.AddRange(new object[] {
            "низкий",
            "средний"});
            this.priorityComboBox.Location = new System.Drawing.Point(20, 110);
            this.priorityComboBox.Name = "priorityComboBox";
            this.priorityComboBox.Size = new System.Drawing.Size(200, 21);
            this.priorityComboBox.TabIndex = 2;
            // 
            // statusComboBox
            // 
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.Items.AddRange(new object[] {
            "в ожидании"});
            this.statusComboBox.Location = new System.Drawing.Point(20, 150);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(200, 21);
            this.statusComboBox.TabIndex = 3;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(20, 190);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 30);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Добавить задачу";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // tasksGridView
            // 
            this.tasksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksGridView.Location = new System.Drawing.Point(250, 30);
            this.tasksGridView.Name = "tasksGridView";
            this.tasksGridView.Size = new System.Drawing.Size(640, 200);
            this.tasksGridView.TabIndex = 5;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(584, 368);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(200, 20);
            this.searchTextBox.TabIndex = 6;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(790, 362);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 30);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Поиск";
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Введите название проекта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Введите описание задачи";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(581, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Введите номер или ключевое слово";
            // 
            // UserForm
            // 
            this.ClientSize = new System.Drawing.Size(902, 404);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.priorityComboBox);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.tasksGridView);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchButton);
            this.Name = "UserForm";
            this.Text = "Добавить задачу";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label3;
    }
}
