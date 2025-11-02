using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace СourseWork
{
    public static class CurrencyRateService
    {
        private static Dictionary<string, double> _ratesCache = null;
        private static DateTime _lastUpdate = DateTime.MinValue;
        private const string CacheFileName = "rates_cache.xml";

        /// <summary>
        /// Получает курсы валют относительно KZT (1 валюта = X KZT)
        /// </summary>
        public static async Task<Dictionary<string, double>> GetRatesAsync()
        {
            // Если данные уже загружены сегодня, возвращаем кэш
            if (_ratesCache != null && _lastUpdate.Date == DateTime.Today)
            {
                return _ratesCache;
            }

            try
            {
                string response = await FetchRatesWithFallback();

                var xml = XDocument.Parse(response);
                _ratesCache = new Dictionary<string, double>();

                // KZT всегда равен 1 (базовая валюта)
                _ratesCache["KZT"] = 1.0;

                foreach (var item in xml.Descendants("item"))
                {
                    string code = item.Element("title")?.Value ?? "";
                    string rateStr = item.Element("description")?.Value ?? "";

                    if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(rateStr))
                    {
                        // Парсим курс: сколько тенге за единицу валюты
                        if (double.TryParse(rateStr, System.Globalization.NumberStyles.Any,
                            System.Globalization.CultureInfo.InvariantCulture, out double rate))
                        {
                            _ratesCache[code] = rate;
                        }
                    }
                }

                _lastUpdate = DateTime.Now;

                // Сохраняем в файл для офлайн режима
                File.WriteAllText(CacheFileName, response);

                return _ratesCache;
            }
            catch (Exception)
            {
                // Пытаемся загрузить из кэша
                return LoadRatesFromCache();
            }
        }

        /// <summary>
        /// Получает курсы валют синхронно (использует кэш или загружает асинхронно в фоне)
        /// </summary>
        public static Dictionary<string, double> GetRates()
        {
            // Если есть кэш, возвращаем его
            if (_ratesCache != null)
            {
                return _ratesCache;
            }

            // Пытаемся загрузить из файла кэша
            var cached = LoadRatesFromCache();
            if (cached != null && cached.Count > 0)
            {
                _ratesCache = cached;
                return _ratesCache;
            }

            // Если нет кэша, возвращаем базовые курсы
            return GetDefaultRates();
        }

        /// <summary>
        /// Получает курс валюты относительно KZT
        /// </summary>
        public static double GetRate(string currencyCode)
        {
            var rates = GetRates();
            return rates.ContainsKey(currencyCode) ? rates[currencyCode] : 1.0;
        }

        /// <summary>
        /// Конвертирует сумму из одной валюты в другую
        /// </summary>
        public static double Convert(string fromCurrency, string toCurrency, double amount)
        {
            var rates = GetRates();

            // Если валюта не найдена, возвращаем исходную сумму
            if (!rates.ContainsKey(fromCurrency) || !rates.ContainsKey(toCurrency))
            {
                return amount;
            }

            // Конвертируем через KZT
            // 1. Конвертируем fromCurrency в KZT
            double amountInKZT = amount * rates[fromCurrency];

            // 2. Конвертируем KZT в toCurrency
            double result = amountInKZT / rates[toCurrency];

            return result;
        }

        private static Dictionary<string, double> LoadRatesFromCache()
        {
            try
            {
                if (File.Exists(CacheFileName))
                {
                    string cached = File.ReadAllText(CacheFileName);
                    var xml = XDocument.Parse(cached);
                    var rates = new Dictionary<string, double>();

                    // KZT всегда равен 1
                    rates["KZT"] = 1.0;

                    foreach (var item in xml.Descendants("item"))
                    {
                        string code = item.Element("title")?.Value ?? "";
                        string rateStr = item.Element("description")?.Value ?? "";

                        if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(rateStr))
                        {
                            if (double.TryParse(rateStr, System.Globalization.NumberStyles.Any,
                                System.Globalization.CultureInfo.InvariantCulture, out double rate))
                            {
                                rates[code] = rate;
                            }
                        }
                    }

                    return rates;
                }
            }
            catch
            {
                // Игнорируем ошибки парсинга кэша
            }

            return null;
        }

        public static Dictionary<string, double> GetDefaultRates()
        {
            // Возвращаем базовые курсы, если не удалось загрузить
            return new Dictionary<string, double>()
            {
                { "KZT", 1.0 },
                { "USD", 530.0 },
                { "EUR", 580.0 },
                { "RUB", 5.5 },
                { "GBP", 670.0 }
            };
        }

        private static async Task<string> FetchRatesWithFallback()
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

        /// <summary>
        /// Принудительно обновляет кэш курсов валют
        /// </summary>
        public static async Task RefreshRatesAsync()
        {
            _ratesCache = null;
            _lastUpdate = DateTime.MinValue;
            await GetRatesAsync();
        }
    }
}

