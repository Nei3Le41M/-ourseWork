namespace СourseWork
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            lblTitle = new Label();
            User = new TextBox();
            Email = new TextBox();
            PasswordReg = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            btnRegister = new Button();
            pictureBoxCloseReg = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCloseReg).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.ForeColor = Color.Purple;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(500, 80);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create Account";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // User
            // 
            User.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            User.BackColor = Color.WhiteSmoke;
            User.BorderStyle = BorderStyle.None;
            User.Location = new Point(124, 155);
            User.Name = "User";
            User.PlaceholderText = "Username";
            User.Size = new Size(260, 20);
            User.TabIndex = 1;
            // 
            // Email
            // 
            Email.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            Email.BackColor = Color.WhiteSmoke;
            Email.BorderStyle = BorderStyle.None;
            Email.Location = new Point(124, 221);
            Email.Name = "Email";
            Email.PlaceholderText = "Email";
            Email.Size = new Size(260, 20);
            Email.TabIndex = 2;
            // 
            // PasswordReg
            // 
            PasswordReg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            PasswordReg.BackColor = Color.WhiteSmoke;
            PasswordReg.BorderStyle = BorderStyle.None;
            PasswordReg.Location = new Point(124, 287);
            PasswordReg.Name = "PasswordReg";
            PasswordReg.PlaceholderText = "Password";
            PasswordReg.Size = new Size(260, 20);
            PasswordReg.TabIndex = 3;
            PasswordReg.UseSystemPasswordChar = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel1.BackColor = Color.Purple;
            panel1.Location = new Point(124, 181);
            panel1.Name = "panel1";
            panel1.Size = new Size(260, 2);
            panel1.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel2.BackColor = Color.Purple;
            panel2.Location = new Point(124, 247);
            panel2.Name = "panel2";
            panel2.Size = new Size(260, 2);
            panel2.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel3.BackColor = Color.Purple;
            panel3.Location = new Point(124, 320);
            panel3.Name = "panel3";
            panel3.Size = new Size(260, 2);
            panel3.TabIndex = 5;
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnRegister.BackColor = Color.MediumPurple;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(168, 374);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(160, 40);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // pictureBoxCloseReg
            // 
            pictureBoxCloseReg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxCloseReg.Cursor = Cursors.Hand;
            pictureBoxCloseReg.Image = (Image)resources.GetObject("pictureBoxCloseReg.Image");
            pictureBoxCloseReg.Location = new Point(455, 12);
            pictureBoxCloseReg.Name = "pictureBoxCloseReg";
            pictureBoxCloseReg.Size = new Size(33, 32);
            pictureBoxCloseReg.TabIndex = 8;
            pictureBoxCloseReg.TabStop = false;
            pictureBoxCloseReg.Click += pictureBoxCloseReg_Click;
            pictureBoxCloseReg.MouseEnter += pictureBoxCloseReg_MouseEnter;
            pictureBoxCloseReg.MouseLeave += pictureBoxCloseReg_MouseLeave;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(500, 653);
            Controls.Add(pictureBoxCloseReg);
            Controls.Add(btnRegister);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(PasswordReg);
            Controls.Add(Email);
            Controls.Add(User);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterForm";
            Load += RegisterForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCloseReg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox User;
        private TextBox Email;
        private TextBox PasswordReg;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button btnRegister;
        private PictureBox pictureBoxCloseReg;
    }
}