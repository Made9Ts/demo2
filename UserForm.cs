using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace demo2
{
    public partial class UserForm : Form
    {
        private string connectionString = "Host=127.0.0.1;Port=5432;Username=postgres;Password=5472;Database=postgres";
        private TextBox projectNameTextBox;
        private TextBox descriptionTextBox;
        private ComboBox priorityComboBox;
        private ComboBox statusComboBox;
        private Button addButton;
        private TextBox searchTextBox;
        private Button searchButton;

        public UserForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTasks();
        }

        // Загрузка задач в DataGridView
        private void LoadTasks()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT task_id, project_name, description, priority, status FROM tasks";
                using (var adapter = new NpgsqlDataAdapter(query, connection))
                {
                    DataTable tasksTable = new DataTable();
                    adapter.Fill(tasksTable);
                    tasksGridView.DataSource = tasksTable;
                }
            }
        }

        // Добавление новой задачи
        private void AddTask(string projectName, string description, string priority, string status)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO tasks (project_name, description, priority, status) VALUES (@projectName, @description, @priority, @status)";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@projectName", projectName);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@priority", priority);
                    command.Parameters.AddWithValue("@status", status);
                    command.ExecuteNonQuery();
                }
            }
            LoadTasks();
            MessageBox.Show("Задача успешно добавлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Обработчик кнопки для добавления задачи
        private void addButton_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы все поля были заполнены
            if (string.IsNullOrWhiteSpace(projectNameTextBox.Text) || string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем данные из полей
            string projectName = projectNameTextBox.Text;
            string description = descriptionTextBox.Text;
            string priority = priorityComboBox.SelectedItem.ToString();
            string status = statusComboBox.SelectedItem.ToString();

            // Добавляем задачу в базу данных
            AddTask(projectName, description, priority, status);
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchQuery = searchTextBox.Text;

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                MessageBox.Show("Пожалуйста, введите номер задачи или ключевое слово для поиска.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Выполняем поиск по номеру задачи или ключевым словам
            SearchTasks(searchQuery);
        }

        // Поиск задач в базе данных
        private void SearchTasks(string searchQuery)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // SQL-запрос для поиска по номеру задачи или по ключевым словам в названии или описании
                string query = @"
                    SELECT task_id, project_name, description, priority, status
                    FROM tasks
                    WHERE task_id::text LIKE @searchQuery OR
                    project_name LIKE @searchQuery OR
                    description LIKE @searchQuery";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable resultTable = new DataTable();
                        adapter.Fill(resultTable);
                        tasksGridView.DataSource = resultTable;
                    }
                }
            }
        }
    }
}