using System;
using System.Windows.Forms;
using Npgsql;

namespace UserAuthApp
{
    public partial class RegisterForm : Form
    {
        private const string ConnectionString = "Host=127.0.0.1;Port=5432;Username=postgres;Password=5472;Database=postgres";

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Выберите роль.");
                return;
            }

            if (RegisterUser(username, password, email, role))
            {
                MessageBox.Show("Регистрация успешна!");
                Close(); 
            }
            else
            {
                MessageBox.Show("Ошибка регистрации.");
            }
        }

        private bool RegisterUser(string username, string password, string email, string role)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO users (username, password_hash, email, role_id)
                        VALUES (@username, crypt(@password, gen_salt('md5')), @email,
                                (SELECT id FROM roles WHERE name = @role))";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("username", username);
                        cmd.Parameters.AddWithValue("password", password);
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("role", role);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            var loginForm = new LoginForm();
            loginForm.ShowDialog(); 
            this.Close(); 
        }
    }
}
