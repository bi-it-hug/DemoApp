using System.Globalization;

namespace DemoApp.Utilities;

public static class StringUtilities
{
    public static string ToTitleCase(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return value;
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
    }

    public static string CapitalizeFirstLetter(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return value;
        return char.ToUpperInvariant(value[0]) + value[1..];
    }
}
