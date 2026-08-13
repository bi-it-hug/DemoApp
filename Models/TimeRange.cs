using MudBlazor;

namespace DemoApp.Models;

public enum TimeRange
{
    Day = 1,
    Week = 7,
    Month = 30,
    Year = 365
}

public sealed record TimeRangeConfig(
    string Label,
    string Format,
    IReadOnlyDictionary<Breakpoint, TimeSpan> Spacing
)
{
    public TimeSpan GetSpacing(Breakpoint breakpoint) => Spacing.TryGetValue(breakpoint, out var spacing) ? spacing : Spacing[Breakpoint.Xxl];
}

public static class TimeRanges
{
    public static readonly Dictionary<TimeRange, TimeRangeConfig> Values = new()
    {
        [TimeRange.Day] = new(
            "24 Hours",
            "HH:mm",
            new Dictionary<Breakpoint, TimeSpan>
            {
                [Breakpoint.Xxl] = TimeSpan.FromHours(1),
                [Breakpoint.Xl] = TimeSpan.FromHours(1),
                [Breakpoint.Lg] = TimeSpan.FromHours(1),
                [Breakpoint.Md] = TimeSpan.FromHours(2),
                [Breakpoint.Sm] = TimeSpan.FromHours(4),
                [Breakpoint.Xs] = TimeSpan.FromHours(6)
            }
        ),
        [TimeRange.Week] = new(
            "7 Days",
            "ddd dd.MM",
            new Dictionary<Breakpoint, TimeSpan>
            {
                [Breakpoint.Xxl] = TimeSpan.FromDays(1),
                [Breakpoint.Xl] = TimeSpan.FromDays(1),
                [Breakpoint.Lg] = TimeSpan.FromDays(1),
                [Breakpoint.Md] = TimeSpan.FromDays(1),
                [Breakpoint.Sm] = TimeSpan.FromDays(2),
                [Breakpoint.Xs] = TimeSpan.FromDays(2)
            }
        ),
        [TimeRange.Month] = new(
            "30 Days",
            "dd. MMM",
            new Dictionary<Breakpoint, TimeSpan>
            {
                [Breakpoint.Xxl] = TimeSpan.FromDays(3),
                [Breakpoint.Xl] = TimeSpan.FromDays(3),
                [Breakpoint.Lg] = TimeSpan.FromDays(3),
                [Breakpoint.Md] = TimeSpan.FromDays(4),
                [Breakpoint.Sm] = TimeSpan.FromDays(5),
                [Breakpoint.Xs] = TimeSpan.FromDays(6)
            }
        ),
        [TimeRange.Year] = new(
            "12 Months",
            "MMM yyy",
            new Dictionary<Breakpoint, TimeSpan>
            {
                [Breakpoint.Xxl] = TimeSpan.FromDays(30),
                [Breakpoint.Xl] = TimeSpan.FromDays(30),
                [Breakpoint.Lg] = TimeSpan.FromDays(30),
                [Breakpoint.Md] = TimeSpan.FromDays(60),
                [Breakpoint.Sm] = TimeSpan.FromDays(90),
                [Breakpoint.Xs] = TimeSpan.FromDays(120)
            }
        )
    };
}
