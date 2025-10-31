using System;
using System.Drawing;
using System.Windows.Forms;
using СourseWork;
using System.IO;

namespace СourseWork
{
    public partial class LoginForm : Form
    {
        public bool IsAuthorized { get; private set; } = false;
        private string userFile = "users.txt";


        public LoginForm()
        {
            InitializeComponent();
            SetupUI();

            linkRegister.LinkClicked += linkRegister_LinkClicked;

            this.AcceptButton = btnLogin;

        }

        private void SetupUI()
        {
            this.Text = "Login";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = Username.Text.Trim();
            string password = Password.Text.Trim();
            string filePath = "users.txt";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Нет зарегистрированных пользователей. Пожалуйста, зарегистрируйтесь!");
                return;
            }
            bool loginSuccess = false;
            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split('|');
                if (parts.Length >= 3 && parts[0] == username && parts[2] == password)
                {
                    loginSuccess = true;
                    break;
                }
            }

            if (loginSuccess)
            {
                SessionManager.IsAuthorized = true;
                SessionManager.CurrentUser = username;

                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
            //SaveLogin
            if (loginSuccess)
            {
                SessionManager.IsAuthorized = true;
                SessionManager.CurrentUser = username;


                File.WriteAllText("session.txt", username);
                this.Close();
            }

        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void pictureBoxClose_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxClose.Image = Image.FromFile("C:\\Users\\Alex\\OneDrive\\Pictures\\CourseWork\\redclose.png");
        }

        private void pictureBoxClose_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxClose.Image = Image.FromFile("C:\\Users\\Alex\\OneDrive\\Pictures\\CourseWork\\darkclose.png");
        }
    }
}
