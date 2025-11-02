using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace СourseWork
{
    public partial class CurrencyPage : UserControl
    {
        private Label labelTitle;
        private Label labelSubtitle;
        private TextBox txtSearch;
        private DataGridView dataGridViewRates;

        // Наименования валют
        private readonly Dictionary<string, string> currencyNames = new Dictionary<string, string>()
        {
            { "USD", "Доллар США" },
            { "EUR", "Евро" },
            { "RUB", "Российский рубль" },
            { "GBP", "Фунт стерлингов" },
            { "CNY", "Китайский юань" },
            { "JPY", "Японская иена" },
            { "KGS", "Киргизский сом" },
            { "UZS", "Узбекский сум" },
            { "TRY", "Турецкая лира" },
            { "CHF", "Швейцарский франк" },
            { "CAD", "Канадский доллар" },
            { "AUD", "Австралийский доллар" },
            { "AED", "Дирхам ОАЭ" },
            { "SEK", "Шведская крона" },
            { "PLN", "Польский злотый" },
            { "AZN", "Азербайджанский манат" },
            { "AMD", "Армянский драм" },
            { "BYN", "Белорусский рубль" },
            { "BRL", "Бразильский реал" },
            { "HUF", "Венгерский форинт" },
            { "HKD", "Гонконгский доллар" },
            { "GEL", "Грузинский лари" },
            { "DKK", "Датская крона" },
            { "INR", "Индийская рупия" },
            { "KRW", "Южнокорейская вона" },
            { "KWD", "Кувейтский динар" },
            { "KZT", "Казахстанский тенге" },
            { "MYR", "Малайзийский ринггит" },
            { "MDL", "Молдавский лей" },
            { "NZD", "Новозеландский доллар" },
            { "NOK", "Норвежская крона" },
            { "SGD", "Сингапурский доллар" },
            { "TJS", "Таджикский сомони" },
            { "THB", "Тайский бат" },
            { "TMT", "Туркменский манат" },
            { "UAH", "Украинская гривна" },
            { "CZK", "Чешская крона" },
            { "ZAR", "Южноафриканский рэнд" },
            { "MXN", "Мексиканское песо" },
            { "IRR", "Иранский риал " },
            { "SAR", "Саудовский риял " },
            { "XDR", "Специальные права заимствования " },
        };

        public CurrencyPage()
        {
            InitializeComponent();
            InitializeCurrencyUI();
            _ = LoadRatesFromNB();
        }

        private void InitializeCurrencyUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            labelTitle = new Label
            {
                Text = "Курсы валют",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(30, 20)
            };
            this.Controls.Add(labelTitle);

            labelSubtitle = new Label
            {
                Text = "Нацбанк — официальный курс национальной валюты. Обновляется один раз в день.",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.DimGray,
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(30, 70)
            };
            this.Controls.Add(labelSubtitle);

            txtSearch = new TextBox
            {
                PlaceholderText = "Поиск по коду и стране",
                Font = new Font("Segoe UI", 11),
                Width = 350,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(30, 110)
            };
            txtSearch.TextChanged += TxtSearch_TextChanged;
            this.Controls.Add(txtSearch);

            dataGridViewRates = new DataGridView
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(30, 160),
                Size = new Size(900, 450),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dataGridViewRates.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewRates.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(122, 86, 255);
            dataGridViewRates.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewRates.EnableHeadersVisualStyles = false;

            dataGridViewRates.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewRates.DefaultCellStyle.BackColor = Color.White;
            dataGridViewRates.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewRates.DefaultCellStyle.SelectionBackColor = Color.FromArgb(122, 86, 255);
            dataGridViewRates.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(243, 247, 255);

            dataGridViewRates.Columns.Add("Currency", "Валюта");
            dataGridViewRates.Columns.Add("Code", "Код");
            dataGridViewRates.Columns.Add("Price", "Цена (KZT)");
            dataGridViewRates.Columns.Add("Change", "Изменение");
            dataGridViewRates.Columns.Add("UpdateTime", "Обновление");

            this.Controls.Add(dataGridViewRates);
        }

        private async Task LoadRatesFromNB()
        {
            try
            {
                string response = await FetchRatesWithFallback();

                var xml = XDocument.Parse(response);
                dataGridViewRates.Rows.Clear();

                foreach (var item in xml.Descendants("item"))
                {
                    string code = item.Element("title")?.Value ?? "";
                    string rate = item.Element("description")?.Value ?? "";
                    string change = item.Element("change")?.Value ?? "";
                    string direction = item.Element("index")?.Value ?? "";
                    string date = DateTime.Now.ToString("dd.MM.yyyy HH:mm");

                    string name = currencyNames.ContainsKey(code) ? currencyNames[code] : code;
                    string fullCode = $"{code}/KZT";

                    if (direction == "UP") change = "+" + change;

                    dataGridViewRates.Rows.Add(name, fullCode, rate, change, date);
                }
                // кэшируем последнюю удачную загрузку
                System.IO.File.WriteAllText("rates_cache.xml", response);
            }
            catch (Exception ex)
            {
                // Пытаемся прочитать из локального кэша при сетевых проблемах
                try
                {
                    if (System.IO.File.Exists("rates_cache.xml"))
                    {
                        string cached = System.IO.File.ReadAllText("rates_cache.xml");
                        var xml = XDocument.Parse(cached);
                        dataGridViewRates.Rows.Clear();

                        foreach (var item in xml.Descendants("item"))
                        {
                            string code = item.Element("title")?.Value ?? "";
                            string rate = item.Element("description")?.Value ?? "";
                            string change = item.Element("change")?.Value ?? "";
                            string direction = item.Element("index")?.Value ?? "";
                            string date = "(офлайн кэш)";

                            string name = currencyNames.ContainsKey(code) ? currencyNames[code] : code;
                            string fullCode = $"{code}/KZT";

                            if (direction == "UP") change = "+" + change;

                            dataGridViewRates.Rows.Add(name, fullCode, rate, change, date);
                        }

                        MessageBox.Show("Не удалось обновить данные из сети, показан кэш.\nПричина: " + ex.Message,
                            "Режим офлайн", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch { /* игнорируем ошибки парсинга кэша */ }

                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
            }
        }

        private async Task<string> FetchRatesWithFallback()
        {
            var urls = new string[]
            {
                "https://nationalbank.kz/rss/rates_all.xml",
                "https://www.nationalbank.kz/rss/rates_all.xml",
                "http://nationalbank.kz/rss/rates_all.xml"
            };

            using HttpClient client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(8)
            };
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (WinForms App)");

            Exception lastEx = null;
            foreach (var url in urls)
            {
                try
                {
                    return await client.GetStringAsync(url);
                }
                catch (Exception ex)
                {
                    lastEx = ex;
                    continue;
                }
            }
            throw lastEx ?? new Exception("Неизвестная ошибка сети");
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.ToLower();

            foreach (DataGridViewRow row in dataGridViewRates.Rows)
            {
                if (row.IsNewRow) continue;
                bool visible = row.Cells["Currency"].Value.ToString().ToLower().Contains(filter)
                            || row.Cells["Code"].Value.ToString().ToLower().Contains(filter);
                row.Visible = visible;
            }
        }
    }
}
