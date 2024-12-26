using System;
using System.Windows.Forms;
using demo2;
using Npgsql;

namespace UserAuthApp
{
    public partial class LoginForm : Form
    {
        private const string ConnectionString = "Host=127.0.0.1;Port=5432;Username=postgres;Password=5472;Database=postgres";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string role = AuthenticateUser(username, password);
            if (role != null)
            {
                MessageBox.Show($"Добро пожаловать, {username}! Ваша роль: {role}");
                OpenRoleBasedForm(role);
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }

        private void btnOpenRegisterForm_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            this.Hide(); 
            var result = registerForm.ShowDialog(); 
            this.Show(); 
            if (result == DialogResult.OK)
            {
                this.Close(); 
            }
        }

        private string AuthenticateUser(string username, string password)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT r.name
                        FROM users u
                        JOIN roles r ON u.role_id = r.id
                        WHERE u.username = @username AND u.password_hash = crypt(@password, u.password_hash)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("username", username);
                        cmd.Parameters.AddWithValue("password", password);
                        var role = cmd.ExecuteScalar();
                        return role?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return null;
            }
        }

        private void OpenRoleBasedForm(string role)
        {
            if (role == "admin")
            {
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
                
            }
            else if (role == "user")
            {
                UserForm userForm = new UserForm();
                userForm.Show();
                
            }
        }
    }
}
