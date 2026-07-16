namespace DemoApp.Utilities;

public static class ColorUtilities
{
    public static string Opacity(string baseColor, double opacity)
    {
        if (string.IsNullOrWhiteSpace(baseColor))
            throw new ArgumentException("Color cannot be empty.", nameof(baseColor));

        if (opacity is < 0 or > 1)
            {
                throw new ArgumentOutOfRangeException(
                nameof(opacity),
                "Opacity must be between 0 and 1."
            );
            }

            string color = baseColor.StartsWith('#')
            ? baseColor
            : $"#{baseColor}";

        if (color.Length != 7)
            {
                throw new ArgumentException(
                "Color must use the format #RRGGBB.",
                nameof(baseColor)
            );
            }

            int alpha = (int)Math.Round(
            opacity * 255,
            MidpointRounding.AwayFromZero
        );

        return $"{color}{alpha:x2}";
    }
}
