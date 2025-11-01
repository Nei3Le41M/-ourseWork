using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace СourseWork
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<string, double> rates = new Dictionary<string, double>()
        {
            {"USD", 1.0},
            {"EUR", 0.92},
            {"KZT", 477.50},
            {"RUB", 95.30},
            {"GBP", 0.79}
        };


        private bool isLeftChanged = false;
        private bool isRightChanged = false;
        private string sessionFile = "session.txt";
        private Label hintLabel;
        private System.Windows.Forms.Timer hintTimer;

        private ProfilePopup profilePopup;

        private bool isAuthorized = false;

        private Button activeStyledButton = null;

        private void ApplyButtonStyles(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button button)
                {
                    // не трогаем кнопки авторизации в шапке
                    if (string.Equals(button.Name, "btnLogin", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(button.Name, "btnReg", StringComparison.OrdinalIgnoreCase))
                    {
                        // оставляем их поведение как было (текстовые кнопки)
                    }
                    else
                    {
                        StyleButton(button, 12,
                        Color.White,
                        Color.FromArgb(230, 230, 248),
                        Color.FromArgb(122, 86, 255));
                    }
                }
                if (control.HasChildren)
                {
                    ApplyButtonStyles(control);
                }
            }
        }

        private static void StyleButton(Button button, int cornerRadius, Color normal, Color hover, Color pressed)
        {
            button.UseVisualStyleBackColor = false;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = normal;
            button.FlatAppearance.MouseOverBackColor = hover;
            button.FlatAppearance.MouseDownBackColor = pressed;

            void applyCorners()
            {
                using (var path = BuildRoundPath(button.ClientRectangle, cornerRadius))
                {
                    button.Region = new Region(path);
                }
            }

            button.Resize += (s, e) => applyCorners();
            applyCorners();

            // hover подсветка только когда кнопка не активна
            Color baseNormal = normal;
            Color baseHover = hover;
            Color basePressed = pressed;

            button.MouseEnter += (s, e) =>
            {
                if (!(button.FindForm() as Form1)?.IsActiveButton(button) ?? true)
                    button.BackColor = baseHover;
            };
            button.MouseLeave += (s, e) =>
            {
                if (!(button.FindForm() as Form1)?.IsActiveButton(button) ?? true)
                    button.BackColor = baseNormal;
            };
            // активируем сразу на нажатие, без визуальной задержки от Click
            button.MouseDown += (s, e) =>
            {
                (button.FindForm() as Form1)?.SetActiveButton(button, baseNormal, baseHover, basePressed);
            };
        }

        private static GraphicsPath BuildRoundPath(Rectangle rect, int radius)
        {
            int diameter = radius * 2;
            var path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        private bool IsActiveButton(Button button)
        {
            return ReferenceEquals(activeStyledButton, button);
        }

        private void SetActiveButton(Button button, Color normal, Color hover, Color pressed)
        {
            // сбрасываем предыдущую активную
            if (activeStyledButton != null && !activeStyledButton.IsDisposed)
            {
                activeStyledButton.BackColor = normal;
                activeStyledButton.FlatAppearance.MouseOverBackColor = hover;
                activeStyledButton.FlatAppearance.MouseDownBackColor = pressed;
                activeStyledButton.ForeColor = Color.Black;
            }

            // активируем новую
            activeStyledButton = button;
            activeStyledButton.BackColor = pressed;
            activeStyledButton.FlatAppearance.MouseOverBackColor = pressed;
            activeStyledButton.FlatAppearance.MouseDownBackColor = pressed;
            activeStyledButton.ForeColor = Color.White;
        }
        private void SetSection(string title, Image icon)
        {
            lblSectionTitle.Text = title;
            picSectionIcon.Image = icon;
        }

        public Form1()
        {
            InitializeComponent();
            btnLogin.Click += btnLogin_Click;

            //закрытие меню при клике вне его
            profileIcon.Click += profileIcon_Click;
            this.MouseDown += Form1_MouseDown;
            this.Resize += Form1_Resize;
            AddGlobalClickHandler(this);
            //

            //loginLabel
            btnLogin.MouseEnter += (s, e) => btnLogin.ForeColor = Color.DarkViolet;
            btnLogin.MouseLeave += (s, e) => btnLogin.ForeColor = Color.MediumPurple;
            //

            // применяем единый стиль к кнопкам (скругление + hover/pressed цвета)
            ApplyButtonStyles(this);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(sessionFile))
            {
                string savedUser = File.ReadAllText(sessionFile).Trim();
                if (!string.IsNullOrEmpty(savedUser))
                {
                    btnLogin.Visible = false;
                    btnReg.Visible = false;
                    profileIcon.Visible = true;
                }
                else
                {
                    btnLogin.Visible = true;
                    btnReg.Visible = true;
                    profileIcon.Visible = false;
                }
            }
            else
            {
                btnLogin.Visible = true;
                btnReg.Visible = true;
                profileIcon.Visible = false;
            }

            // Вход в аккаунт 
            if (File.Exists(sessionFile))
            {
                string savedUser = File.ReadAllText(sessionFile).Trim();
                if (!string.IsNullOrEmpty(savedUser))
                {
                    SessionManager.IsAuthorized = true;
                    btnLogin.Visible = false;
                    btnReg.Visible = false;
                    profileIcon.Visible = true;
                }
                else
                {
                    SessionManager.IsAuthorized = false;
                    btnLogin.Visible = true;
                    btnReg.Visible = true;
                    profileIcon.Visible = false;
                }
            }
        }

        // Закрытие profile popup при клике вне его
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (profilePopup != null && !profilePopup.IsDisposed)
            {
                if (!profileIcon.Bounds.Contains(e.Location))
                {
                    profilePopup.Close();
                    profilePopup = null;
                }
            }
        }
        //

        // Закрытие profile popup при изменении размера окна
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (profilePopup != null && !profilePopup.IsDisposed)
            {
                profilePopup.Close();
                profilePopup = null;
            }
        }
        //

        //Закрытие profile popup при клике на кнопки и другие элементы
        private void AddGlobalClickHandler(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.MouseDown += (s, e) =>
                {
                    if (profilePopup != null && !profilePopup.IsDisposed)
                    {
                        profilePopup.Close();
                        profilePopup = null;
                    }
                };
                AddGlobalClickHandler(ctrl);
            }
        }
        //


        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (LoginForm loginForm = new LoginForm())
            {
                loginForm.ShowDialog();

                if (SessionManager.IsAuthorized)
                {
                    btnLogin.Visible = false;
                    btnReg.Visible = false;
                    profileIcon.Visible = true;

                    if (File.Exists("user_avatar.png"))
                        profileIcon.Image = Image.FromFile("user_avatar.png");
                }
                else
                {
                    btnLogin.Visible = true;
                    btnReg.Visible = true;
                    profileIcon.Visible = false;
                }
            }
            this.Show();
        }

        private void profileIcon_Click(object sender, EventArgs e)
        {
            if (profilePopup != null && !profilePopup.IsDisposed)
            {
                profilePopup.Close();
                profilePopup = null;
                return;
            }

            string username = File.Exists("session.txt") ? File.ReadAllText("session.txt").Trim() : "Пользователь";
            string email = "user@gmail.com";

            string usersFile = "users.txt";
            if (File.Exists(usersFile))
            {
                var lines = File.ReadAllLines(usersFile);
                foreach (var line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 3 && parts[0] == username)
                    {
                        email = parts[1];
                        break;
                    }
                }
            }

            // создаём окно профиля с найденными данными
            profilePopup = new ProfilePopup(username, email);

            var iconScreenPos = profileIcon.PointToScreen(Point.Empty);
            profilePopup.Location = new Point(iconScreenPos.X - profilePopup.Width + profileIcon.Width, iconScreenPos.Y + profileIcon.Height + 5);

            profilePopup.LogoutClicked += (s, ev) =>
            {
                SessionManager.IsAuthorized = false;
                SessionManager.CurrentUser = "";
                File.Delete("session.txt");
                profileIcon.Visible = false;
                btnLogin.Visible = true;
                btnReg.Visible = true;
            };

            profilePopup.Show();
        }


        private void btnReg_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (RegisterForm registerForm = new RegisterForm())
            {
                registerForm.ShowDialog();
            }
            this.Show();
        }

        //Доп фунцкии после входа в аккаунт
        private void ShowHint(Control targetButton, string message)
        {
            hintLabel?.Dispose();

            hintLabel = new Label
            {
                Text = message,
                BackColor = Color.FromArgb(40, 40, 40),
                ForeColor = Color.White,
                AutoSize = true,
                Padding = new Padding(8),
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                BorderStyle = BorderStyle.FixedSingle
            };

            this.Controls.Add(hintLabel);
            hintLabel.BringToFront();

            Point btnPos = targetButton.PointToScreen(Point.Empty);
            Point formPos = this.PointToClient(btnPos);

            int x = formPos.X + (targetButton.Width - hintLabel.Width) / 2;
            int y = formPos.Y - hintLabel.Height - 5;

            if (x < 5) x = 5;

            if (x + hintLabel.Width > this.ClientSize.Width - 5)
                x = this.ClientSize.Width - hintLabel.Width - 5;

            if (y < 0)
                y = formPos.Y + targetButton.Height + 5;

            hintLabel.Location = new Point(x, y);

            System.Windows.Forms.Timer hintTimer = new System.Windows.Forms.Timer();
            hintTimer.Interval = 2000;
            hintTimer.Tick += (s, e) =>
            {
                hintTimer.Stop();
                hintLabel?.Dispose();
            };
            hintTimer.Start();
        }



        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsAuthorized)
            {
                ShowHint(btnHistory, "Зарегистрируйтесь, чтобы продолжить");
                return;
            }
            LoadPage(new HistoryPage());
            SetSection("История", Properties.Resources.history);
        }

        private void btnCurrency_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsAuthorized)
            {
                ShowHint(btnCurrency, "Войдите, чтобы открыть расширенные курсы");
                return;
            }
            LoadPage(new CurrencyPage());
            SetSection("Валюты", Properties.Resources.currency);
        }
        private void btnDynamics_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsAuthorized)
            {
                ShowHint(btnDynamics, "Авторизуйтесь для доступа к динамике валют");
                return;
            }
            LoadPage(new DynamicsPage());
            SetSection("График", Properties.Resources.converter);
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            LoadPage(new ConverterPage());
            SetSection("Конвертер", Properties.Resources.converter);
        }

        private void LoadPage(UserControl page)
        {
            // Сохраняем panel4 перед очисткой
            Panel savedPanel4 = panel4;
            mainPanel.Controls.Clear(); // очищаем старую страницу

            // Возвращаем panel4 обратно
            mainPanel.Controls.Add(savedPanel4);

            page.Dock = DockStyle.Fill; // растягиваем на всю панель
            mainPanel.Controls.Add(page);
        }
    }


    // Вспомогательные методы стилизации кнопок

    public static class SessionManager
    {
        public static bool IsAuthorized { get; set; } = false;
        public static string CurrentUser { get; set; } = "";
    }


}
