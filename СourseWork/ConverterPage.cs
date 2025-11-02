using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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

            // Устанавливаем Dock для растягивания на весь экран
            this.Dock = DockStyle.Fill;

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

            // Настраиваем PictureBox для обмена валют
            buttonSwap.Cursor = Cursors.Hand;
            buttonSwap.Click += buttonSwap_Click;

            // Быстрые кнопки слева
            btnL_KZT.Click += (_, __) => SelectQuick(comboBox1, "KZT");
            btnL_USD.Click += (_, __) => SelectQuick(comboBox1, "USD");
            btnL_EUR.Click += (_, __) => SelectQuick(comboBox1, "EUR");
            btnL_RUB.Click += (_, __) => SelectQuick(comboBox1, "RUB");
            // Быстрые кнопки справа
            btnR_KZT.Click += (_, __) => SelectQuick(comboBox2, "KZT");
            btnR_USD.Click += (_, __) => SelectQuick(comboBox2, "USD");
            btnR_EUR.Click += (_, __) => SelectQuick(comboBox2, "EUR");
            btnR_RUB.Click += (_, __) => SelectQuick(comboBox2, "RUB");

            UpdateRateLabels();
            HighlightQuickButtons();

            // Обработчик для адаптации элементов при изменении размера
            this.Resize += ConverterPage_Resize;

            // Вызываем один раз для начальной настройки позиций после полной загрузки
            this.HandleCreated += (s, e) =>
            {
                this.BeginInvoke(new Action(() => ConverterPage_Resize(this, EventArgs.Empty)));
            };
        }

        private void ConverterPage_Resize(object sender, EventArgs e)
        {
            const int breakpointWidth = 800; // Ширина для переключения макета

            if (this.Width >= breakpointWidth)
            {
                // Горизонтальный макет (side-by-side)
                LayoutHorizontal();
            }
            else
            {
                // Вертикальный макет (stacked)
                LayoutVertical();
            }
        }

        private void LayoutHorizontal()
        {
            // Минимальная ширина для горизонтального макета
            if (this.Width < 700) return;

            // Центрируем элементы конвертера по горизонтали
            int centerX = this.Width / 2;
            int spacing = 50; // Расстояние между элементами
            int elementWidth = 300; // Ширина каждого блока
            int swapWidth = buttonSwap != null ? buttonSwap.Width : 68; // Ширина swap иконки

            // Рассчитываем позиции с учетом swap иконки
            int totalWidth = elementWidth * 2 + swapWidth + spacing * 2;
            int startX = centerX - totalWidth / 2;

            // Левый блок
            int leftX = Math.Max(startX, 20);

            // Swap иконка между блоками
            int swapX = leftX + elementWidth + spacing;

            // Правый блок
            int rightX = swapX + swapWidth + spacing;

            // Проверяем, помещается ли все в окно
            if (rightX + elementWidth > this.Width - 20)
            {
                // Пересчитываем, если не помещается
                int maxRightX = this.Width - elementWidth - 20;
                rightX = maxRightX;
                swapX = rightX - spacing - swapWidth;
                leftX = swapX - spacing - elementWidth;
                if (leftX < 20) leftX = 20;
            }

            // Адаптивная вертикальная позиция и высота на основе высоты окна
            int baseHeight = 600; // Базовая высота окна для расчетов
            double heightRatio = Math.Max(0.5, Math.Min(2.0, (double)this.Height / baseHeight)); // Ограничиваем от 0.5 до 2.0

            // Высота текстовых полей адаптируется к высоте окна
            int baseTextBoxHeight = 110;
            int minTextBoxHeight = 60;
            int maxTextBoxHeight = 200;
            int textBoxHeight = Math.Max(minTextBoxHeight, Math.Min(maxTextBoxHeight, (int)(baseTextBoxHeight * heightRatio)));

            // Вертикальные позиции адаптируются к высоте окна
            int baseTopOffset = 150; // Базовая позиция сверху
            int titleTop = Math.Max(80, (int)(baseTopOffset * heightRatio)); // Минимум 80px от верха
            int panelTop = titleTop + 50;
            int textBoxTop = panelTop + 50;
            int rateTop = textBoxTop + textBoxHeight + 10;

            // Обновляем позиции элементов слева
            if (lblLeftTitle != null && !lblLeftTitle.IsDisposed)
            {
                lblLeftTitle.Left = leftX;
                lblLeftTitle.Top = titleTop;
            }
            if (panelQuickLeft != null && !panelQuickLeft.IsDisposed)
            {
                panelQuickLeft.Left = leftX;
                panelQuickLeft.Top = panelTop;
            }
            if (textBox1 != null && !textBox1.IsDisposed)
            {
                textBox1.Left = leftX;
                textBox1.Top = textBoxTop;
                textBox1.Width = elementWidth;
                textBox1.Height = textBoxHeight;
            }
            if (lblLeftRate != null && !lblLeftRate.IsDisposed)
            {
                lblLeftRate.Left = leftX + 10;
                lblLeftRate.Top = rateTop;
            }

            // Обновляем позиции элементов справа
            if (lblRightTitle != null && !lblRightTitle.IsDisposed)
            {
                lblRightTitle.Left = rightX;
                lblRightTitle.Top = titleTop;
            }
            if (panelQuickRight != null && !panelQuickRight.IsDisposed)
            {
                panelQuickRight.Left = rightX;
                panelQuickRight.Top = panelTop;
            }
            if (textBox2 != null && !textBox2.IsDisposed)
            {
                textBox2.Left = rightX;
                textBox2.Top = textBoxTop; // Та же позиция, что и textBox1
                textBox2.Width = elementWidth;
                textBox2.Height = textBoxHeight; // Та же высота, что и textBox1
            }
            if (lblRightRate != null && !lblRightRate.IsDisposed)
            {
                lblRightRate.Left = rightX + 10;
                lblRightRate.Top = rateTop;
            }

            // Центрируем кнопку swap точно между двумя текстовыми полями
            if (buttonSwap != null && !buttonSwap.IsDisposed)
            {
                // По горизонтали - точно между полями
                buttonSwap.Left = swapX;

                // По вертикали - точно по центру текстовых полей
                int textBoxCenterY = textBoxTop + textBoxHeight / 2;
                buttonSwap.Top = textBoxCenterY - buttonSwap.Height / 2;
            }
        }

        private void LayoutVertical()
        {
            // Вертикальный макет - элементы расположены один над другим
            int elementWidth = Math.Min(300, this.Width - 100); // Ширина блока с отступами
            int centerX = this.Width / 2;
            int leftX = centerX - elementWidth / 2;

            // Адаптивная высота элементов на основе высоты окна
            int baseHeight = 600; // Базовая высота окна для расчетов
            double heightRatio = Math.Max(0.5, Math.Min(2.0, (double)this.Height / baseHeight)); // Ограничиваем от 0.5 до 2.0

            // Высота текстовых полей адаптируется
            int baseTextBoxHeight = 110;
            int minTextBoxHeight = 50;
            int maxTextBoxHeight = 180;
            int textBoxHeight = Math.Max(minTextBoxHeight, Math.Min(maxTextBoxHeight, (int)(baseTextBoxHeight * heightRatio)));

            int spacing = 30; // Расстояние между верхней и нижней панелью

            // Верхняя панель (У меня есть) - позиции адаптируются
            int baseTopPanelTop = 80;
            int topPanelTop = (int)(baseTopPanelTop * heightRatio);
            int topTitleTop = topPanelTop;
            int topPanelButtonsTop = topPanelTop + 40;
            int topTextBoxTop = topPanelButtonsTop + 50;
            int topRateTop = topTextBoxTop + textBoxHeight + 10;

            // Обновляем позиции элементов верхней панели
            if (lblLeftTitle != null && !lblLeftTitle.IsDisposed)
            {
                lblLeftTitle.Left = leftX;
                lblLeftTitle.Top = topTitleTop;
            }
            if (panelQuickLeft != null && !panelQuickLeft.IsDisposed)
            {
                panelQuickLeft.Left = leftX;
                panelQuickLeft.Top = topPanelButtonsTop;
                panelQuickLeft.Width = elementWidth;
            }
            if (textBox1 != null && !textBox1.IsDisposed)
            {
                textBox1.Left = leftX;
                textBox1.Top = topTextBoxTop;
                textBox1.Width = elementWidth;
                textBox1.Height = textBoxHeight;
            }
            if (lblLeftRate != null && !lblLeftRate.IsDisposed)
            {
                lblLeftRate.Left = leftX + 10;
                lblLeftRate.Top = topRateTop;
            }

            // Нижняя панель (Хочу приобрести)
            // Проверяем, помещается ли нижняя панель в окно
            int bottomPanelTop = topRateTop + 40 + spacing;
            int bottomTitleTop = bottomPanelTop;
            int bottomPanelButtonsTop = bottomPanelTop + 40;
            int bottomTextBoxTop = bottomPanelButtonsTop + 50;
            int bottomRateTop = bottomTextBoxTop + textBoxHeight + 10;

            // Если нижняя панель не помещается, уменьшаем отступы и высоты
            if (bottomRateTop > this.Height - 20)
            {
                // Уменьшаем spacing и высоты пропорционально
                int overflow = bottomRateTop - (this.Height - 20);
                spacing = Math.Max(10, spacing - overflow / 2);
                if (textBoxHeight > minTextBoxHeight)
                {
                    textBoxHeight = Math.Max(minTextBoxHeight, textBoxHeight - overflow / 2);
                    // Пересчитываем позиции с новыми значениями
                    topRateTop = topTextBoxTop + textBoxHeight + 10;
                    bottomPanelTop = topRateTop + 40 + spacing;
                    bottomTitleTop = bottomPanelTop;
                    bottomPanelButtonsTop = bottomPanelTop + 40;
                    bottomTextBoxTop = bottomPanelButtonsTop + 50;
                    bottomRateTop = bottomTextBoxTop + textBoxHeight + 10;
                }
            }

            // Обновляем позиции элементов нижней панели
            if (lblRightTitle != null && !lblRightTitle.IsDisposed)
            {
                lblRightTitle.Left = leftX;
                lblRightTitle.Top = bottomTitleTop;
            }
            if (panelQuickRight != null && !panelQuickRight.IsDisposed)
            {
                panelQuickRight.Left = leftX;
                panelQuickRight.Top = bottomPanelButtonsTop;
                panelQuickRight.Width = elementWidth;
            }
            if (textBox2 != null && !textBox2.IsDisposed)
            {
                textBox2.Left = leftX;
                textBox2.Top = bottomTextBoxTop;
                textBox2.Width = elementWidth;
                textBox2.Height = textBoxHeight;
            }
            if (lblRightRate != null && !lblRightRate.IsDisposed)
            {
                lblRightRate.Left = leftX + 10;
                lblRightRate.Top = bottomRateTop;
            }

            // Кнопка swap справа по центру между панелями
            if (buttonSwap != null && !buttonSwap.IsDisposed)
            {
                // По горизонтали - справа с отступом
                buttonSwap.Left = this.Width - buttonSwap.Width - 30;

                // По вертикали - между двумя панелями
                int swapCenterY = (topRateTop + bottomTitleTop) / 2;
                buttonSwap.Top = swapCenterY - buttonSwap.Height / 2;
            }
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
            UpdateRateLabels();
            HighlightQuickButtons();
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

            UpdateRateLabels();
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
            UpdateRateLabels();
            HighlightQuickButtons();
        }

        private void UpdateRateLabels()
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null) return;
            string left = comboBox1.SelectedItem.ToString();
            string right = comboBox2.SelectedItem.ToString();

            double rateLeftToRight = rates[right] / rates[left];
            double rateRightToLeft = rates[left] / rates[right];

            lblLeftRate.Text = $"1 {right} = {rateRightToLeft:F4} {left}";
            lblRightRate.Text = $"1 {left} = {rateLeftToRight:F4} {right}";
        }

        private void SelectQuick(ComboBox combo, string code)
        {
            int idx = combo.Items.IndexOf(code);
            if (idx >= 0) combo.SelectedIndex = idx;
        }

        private void HighlightQuickButtons()
        {
            // простое выделение цвета активной валюты (зелёный фон)
            HighlightGroupLeft(comboBox1.SelectedItem?.ToString());
            HighlightGroupRight(comboBox2.SelectedItem?.ToString());
        }

        private void HighlightGroupLeft(string code)
        {
            SetButtonActive(btnL_KZT, code == "KZT");
            SetButtonActive(btnL_USD, code == "USD");
            SetButtonActive(btnL_EUR, code == "EUR");
            SetButtonActive(btnL_RUB, code == "RUB");
        }

        private void HighlightGroupRight(string code)
        {
            SetButtonActive(btnR_KZT, code == "KZT");
            SetButtonActive(btnR_USD, code == "USD");
            SetButtonActive(btnR_EUR, code == "EUR");
            SetButtonActive(btnR_RUB, code == "RUB");
        }

        private void SetButtonActive(Button button, bool active)
        {
            if (active)
            {
                button.BackColor = Color.FromArgb(122, 86, 255);
                button.ForeColor = Color.White;
            }
            else
            {
                button.BackColor = SystemColors.Control;
                button.ForeColor = Color.Black;
            }
        }

        private void lblRightTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
