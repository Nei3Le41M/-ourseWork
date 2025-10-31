using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace СourseWork
{
    public class ProfilePopup : Form
    {
        private Label lblName;
        private Label lblEmail;
        private PictureBox avatar;
        private Button btnLogout;

        public event EventHandler LogoutClicked;

        public ProfilePopup(string username, string email)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Size = new Size(260, 280);
            this.ShowInTaskbar = false;
            this.TopMost = true;

            // Округлые углы
            this.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20)
            );

            avatar = new PictureBox()
            {
                Size = new Size(70, 70),
                Location = new Point((this.Width - 70) / 2, 20),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = File.Exists("user_avatar.png") ? Image.FromFile("user_avatar.png") : Properties.Resources.default_avatar
            };
            this.Controls.Add(avatar);

            lblName = new Label()
            {
                Text = username,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.None,
                Location = new Point(0, 100),
                Size = new Size(this.Width, 30)
            };
            this.Controls.Add(lblName);

            lblEmail = new Label()
            {
                Text = email,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.LightGray,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.None,
                Location = new Point(0, 130),
                Size = new Size(this.Width, 30)
            };
            this.Controls.Add(lblEmail);

            btnLogout = new Button()
            {
                Text = "Выйти",
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 35),
                Location = new Point((this.Width - 100) / 2, 200)
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += (s, e) => LogoutClicked?.Invoke(this, EventArgs.Empty);
            this.Controls.Add(btnLogout);
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);
    }
}
