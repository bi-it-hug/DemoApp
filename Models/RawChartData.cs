namespace DemoApp.Models;

public class RawChartData
{
    public string[] Labels { get; set; } = [];
    public List<RawChartDataset> Datasets { get; set; } = [];
}
