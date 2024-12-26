
using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace demo2
{
    public partial class AdminForm : Form
    {
        private string connectionString = "Host=127.0.0.1;Port=5432;Username=postgres;Password=5472;Database=postgres";

        public AdminForm()
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
        }

        // Обновление задачи
        private void UpdateTask(int taskId, string status, string priority)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE tasks SET status = @status, priority = @priority WHERE task_id = @taskId";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@taskId", taskId);
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@priority", priority);
                    command.ExecuteNonQuery();
                }
            }
            LoadTasks();
        }

        // Удаление задачи
        private void DeleteTask(int taskId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM tasks WHERE task_id = @taskId";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@taskId", taskId);
                    command.ExecuteNonQuery();
                }
            }
            LoadTasks();
        }

        // Расчет статистики
        private void CalculateStatistics()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) AS completedTasks FROM tasks WHERE status = 'выполнено'";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    int completedTasks = Convert.ToInt32(command.ExecuteScalar());
                    MessageBox.Show($"Количество выполненных задач: {completedTasks}", "Статистика");
                }
            }
        }

        // Обработчики событий кнопок
        private void addButton_Click(object sender, EventArgs e)
        {
            AddTask("Новый проект", "Описание задачи", "средний", "в ожидании");
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (tasksGridView.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(tasksGridView.SelectedRows[0].Cells["task_id"].Value);
                UpdateTask(taskId, "в работе", "высокий");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (tasksGridView.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(tasksGridView.SelectedRows[0].Cells["task_id"].Value);
                DeleteTask(taskId);
            }
        }

        private void statsButton_Click(object sender, EventArgs e)
        {
            CalculateStatistics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tasksGridView.SelectedRows.Count > 0)
            {
                int taskId = Convert.ToInt32(tasksGridView.SelectedRows[0].Cells["task_id"].Value);
                UpdateTaskStatusToCompleted(taskId);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите задачу для обновления статуса.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void UpdateTaskStatusToCompleted(int taskId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE tasks SET status = 'выполнено' WHERE task_id = @taskId";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@taskId", taskId);
                    command.ExecuteNonQuery();
                }
            }
            LoadTasks(); // Перезагружаем задачи, чтобы отобразить обновления
            MessageBox.Show("Статус задачи обновлен на 'выполнено'.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
