using MudBlazor;
using static DemoApp.Theme.TailwindColors;
using static DemoApp.Utilities.ColorUtilities;

namespace DemoApp.Theme;

public static class Theme
{
    public static MudTheme Create() =>
        new()
        {
            LayoutProperties = new LayoutProperties()
            {
                AppbarHeight = "54px",
                DrawerMiniWidthLeft = "57px",
                DefaultBorderRadius = "8px",
            },

            PaletteLight = new PaletteLight()
            {
                Black = Base.Black,
                White = Base.White,
                Primary = Blue._500,
                PrimaryContrastText = Base.White,
                Secondary = Rose._500,
                SecondaryContrastText = Base.White,
                Tertiary = Neutral._200,
                TertiaryContrastText = Base.White,
                Info = Sky._500,
                InfoContrastText = Base.White,
                Success = Green._500,
                SuccessContrastText = Base.White,
                Warning = Amber._500,
                WarningContrastText = Base.White,
                Error = Red._500,
                ErrorContrastText = Base.White,
                Dark = Neutral._600,
                DarkContrastText = Base.White,
                TextPrimary = Neutral._900,
                TextSecondary = Opacity(Base.Black, 0.6),
                TextDisabled = Opacity(Base.Black, 0.4),
                ActionDefault = Neutral._900,
                ActionDisabled = Opacity(Base.Black, 0.3),
                ActionDisabledBackground = Opacity(Base.Black, 0.07),
                Background = Base.White,
                BackgroundGray = Opacity(Base.Black, 0.05),
                Surface = Neutral._050,
                DrawerBackground = Neutral._050,
                DrawerText = Neutral._900,
                DrawerIcon = Neutral._900,
                AppbarBackground = Base.White,
                AppbarText = Neutral._900,
                LinesDefault = Neutral._200,
                LinesInputs = Neutral._200,
                TableLines = Opacity(Base.Black, 0.05),
                TableStriped = Opacity(Base.Black, 0.02),
                TableHover = Opacity(Base.Black, 0.04),
                Divider = Neutral._200,
                DividerLight = Opacity(Base.Black, 0.8),
                Skeleton = Opacity(Base.Black, 0.1),
                PrimaryDarken = Blue._600,
                PrimaryLighten = Blue._400,
                SecondaryDarken = Rose._600,
                SecondaryLighten = Rose._400,
                TertiaryDarken = Emerald._600,
                TertiaryLighten = Emerald._400,
                InfoDarken = Sky._600,
                InfoLighten = Sky._400,
                SuccessDarken = Green._600,
                SuccessLighten = Green._400,
                WarningDarken = Amber._600,
                WarningLighten = Amber._400,
                ErrorDarken = Red._600,
                ErrorLighten = Red._400,
                DarkDarken = Neutral._700,
                DarkLighten = Neutral._500,
                BorderOpacity = 0.1,
                HoverOpacity = 0.06,
                RippleOpacity = 0.1,
                RippleOpacitySecondary = 0.1,
                GrayDefault = Opacity(Base.Black, 0.05),
                GrayLight = Neutral._300,
                GrayLighter = Neutral._200,
                GrayDark = Neutral._500,
                GrayDarker = Neutral._900,
                OverlayDark = Opacity(Neutral._800, 0.5),
                OverlayLight = Opacity(Base.White, 0.5),
            },

            PaletteDark = new PaletteDark()
            {
                Primary = Blue._400,
                Tertiary = Neutral._800,
                TextPrimary = Neutral._050,
                TextSecondary = Neutral._050,
                TextDisabled = Opacity(Base.White, 0.5),
                ActionDefault = Base.White,
                ActionDisabled = Opacity(Base.White, 0.3),
                ActionDisabledBackground = Opacity(Base.White, 0.1),
                Background = Neutral._950,
                BackgroundGray = Opacity(Base.White, 0.05),
                Surface = Neutral._900,
                DrawerBackground = Neutral._900,
                DrawerText = Base.White,
                DrawerIcon = Base.White,
                AppbarBackground = Neutral._950,
                AppbarText = Base.White,
                LinesDefault = Neutral._800,
                LinesInputs = Neutral._800,
                TableLines = Opacity(Base.White, 0.05),
                TableStriped = Opacity(Base.White, 0.2),
                Divider = Opacity(Base.White, 0.1),
                DividerLight = Opacity(Base.White, 0.06),
                Skeleton = Opacity(Base.White, 0.1),
                Dark = Neutral._800,
                DarkDarken = Neutral._900,
                DarkLighten = Neutral._700,
                BorderOpacity = 0.1,
                HoverOpacity = 0.06,
                RippleOpacity = 0.1,
                GrayDefault = Opacity(Base.White, 0.05),
                GrayLight = Neutral._300,
                GrayLighter = Neutral._200,
                GrayDark = Neutral._500,
                GrayDarker = Neutral._050,
                DarkContrastText = Neutral._900,
            },

            // Font sizes & line-heights match Tailwind: https://tailwindcss.com/docs/font-size
            Typography = new Typography()
            {
                Default = new DefaultTypography()
                {
                    FontFamily = ["Geist", "sans-serif"],
                    FontSize = "1rem", // text-base
                    LineHeight = (1.5 / 1).ToString(),
                    FontWeight = "400",
                    LetterSpacing = "0",
                },
                Button = new ButtonTypography()
                {
                    FontSize = "0.875rem", // text-sm
                    LineHeight = (1.25 / 0.875).ToString(),
                    FontWeight = "500",
                    LetterSpacing = "0",
                    TextTransform = "",
                },
                Subtitle1 = new Subtitle1Typography()
                {
                    FontSize = "1rem", // text-base
                    LineHeight = (1.5 / 1).ToString(),
                    FontWeight = "400",
                    LetterSpacing = "0",
                },
                Subtitle2 = new Subtitle2Typography()
                {
                    FontSize = "0.875rem", // text-sm
                    LineHeight = "20px", // (1.25 / 0.875).ToString()
                    FontWeight = "400",
                    LetterSpacing = "0",
                },
                Caption = new CaptionTypography()
                {
                    FontSize = "0.75rem", // text-xs
                    LineHeight = (1 / 0.75).ToString(),
                    FontWeight = "400",
                    LetterSpacing = "0",
                },
                Body2 = new Body2Typography()
                {
                    FontSize = "0.875rem", // text-sm
                    LineHeight = "1", // (1.25 / 0.875).ToString()
                    FontWeight = "400",
                    LetterSpacing = "0",
                },
                Body1 = new Body1Typography()
                {
                    FontSize = "1rem", // text-base
                    LineHeight = "22px", // (1.5 / 1).ToString()
                    FontWeight = "400",
                    LetterSpacing = "0",
                },
                H6 = new H6Typography()
                {
                    FontSize = "1.125rem", // text-lg
                    LineHeight = (1.75 / 1.125).ToString(),
                    FontWeight = "400",
                    LetterSpacing = "0",
                },
                H5 = new H5Typography()
                {
                    FontSize = "1.25rem", // text-xl
                    LineHeight = (1.75 / 1.25).ToString(),
                    FontWeight = "500",
                    LetterSpacing = "0",
                },
                H4 = new H4Typography()
                {
                    FontSize = "1.5rem", // text-2xl
                    LineHeight = (2 / 1.5).ToString(),
                    FontWeight = "500",
                    LetterSpacing = "0",
                },
                H3 = new H3Typography()
                {
                    FontSize = "1.875rem", // text-3xl
                    LineHeight = (2.25 / 1.875).ToString(),
                    FontWeight = "600",
                    LetterSpacing = "0",
                },
                H2 = new H2Typography()
                {
                    FontSize = "2.25rem", // text-4xl
                    LineHeight = (2.5 / 2.25).ToString(),
                    FontWeight = "600",
                    LetterSpacing = "0",
                },
                H1 = new H1Typography()
                {
                    FontSize = "3rem", // text-5xl
                    LineHeight = "1",
                    FontWeight = "700",
                    LetterSpacing = "0",
                },
            },

            Shadows = new Shadow()
            {
                Elevation =
                [
                    "none",
                    "none", /* "0px 0px 10px 0px var(--mud-palette-dark)" */
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                    "none",
                ],
            },
        };
}
