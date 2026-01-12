using System;
using System.Net.Http;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

// ZORUNLU MODEL SINIFLARI
class CurrencyResponse
{
    public string Base { get; set; }
    public Dictionary<string, decimal> Rates { get; set; }
}

class Currency
{
    public string Code { get; set; }
    public decimal Rate { get; set; }
}

class Program
{
    private static readonly HttpClient client = new HttpClient();
    private static List<Currency> currencyList = new List<Currency>();

    static async Task Main(string[] args)
    {
        await LoadDataAsync();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n===== CurrencyTracker =====");
            Console.WriteLine("1. Tüm dövizleri listele");
            Console.WriteLine("2. Koda göre döviz ara");
            Console.WriteLine("3. Belirli bir değerden büyük dövizleri listele");
            Console.WriteLine("4. Dövizleri değere göre sırala");
            Console.WriteLine("5. İstatistiksel özet göster");
            Console.WriteLine("0. Çıkış");
            Console.Write("Seçiminiz: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    currencyList
                        .Select(c => $"{c.Code}: {c.Rate}")
                        .ToList()
                        .ForEach(Console.WriteLine);
                    break;

                case "2":
                    Console.Write("Aranacak Döviz Kodu: ");
                    string code = Console.ReadLine();

                    var result = currencyList
                        .Where(c => c.Code.Equals(code, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    if (result.Any())
                        result.ForEach(c => Console.WriteLine($"{c.Code}: {c.Rate}"));
                    else
                        Console.WriteLine("Kayıt bulunamadı.");
                    break;

                case "3":
                    Console.Write("Limit Değeri Girin: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal limit))
                    {
                        currencyList
                            .Where(c => c.Rate > limit)
                            .ToList()
                            .ForEach(c => Console.WriteLine($"{c.Code}: {c.Rate}"));
                    }
                    break;

                case "4":
                    // YATAY ALT MENÜ
                    Console.Write("Sıralama (1-Artan | 2-Azalan): ");
                    string sortChoice = Console.ReadLine();

                    if (sortChoice == "1")
                    {
                        currencyList
                            .OrderBy(c => c.Rate)
                            .ToList()
                            .ForEach(c => Console.WriteLine($"{c.Code}: {c.Rate}"));
                    }
                    else if (sortChoice == "2")
                    {
                        currencyList
                            .OrderByDescending(c => c.Rate)
                            .ToList()
                            .ForEach(c => Console.WriteLine($"{c.Code}: {c.Rate}"));
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz seçim.");
                    }
                    break;

                case "5":
                    Console.WriteLine($"Toplam Döviz Sayısı: {currencyList.Count()}");
                    Console.WriteLine($"En Yüksek Kur: {currencyList.Max(c => c.Rate)}");
                    Console.WriteLine($"En Düşük Kur: {currencyList.Min(c => c.Rate)}");
                    Console.WriteLine($"Ortalama Kur: {currencyList.Average(c => c.Rate)}");
                    break;

                case "0":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
    }

    static async Task LoadDataAsync()
    {
        try
        {
            string url = "https://api.frankfurter.app/latest?from=TRY";
            string json = await client.GetStringAsync(url);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<CurrencyResponse>(json, options);

            currencyList = data.Rates
                .Select(r => new Currency
                {
                    Code = r.Key,
                    Rate = r.Value
                })
                .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata oluştu: {ex.Message}");
        }
    }
}
