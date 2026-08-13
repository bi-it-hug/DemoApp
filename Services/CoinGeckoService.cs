using DemoApp.Models;

namespace DemoApp.Services;

public sealed class CoinGeckoService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient HttpClient = httpClientFactory.CreateClient(nameof(CoinGeckoService));

    public async Task<(CoinGeckoMarketChart? Data, string? Error)> GetMarketChartAsync(
        string coinId = "bitcoin",
        string vsCurrency = "chf",
        TimeRange days = TimeRange.Day,
        CancellationToken cancellationToken = default
    )
    {
        var url = $"coins/{coinId}/market_chart?vs_currency={vsCurrency}&days={Convert.ToInt32(days)}";
        try
        {
            var response = await HttpClient.GetFromJsonAsync<CoinGeckoMarketChart>(url, cancellationToken);
            return (response, null);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Request failed: {ex.Message}");
            return (null, ex.Message);
        }
    }
}



































//private List<ChartSeries<double>> SampleDataTemperature = new()
//{
//    new()
//    {
//        Name = "Sensor 1",
//        Data = new ChartData<double>(new[]
//        {
//            (new DateTime(2026, 8, 7, 9, 00, 0), 20.3),
//            (new DateTime(2026, 8, 7, 9, 05, 0), 20.5),
//            (new DateTime(2026, 8, 7, 9, 10, 0), 20.8),
//            (new DateTime(2026, 8, 7, 9, 15, 0), 52.6),
//            (new DateTime(2026, 8, 7, 9, 20, 0), 21.4),
//            (new DateTime(2026, 8, 7, 9, 25, 0), -8.2),
//            (new DateTime(2026, 8, 7, 9, 30, 0), 22.0),
//            (new DateTime(2026, 8, 7, 9, 35, 0), 22.2),
//            (new DateTime(2026, 8, 7, 9, 40, 0), 81.9),
//            (new DateTime(2026, 8, 7, 9, 45, 0), 22.7),
//            (new DateTime(2026, 8, 7, 9, 50, 0), 3.4),
//            (new DateTime(2026, 8, 7, 9, 55, 0), 22.9),
//            (new DateTime(2026, 8, 7, 10, 00, 0), 23.0),
//        })
//    },

//    new()
//    {
//        Name = "Sensor 2",
//        Data = new ChartData<double>(new[]
//        {
//            (new DateTime(2026, 8, 7, 9, 00, 0), 18.6),
//            (new DateTime(2026, 8, 7, 9, 05, 0), 18.9),
//            (new DateTime(2026, 8, 7, 9, 10, 0), 19.1),
//            (new DateTime(2026, 8, 7, 9, 15, 0), 19.4),
//            (new DateTime(2026, 8, 7, 9, 20, 0), 75.0),
//            (new DateTime(2026, 8, 7, 9, 25, 0), 19.8),
//            (new DateTime(2026, 8, 7, 9, 30, 0), 20.0),
//            (new DateTime(2026, 8, 7, 9, 35, 0), -15.0),
//            (new DateTime(2026, 8, 7, 9, 40, 0), 20.4),
//            (new DateTime(2026, 8, 7, 9, 45, 0), 20.7),
//            (new DateTime(2026, 8, 7, 9, 50, 0), 95.0),
//            (new DateTime(2026, 8, 7, 9, 55, 0), 21.0),
//            (new DateTime(2026, 8, 7, 10, 00, 0), 21.2),
//        })
//    },

//    new()
//    {
//        Name = "Sensor 3",
//        Data = new ChartData<double>(new[]
//        {
//            (new DateTime(2026, 8, 7, 9, 00, 0), 24.5),
//            (new DateTime(2026, 8, 7, 9, 05, 0), 24.4),
//            (new DateTime(2026, 8, 7, 9, 10, 0), 24.6),
//            (new DateTime(2026, 8, 7, 9, 15, 0), 24.8),
//            (new DateTime(2026, 8, 7, 9, 20, 0), 25.0),
//            (new DateTime(2026, 8, 7, 9, 25, 0), 25.2),
//            (new DateTime(2026, 8, 7, 9, 30, 0), -20.0),
//            (new DateTime(2026, 8, 7, 9, 35, 0), 25.5),
//            (new DateTime(2026, 8, 7, 9, 40, 0), 25.7),
//            (new DateTime(2026, 8, 7, 9, 45, 0), 130.0),
//            (new DateTime(2026, 8, 7, 9, 50, 0), 25.9),
//            (new DateTime(2026, 8, 7, 9, 55, 0), 26.0),
//            (new DateTime(2026, 8, 7, 10, 00, 0), 26.2),
//        })
//    }
//};