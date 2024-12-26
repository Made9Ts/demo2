namespace demo2
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView tasksGridView;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button statsButton;
        private System.Windows.Forms.Label tasksLabel;

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
            this.tasksGridView = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.statsButton = new System.Windows.Forms.Button();
            this.tasksLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tasksGridView
            // 
            this.tasksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksGridView.Location = new System.Drawing.Point(12, 32);
            this.tasksGridView.Name = "tasksGridView";
            this.tasksGridView.Size = new System.Drawing.Size(760, 400);
            this.tasksGridView.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 506);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 43);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(93, 506);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 43);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Обновить";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(174, 506);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 43);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // statsButton
            // 
            this.statsButton.Location = new System.Drawing.Point(255, 506);
            this.statsButton.Name = "statsButton";
            this.statsButton.Size = new System.Drawing.Size(75, 43);
            this.statsButton.TabIndex = 4;
            this.statsButton.Text = "Статистика";
            this.statsButton.UseVisualStyleBackColor = true;
            this.statsButton.Click += new System.EventHandler(this.statsButton_Click);
            // 
            // tasksLabel
            // 
            this.tasksLabel.AutoSize = true;
            this.tasksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tasksLabel.Location = new System.Drawing.Point(12, 9);
            this.tasksLabel.Name = "tasksLabel";
            this.tasksLabel.Size = new System.Drawing.Size(130, 20);
            this.tasksLabel.TabIndex = 5;
            this.tasksLabel.Text = "Список задач:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 43);
            this.button1.TabIndex = 6;
            this.button1.Text = "Статус";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdminForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tasksLabel);
            this.Controls.Add(this.statsButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.tasksGridView);
            this.Name = "AdminForm";
            this.Text = "Управление задачами";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button button1;
    }
}
