namespace СourseWork
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            btnLogin = new Button();
            label1 = new Label();
            Username = new TextBox();
            panel1 = new Panel();
            Password = new TextBox();
            panel2 = new Panel();
            linkRegister = new LinkLabel();
            pictureBoxClose = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxClose).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnLogin.BackColor = Color.MediumPurple;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(176, 362);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(160, 40);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Purple;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(500, 125);
            label1.TabIndex = 1;
            label1.Text = "ZXCConverter";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Username
            // 
            Username.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            Username.BackColor = Color.WhiteSmoke;
            Username.BorderStyle = BorderStyle.None;
            Username.Location = new Point(114, 195);
            Username.Margin = new Padding(4);
            Username.Name = "Username";
            Username.PlaceholderText = "Username or Email";
            Username.Size = new Size(260, 25);
            Username.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel1.BackColor = Color.Purple;
            panel1.Location = new Point(114, 227);
            panel1.Name = "panel1";
            panel1.Size = new Size(260, 2);
            panel1.TabIndex = 3;
            // 
            // Password
            // 
            Password.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            Password.BackColor = Color.WhiteSmoke;
            Password.BorderStyle = BorderStyle.None;
            Password.Location = new Point(114, 262);
            Password.Name = "Password";
            Password.PlaceholderText = "Password";
            Password.Size = new Size(260, 25);
            Password.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel2.BackColor = Color.Purple;
            panel2.Location = new Point(114, 293);
            panel2.Name = "panel2";
            panel2.Size = new Size(260, 2);
            panel2.TabIndex = 5;
            // 
            // linkRegister
            // 
            linkRegister.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            linkRegister.AutoSize = true;
            linkRegister.Cursor = Cursors.Hand;
            linkRegister.LinkColor = Color.Purple;
            linkRegister.Location = new Point(105, 419);
            linkRegister.Name = "linkRegister";
            linkRegister.Size = new Size(304, 25);
            linkRegister.TabIndex = 6;
            linkRegister.TabStop = true;
            linkRegister.Text = "Нет аккаунта? Зарегистрируйтесь";
            // 
            // pictureBoxClose
            // 
            pictureBoxClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxClose.Cursor = Cursors.Hand;
            pictureBoxClose.Image = (Image)resources.GetObject("pictureBoxClose.Image");
            pictureBoxClose.Location = new Point(455, 12);
            pictureBoxClose.Name = "pictureBoxClose";
            pictureBoxClose.Size = new Size(33, 32);
            pictureBoxClose.TabIndex = 7;
            pictureBoxClose.TabStop = false;
            pictureBoxClose.Click += pictureBoxClose_Click;
            pictureBoxClose.MouseEnter += pictureBoxClose_MouseEnter;
            pictureBoxClose.MouseLeave += pictureBoxClose_MouseLeave;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(500, 653);
            Controls.Add(pictureBoxClose);
            Controls.Add(linkRegister);
            Controls.Add(panel2);
            Controls.Add(Password);
            Controls.Add(panel1);
            Controls.Add(Username);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)pictureBoxClose).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label label1;
        private TextBox Username;
        private Panel panel1;
        private TextBox Password;
        private Panel panel2;
        private LinkLabel linkRegister;
        private PictureBox pictureBoxClose;
    }
}