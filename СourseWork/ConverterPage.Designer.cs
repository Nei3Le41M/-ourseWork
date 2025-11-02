namespace СourseWork
{
    partial class ConverterPage
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConverterPage));
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            lblLeftTitle = new Label();
            lblRightTitle = new Label();
            lblLeftRate = new Label();
            lblRightRate = new Label();
            panelQuickLeft = new Panel();
            btnL_KZT = new Button();
            btnL_USD = new Button();
            btnL_EUR = new Button();
            btnL_RUB = new Button();
            panelQuickRight = new Panel();
            btnR_KZT = new Button();
            btnR_USD = new Button();
            btnR_EUR = new Button();
            btnR_RUB = new Button();
            buttonSwap = new PictureBox();
            panelQuickLeft.SuspendLayout();
            panelQuickRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)buttonSwap).BeginInit();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 28F);
            textBox2.Location = new Point(504, 153);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(300, 110);
            textBox2.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 28F);
            textBox1.Location = new Point(68, 155);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(300, 110);
            textBox1.TabIndex = 7;
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Segoe UI", 11F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(236, 1);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(60, 33);
            comboBox2.TabIndex = 6;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 11F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(236, 1);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(60, 33);
            comboBox1.TabIndex = 5;
            // 
            // lblLeftTitle
            // 
            lblLeftTitle.AutoSize = true;
            lblLeftTitle.Font = new Font("Segoe UI", 11F);
            lblLeftTitle.Location = new Point(68, 53);
            lblLeftTitle.Name = "lblLeftTitle";
            lblLeftTitle.Size = new Size(114, 25);
            lblLeftTitle.TabIndex = 10;
            lblLeftTitle.Text = "У меня есть";
            // 
            // lblRightTitle
            // 
            lblRightTitle.AutoSize = true;
            lblRightTitle.Font = new Font("Segoe UI", 11F);
            lblRightTitle.Location = new Point(504, 53);
            lblRightTitle.Name = "lblRightTitle";
            lblRightTitle.Size = new Size(163, 25);
            lblRightTitle.TabIndex = 11;
            lblRightTitle.Text = "Хочу приобрести";
            lblRightTitle.Click += lblRightTitle_Click;
            // 
            // lblLeftRate
            // 
            lblLeftRate.AutoSize = true;
            lblLeftRate.Font = new Font("Segoe UI", 9F);
            lblLeftRate.ForeColor = SystemColors.GrayText;
            lblLeftRate.Location = new Point(78, 223);
            lblLeftRate.Name = "lblLeftRate";
            lblLeftRate.Size = new Size(141, 20);
            lblLeftRate.TabIndex = 12;
            lblLeftRate.Text = "1 USD = 530.07 KZT";
            // 
            // lblRightRate
            // 
            lblRightRate.AutoSize = true;
            lblRightRate.Font = new Font("Segoe UI", 9F);
            lblRightRate.ForeColor = SystemColors.GrayText;
            lblRightRate.Location = new Point(514, 223);
            lblRightRate.Name = "lblRightRate";
            lblRightRate.Size = new Size(141, 20);
            lblRightRate.TabIndex = 13;
            lblRightRate.Text = "1 KZT = 0.0019 USD";
            // 
            // panelQuickLeft
            // 
            panelQuickLeft.Controls.Add(btnL_KZT);
            panelQuickLeft.Controls.Add(btnL_USD);
            panelQuickLeft.Controls.Add(btnL_EUR);
            panelQuickLeft.Controls.Add(btnL_RUB);
            panelQuickLeft.Controls.Add(comboBox1);
            panelQuickLeft.Location = new Point(68, 100);
            panelQuickLeft.Name = "panelQuickLeft";
            panelQuickLeft.Size = new Size(300, 35);
            panelQuickLeft.TabIndex = 14;
            // 
            // btnL_KZT
            // 
            btnL_KZT.FlatStyle = FlatStyle.Flat;
            btnL_KZT.Location = new Point(0, 0);
            btnL_KZT.Name = "btnL_KZT";
            btnL_KZT.Size = new Size(60, 35);
            btnL_KZT.TabIndex = 0;
            btnL_KZT.Text = "KZT";
            btnL_KZT.UseVisualStyleBackColor = true;
            // 
            // btnL_USD
            // 
            btnL_USD.FlatStyle = FlatStyle.Flat;
            btnL_USD.Location = new Point(59, 0);
            btnL_USD.Name = "btnL_USD";
            btnL_USD.Size = new Size(60, 35);
            btnL_USD.TabIndex = 1;
            btnL_USD.Text = "USD";
            btnL_USD.UseVisualStyleBackColor = true;
            // 
            // btnL_EUR
            // 
            btnL_EUR.FlatStyle = FlatStyle.Flat;
            btnL_EUR.Location = new Point(118, 0);
            btnL_EUR.Name = "btnL_EUR";
            btnL_EUR.Size = new Size(60, 35);
            btnL_EUR.TabIndex = 2;
            btnL_EUR.Text = "EUR";
            btnL_EUR.UseVisualStyleBackColor = true;
            // 
            // btnL_RUB
            // 
            btnL_RUB.FlatStyle = FlatStyle.Flat;
            btnL_RUB.Location = new Point(177, 0);
            btnL_RUB.Name = "btnL_RUB";
            btnL_RUB.Size = new Size(60, 35);
            btnL_RUB.TabIndex = 3;
            btnL_RUB.Text = "RUB";
            btnL_RUB.UseVisualStyleBackColor = true;
            // 
            // panelQuickRight
            // 
            panelQuickRight.Controls.Add(btnR_KZT);
            panelQuickRight.Controls.Add(btnR_USD);
            panelQuickRight.Controls.Add(btnR_EUR);
            panelQuickRight.Controls.Add(btnR_RUB);
            panelQuickRight.Controls.Add(comboBox2);
            panelQuickRight.Location = new Point(504, 100);
            panelQuickRight.Name = "panelQuickRight";
            panelQuickRight.Size = new Size(300, 35);
            panelQuickRight.TabIndex = 15;
            // 
            // btnR_KZT
            // 
            btnR_KZT.FlatStyle = FlatStyle.Flat;
            btnR_KZT.Location = new Point(0, 0);
            btnR_KZT.Name = "btnR_KZT";
            btnR_KZT.Size = new Size(60, 35);
            btnR_KZT.TabIndex = 0;
            btnR_KZT.Text = "KZT";
            btnR_KZT.UseVisualStyleBackColor = true;
            // 
            // btnR_USD
            // 
            btnR_USD.FlatStyle = FlatStyle.Flat;
            btnR_USD.Location = new Point(59, 0);
            btnR_USD.Name = "btnR_USD";
            btnR_USD.Size = new Size(60, 35);
            btnR_USD.TabIndex = 1;
            btnR_USD.Text = "USD";
            btnR_USD.UseVisualStyleBackColor = true;
            // 
            // btnR_EUR
            // 
            btnR_EUR.FlatStyle = FlatStyle.Flat;
            btnR_EUR.Location = new Point(118, 0);
            btnR_EUR.Name = "btnR_EUR";
            btnR_EUR.Size = new Size(60, 35);
            btnR_EUR.TabIndex = 2;
            btnR_EUR.Text = "EUR";
            btnR_EUR.UseVisualStyleBackColor = true;
            // 
            // btnR_RUB
            // 
            btnR_RUB.FlatStyle = FlatStyle.Flat;
            btnR_RUB.Location = new Point(177, 0);
            btnR_RUB.Name = "btnR_RUB";
            btnR_RUB.Size = new Size(60, 35);
            btnR_RUB.TabIndex = 3;
            btnR_RUB.Text = "RUB";
            btnR_RUB.UseVisualStyleBackColor = true;
            // 
            // buttonSwap
            // 
            buttonSwap.BackgroundImageLayout = ImageLayout.Zoom;
            buttonSwap.Image = (Image)resources.GetObject("buttonSwap.Image");
            buttonSwap.Location = new Point(400, 155);
            buttonSwap.Name = "buttonSwap";
            buttonSwap.Size = new Size(68, 62);
            buttonSwap.TabIndex = 16;
            buttonSwap.TabStop = false;
            // 
            // ConverterPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonSwap);
            Controls.Add(panelQuickRight);
            Controls.Add(panelQuickLeft);
            Controls.Add(lblRightRate);
            Controls.Add(lblLeftRate);
            Controls.Add(lblRightTitle);
            Controls.Add(lblLeftTitle);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "ConverterPage";
            Size = new Size(872, 545);
            panelQuickLeft.ResumeLayout(false);
            panelQuickRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)buttonSwap).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox2;
        private TextBox textBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Label lblLeftTitle;
        private Label lblRightTitle;
        private Label lblLeftRate;
        private Label lblRightRate;
        private Panel panelQuickLeft;
        private Button btnL_KZT;
        private Button btnL_USD;
        private Button btnL_EUR;
        private Button btnL_RUB;
        private Panel panelQuickRight;
        private Button btnR_KZT;
        private Button btnR_USD;
        private Button btnR_EUR;
        private Button btnR_RUB;
        private PictureBox buttonSwap;
    }
}
