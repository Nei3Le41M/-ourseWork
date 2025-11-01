namespace СourseWork
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            btnDynamics = new Button();
            btnCurrency = new Button();
            btnHistory = new Button();
            btnConverter = new Button();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            lblSectionTitle = new Label();
            picSectionIcon = new PictureBox();
            btnReg = new Button();
            profileIcon = new PictureBox();
            btnLogin = new Button();
            profileMenu = new ContextMenuStrip(components);
            profileToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            mainPanel = new Panel();
            panel4 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSectionIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)profileIcon).BeginInit();
            profileMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnDynamics);
            panel1.Controls.Add(btnCurrency);
            panel1.Controls.Add(btnHistory);
            panel1.Controls.Add(btnConverter);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(210, 603);
            panel1.TabIndex = 5;
            // 
            // btnDynamics
            // 
            btnDynamics.Dock = DockStyle.Top;
            btnDynamics.Image = (Image)resources.GetObject("btnDynamics.Image");
            btnDynamics.ImageAlign = ContentAlignment.MiddleLeft;
            btnDynamics.Location = new Point(0, 320);
            btnDynamics.Name = "btnDynamics";
            btnDynamics.Padding = new Padding(10, 0, 20, 0);
            btnDynamics.Size = new Size(210, 65);
            btnDynamics.TabIndex = 4;
            btnDynamics.Text = "Динамика курса";
            btnDynamics.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDynamics.UseVisualStyleBackColor = true;
            btnDynamics.Click += btnDynamics_Click;
            // 
            // btnCurrency
            // 
            btnCurrency.Dock = DockStyle.Top;
            btnCurrency.Image = (Image)resources.GetObject("btnCurrency.Image");
            btnCurrency.ImageAlign = ContentAlignment.MiddleLeft;
            btnCurrency.Location = new Point(0, 255);
            btnCurrency.Name = "btnCurrency";
            btnCurrency.Padding = new Padding(10, 0, 20, 0);
            btnCurrency.Size = new Size(210, 65);
            btnCurrency.TabIndex = 3;
            btnCurrency.Text = "Валюты";
            btnCurrency.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCurrency.UseVisualStyleBackColor = true;
            btnCurrency.Click += btnCurrency_Click;
            // 
            // btnHistory
            // 
            btnHistory.Dock = DockStyle.Top;
            btnHistory.Image = (Image)resources.GetObject("btnHistory.Image");
            btnHistory.ImageAlign = ContentAlignment.MiddleLeft;
            btnHistory.Location = new Point(0, 190);
            btnHistory.Name = "btnHistory";
            btnHistory.Padding = new Padding(10, 0, 20, 0);
            btnHistory.Size = new Size(210, 65);
            btnHistory.TabIndex = 2;
            btnHistory.Text = "История ";
            btnHistory.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnHistory_Click;
            // 
            // btnConverter
            // 
            btnConverter.Dock = DockStyle.Top;
            btnConverter.Image = (Image)resources.GetObject("btnConverter.Image");
            btnConverter.ImageAlign = ContentAlignment.MiddleLeft;
            btnConverter.Location = new Point(0, 125);
            btnConverter.Name = "btnConverter";
            btnConverter.Padding = new Padding(10, 0, 20, 0);
            btnConverter.Size = new Size(210, 65);
            btnConverter.TabIndex = 1;
            btnConverter.Text = "Конвертер";
            btnConverter.TextAlign = ContentAlignment.MiddleLeft;
            btnConverter.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnConverter.UseVisualStyleBackColor = true;
            btnConverter.Click += btnConverter_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(210, 125);
            panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, -30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(210, 214);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(243, 247, 255);
            panel3.Controls.Add(lblSectionTitle);
            panel3.Controls.Add(picSectionIcon);
            panel3.Controls.Add(btnReg);
            panel3.Controls.Add(profileIcon);
            panel3.Controls.Add(btnLogin);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(210, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(872, 60);
            panel3.TabIndex = 6;
            // 
            // lblSectionTitle
            // 
            lblSectionTitle.AutoSize = true;
            lblSectionTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblSectionTitle.Location = new Point(44, 16);
            lblSectionTitle.Name = "lblSectionTitle";
            lblSectionTitle.Size = new Size(0, 28);
            lblSectionTitle.TabIndex = 5;
            // 
            // picSectionIcon
            // 
            picSectionIcon.Location = new Point(6, 12);
            picSectionIcon.Name = "picSectionIcon";
            picSectionIcon.Size = new Size(32, 32);
            picSectionIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picSectionIcon.TabIndex = 4;
            picSectionIcon.TabStop = false;
            // 
            // btnReg
            // 
            btnReg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReg.BackColor = Color.FromArgb(122, 86, 255);
            btnReg.Cursor = Cursors.Hand;
            btnReg.ForeColor = Color.White;
            btnReg.Location = new Point(749, 12);
            btnReg.Name = "btnReg";
            btnReg.Size = new Size(111, 29);
            btnReg.TabIndex = 3;
            btnReg.Text = "Registration";
            btnReg.UseVisualStyleBackColor = false;
            btnReg.Click += btnReg_Click;
            // 
            // profileIcon
            // 
            profileIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            profileIcon.Cursor = Cursors.Hand;
            profileIcon.Image = Properties.Resources.default_avatar;
            profileIcon.Location = new Point(800, 12);
            profileIcon.Name = "profileIcon";
            profileIcon.Size = new Size(40, 40);
            profileIcon.SizeMode = PictureBoxSizeMode.Zoom;
            profileIcon.TabIndex = 2;
            profileIcon.TabStop = false;
            profileIcon.Visible = false;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.ForeColor = Color.MediumPurple;
            btnLogin.Location = new Point(649, 12);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // profileMenu
            // 
            profileMenu.BackColor = Color.White;
            profileMenu.ImageScalingSize = new Size(20, 20);
            profileMenu.Items.AddRange(new ToolStripItem[] { profileToolStripMenuItem, logoutToolStripMenuItem });
            profileMenu.Name = "contextMenuStrip1";
            profileMenu.Size = new Size(126, 52);
            // 
            // profileToolStripMenuItem
            // 
            profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            profileToolStripMenuItem.Size = new Size(125, 24);
            profileToolStripMenuItem.Text = "Profile";
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(125, 24);
            logoutToolStripMenuItem.Text = "Logout";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(122, 86, 255);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(210, 60);
            panel4.Name = "panel4";
            panel4.Size = new Size(872, 1);
            panel4.TabIndex = 16;
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(210, 61);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(872, 542);
            mainPanel.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 247, 255);
            ClientSize = new Size(1082, 603);
            Controls.Add(mainPanel);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSectionIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)profileIcon).EndInit();
            profileMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button btnConverter;
        private Panel panel2;
        private Button btnDynamics;
        private Button btnCurrency;
        private Button btnHistory;
        private Panel panel3;
        private Button btnLogin;
        private PictureBox profileIcon;
        private Button btnReg;
        private ContextMenuStrip profileMenu;
        private ToolStripMenuItem profileToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private PictureBox pictureBox1;
        private Panel mainPanel;
        private PictureBox picSectionIcon;
        private Label lblSectionTitle;
        private Panel panel4;
    }
}
