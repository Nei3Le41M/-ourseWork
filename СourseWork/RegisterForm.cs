using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace СourseWork
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            SetupUI();

            this.Shown += (s, e) =>
            {
                this.ActiveControl = null;
            };
        }

        private void SetupUI()
        {
            this.Text = "Register";
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = User.Text.Trim();
            string email = Email.Text.Trim();
            string password = PasswordReg.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filePath = "users.txt";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length > 0 && parts[0] == username)
                    {
                        MessageBox.Show("Такой логин уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            File.AppendAllText(filePath, $"{username}|{email}|{password}\n");

            MessageBox.Show("Аккаунт успешно зарегистрирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void pictureBoxCloseReg_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxCloseReg.Image = Image.FromFile("C:\\Users\\Alex\\OneDrive\\Pictures\\CourseWork\\darkclose.png");
        }

        private void pictureBoxCloseReg_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxCloseReg.Image = Image.FromFile("C:\\Users\\Alex\\OneDrive\\Pictures\\CourseWork\\redclose.png");
        }

        private void pictureBoxCloseReg_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
