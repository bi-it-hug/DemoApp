using System.Text.Json.Serialization;

namespace DemoApp.Models;

public sealed class CoinGeckoMarketChart
{
	[JsonPropertyName("prices")]
	public List<List<double>> Prices { get; set; } = [];

	[JsonPropertyName("market_caps")]
	public List<List<double>> MarketCaps { get; set; } = [];

	[JsonPropertyName("total_volumes")]
	public List<List<double>> TotalVolumes { get; set; } = [];
}
