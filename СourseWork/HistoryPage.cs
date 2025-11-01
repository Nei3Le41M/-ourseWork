using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace СourseWork
{
    public partial class HistoryPage : UserControl
    {
        private DataGridView historyGrid;
        private Button btnClear;

        public HistoryPage()
        {
            InitializeComponent();
            InitializeHistoryUI();
            LoadHistory();
        }

        private void InitializeHistoryUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = System.Drawing.Color.White;

            historyGrid = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 350,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = System.Drawing.Color.White,
                ForeColor = System.Drawing.Color.Black,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = System.Drawing.Color.FromArgb(122, 86, 255),
                    ForeColor = System.Drawing.Color.White,
                    Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = System.Drawing.Color.White,
                    ForeColor = System.Drawing.Color.Black,
                    SelectionBackColor = System.Drawing.Color.FromArgb(122, 86, 255)
                },
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = System.Drawing.Color.FromArgb(243, 247, 255),
                    ForeColor = System.Drawing.Color.Black
                }
            };

            historyGrid.Columns.Add("Time", "Время");
            historyGrid.Columns.Add("From", "Из");
            historyGrid.Columns.Add("To", "В");
            historyGrid.Columns.Add("Input", "Сумма");
            historyGrid.Columns.Add("Output", "Результат");

            btnClear = new Button
            {
                Text = "Сбросить историю",
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = System.Drawing.Color.FromArgb(122, 86, 255),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Click += BtnClear_Click;

            this.Controls.Add(historyGrid);
            this.Controls.Add(btnClear);
        }

        private void LoadHistory()
        {
            historyGrid.Rows.Clear();

            if (!File.Exists("history.txt"))
                return;

            var lines = File.ReadAllLines("history.txt");
            foreach (var line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 5)
                {
                    historyGrid.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4]);
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (File.Exists("history.txt"))
                File.WriteAllText("history.txt", string.Empty);

            historyGrid.Rows.Clear();
        }
    }
}
