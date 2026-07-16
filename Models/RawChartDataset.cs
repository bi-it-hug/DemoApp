using MudBlazor;

namespace DemoApp.Models;

public class RawChartDataset
{
    public string Name { get; set; } = "";
    public ChartData<double> Data { get; set; } = Array.Empty<double>();
}
