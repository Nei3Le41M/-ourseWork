using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace СourseWork
{
    public partial class ConverterPage : UserControl
    {
        // Поля (расположены в классе)
        private readonly Dictionary<string, double> rates = new Dictionary<string, double>()
        {
            {"USD", 1.0},
            {"EUR", 0.92},
            {"KZT", 477.50},
            {"RUB", 95.30},
            {"GBP", 0.79}
        };

        private System.Windows.Forms.Timer inputTimer;
        private bool isLeftChanged = false;
        private bool isRightChanged = false;

        public ConverterPage()
        {
            InitializeComponent();

            // Инициализация элементов — убедись, что имена совпадают с дизайнером:
            comboBox1.Items.AddRange(rates.Keys.ToArray());
            comboBox2.Items.AddRange(rates.Keys.ToArray());
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;

            inputTimer = new System.Windows.Forms.Timer();
            inputTimer.Interval = 1000;
            inputTimer.Tick += InputTimer_Tick;

            textBox1.TextChanged += TextBox1_TextChanged;
            textBox2.TextChanged += TextBox2_TextChanged;
            comboBox1.SelectedIndexChanged += ComboBox_Changed;
            comboBox2.SelectedIndexChanged += ComboBox_Changed;

            buttonSwap.Click += buttonSwap_Click;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (isRightChanged) return;

            isLeftChanged = true;
            inputTimer.Stop();
            inputTimer.Start();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (isLeftChanged) return;

            isRightChanged = true;
            inputTimer.Stop();
            inputTimer.Start();
        }

        private void InputTimer_Tick(object sender, EventArgs e)
        {
            inputTimer.Stop();
            if (isLeftChanged)
            {
                ConvertCurrency(forward: true);
                isLeftChanged = false;
            }
            else if (isRightChanged)
            {
                ConvertCurrency(forward: false);
                isRightChanged = false;
            }
        }

        private void ComboBox_Changed(object sender, EventArgs e)
        {
            ConvertCurrency(forward: true);
        }

        private void ConvertCurrency(bool forward)
        {
            try
            {
                string from, to;
                double amount;

                if (forward)
                {
                    from = comboBox1.SelectedItem.ToString();
                    to = comboBox2.SelectedItem.ToString();
                    if (string.IsNullOrWhiteSpace(textBox1.Text)) { textBox2.Text = ""; return; }

                    amount = double.Parse(textBox1.Text);
                    double amountInUSD = amount / rates[from];
                    double result = amountInUSD * rates[to];

                    isRightChanged = true;
                    textBox2.Text = result.ToString("F2");
                    isRightChanged = false;

                    // Сохранение истории
                    SaveHistory(from, to, amount, result);
                }
                else
                {
                    from = comboBox2.SelectedItem.ToString();
                    to = comboBox1.SelectedItem.ToString();
                    if (string.IsNullOrWhiteSpace(textBox2.Text)) { textBox1.Text = ""; return; }

                    amount = double.Parse(textBox2.Text);
                    double amountInUSD = amount / rates[from];
                    double result = amountInUSD * rates[to];

                    isLeftChanged = true;
                    textBox1.Text = result.ToString("F2");
                    isLeftChanged = false;

                    // Сохранение истории
                    SaveHistory(from, to, amount, result);
                }
            }
            catch
            {
                if (forward) textBox2.Text = "";
                else textBox1.Text = "";
            }

            // Сохранение истории
            
        }

        private void SaveHistory(string from, string to, double input, double output)
        {
            string time = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            string line = $"{time}|{from}|{to}|{input:F2}|{output:F2}";
            File.AppendAllText("history.txt", line + Environment.NewLine);
        }


        private void buttonSwap_Click(object sender, EventArgs e)
        {
            int leftIndex = comboBox1.SelectedIndex;
            int rightIndex = comboBox2.SelectedIndex;

            comboBox1.SelectedIndex = rightIndex;
            comboBox2.SelectedIndex = leftIndex;

            string temp = textBox1.Text;
            textBox1.Text = textBox2.Text;
            textBox2.Text = temp;

            ConvertCurrency(forward: true);
        }
    }
}
