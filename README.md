# DemoApp

A Blazor Server demo that shows how to build a UI with **[MudBlazor](https://mudblazor.com/)** — a Material Design component library for Blazor.

This project is meant for 2nd-year students who already know a bit of C# and Blazor, and want to learn how MudBlazor fits into a real app (layout, theme, dialogs, charts, custom components).

The Home page loads live cryptocurrency prices from the [CoinGecko API](https://www.coingecko.com/en/api) and plots them with MudBlazor’s timeseries chart.

---

## What is MudBlazor?

Blazor lets you build web UIs with C# and `.razor` components. MudBlazor gives you ready-made UI building blocks so you do not have to invent buttons, dialogs, grids, and navigation from scratch.

Instead of writing raw HTML/CSS for every control, you compose MudBlazor components:

```razor
<MudButton Variant="Variant.Filled" Color="Color.Primary">
    Click me
</MudButton>
```

MudBlazor is similar in spirit to libraries like Material UI (React) or Vuetify (Vue): you get consistent styling, theming, and accessibility patterns out of the box.

### Concepts you will see in this project

| Concept                 | What it means                                                 | Example in this app                          |
| ----------------------- | ------------------------------------------------------------- | -------------------------------------------- |
| **Components**          | Reusable UI pieces (`MudButton`, `MudCard`, `MudGrid`, …)     | `SampleCard.razor`, Home page grid           |
| **Providers**           | App-wide services MudBlazor needs (theme, dialogs, snackbars) | `MainLayout.razor`                           |
| **Theme**               | Colors, typography, light/dark mode                           | `Theme/Theme.cs`, `ThemeSwitch.razor`        |
| **Layout**              | App shell: app bar, drawer, main content                      | `MainLayout.razor`                           |
| **Dialogs / Snackbars** | Overlays and toast messages                                   | Playground page, notifications               |
| **Charts**              | Timeseries line chart with custom tooltip                     | `TimeSeriesChart.razor`                      |
| **HTTP services**       | Fetch JSON from an external API                               | `CoinGeckoService.cs`                        |

Official docs: [https://mudblazor.com/docs/overview](https://mudblazor.com/docs/overview)

---

## Prerequisites

Install:

1. **[.NET SDK](https://dotnet.microsoft.com/download)** — this project targets **.NET 10**
2. An editor: **Visual Studio 2022**, **VS Code** (+ C# extension), or **Rider**

Check that the SDK is available:

```bash
dotnet --version
```

You should see a 10.x version (or newer that can build `net10.0`).

---

## How to run

From the project root (`DemoApp`):

```bash
dotnet restore
dotnet run
```

Or with HTTPS (as configured in `Properties/launchSettings.json`):

```bash
dotnet run --launch-profile https
```

Then open the URL printed in the terminal, typically:

- HTTP: http://localhost:5138
- HTTPS: https://localhost:7243

The Home chart needs internet access for CoinGecko. If the request fails (rate limit, no network), the card shows an error instead of the chart.

### Run from Visual Studio / VS Code

- **Visual Studio**: open `DemoApp.sln`, press **F5** (or Ctrl+F5).
- **VS Code**: open the folder, use the existing launch profile in `.vscode/launch.json`, or run `dotnet run` in the terminal.

---

## Pages to explore

| Route         | File                                | What to notice                                                                 |
| ------------- | ----------------------------------- | ------------------------------------------------------------------------------ |
| `/`           | `Components/Pages/Home.razor`       | `MudGrid` layout, `SampleCard`, live CoinGecko chart, time-range `MudSelect`   |
| `/playground` | `Components/Pages/Playground.razor` | Opening a custom `AlertDialog` with `IDialogService`                           |

Also look at the shell UI in `Components/Layout/MainLayout.razor`: app bar, drawer, breadcrumbs, theme provider, snackbar/dialog providers.

### Home chart (worth a closer look)

1. `Home.razor` calls `CoinGeckoService.GetMarketChartAsync` for bitcoin, ethereum, tether, and solana.
2. Prices come back as `[timestamp, value]` pairs (`Models/CoinGeckoMarketChart.cs`).
3. `TimeSeriesChart.CreateSeries` turns those pairs into MudBlazor `ChartSeries<double>`.
4. `TimeSeriesChart.razor` wraps `MudChart` (`ChartType.Timeseries`) and customizes the tooltip, axis labels, and palette.
5. The time-range dropdown (`24 Hours` / `7 Days` / `30 Days` / `12 Months`) is the `TimeRange` enum in `Models/TimeRange.cs`. Changing it refetches the data.

Chart docs: [https://mudblazor.com/components/chart](https://mudblazor.com/components/chart)

---

## Project structure (high level)

```
DemoApp/
├── Program.cs                 # Registers MudBlazor + app services (incl. HttpClient)
├── Components/
│   ├── App.razor              # Loads MudBlazor CSS/JS
│   ├── _Imports.razor         # Global usings (includes MudBlazor)
│   ├── Layout/                # App layout + reconnect UI
│   ├── Pages/                 # Routable pages
│   └── Custom/                # App-specific components built on MudBlazor
├── Services/                  # App state, notifications, local storage, CoinGecko
├── Theme/                     # MudBlazor theme customization
├── Models/                    # Settings, chart time ranges, API models
└── wwwroot/                   # Static files
```

### How MudBlazor is wired in

1. **Package** — `MudBlazor` is referenced in `DemoApp.csproj`.
2. **Services** — `builder.Services.AddMudServices(...)` in `Program.cs`.
3. **Assets** — CSS/JS linked in `Components/App.razor`.
4. **Providers** — `MudThemeProvider`, `MudDialogProvider`, `MudSnackbarProvider`, `MudPopoverProvider` in `MainLayout.razor`.
5. **Usings** — `@using MudBlazor` in `Components/_Imports.razor` so every page can use Mud components without repeating imports.

`CoinGeckoService` is registered as a scoped service with a named `HttpClient` whose base address is `https://api.coingecko.com/api/v3/`.

Custom components inherit `StateComponent` (via `_Imports.razor`) so they re-render when app settings or notifications change.

---

## Quick MudBlazor starter tips

1. Prefer Mud components (`MudText`, `MudStack`, `MudPaper`) over one-off HTML when you want consistent spacing and theme colors.
2. Use the [component docs](https://mudblazor.com/docs/overview) — each page shows live examples and the razor code.
3. Icons come from Material Icons, e.g. `@Icons.Material.Rounded.Home`.
4. Layout helpers often use Mud utility classes (`d-flex`, `pa-4`, `mud-height-full`) — same idea as spacing utilities in other UI kits.
5. When you need a reusable piece of UI for _this_ app, wrap MudBlazor components in your own `.razor` file under `Components/Custom/` (see `SampleCard.razor`, `TimeSeriesChart.razor`, or `NotificationMenu.razor`).

---

## Useful links

- [MudBlazor documentation](https://mudblazor.com/docs/overview)
- [MudBlazor component list](https://mudblazor.com/docs/components)
- [MudBlazor charts](https://mudblazor.com/components/chart)
- [ASP.NET Core Blazor docs](https://learn.microsoft.com/aspnet/core/blazor/)
- [MudBlazor GitHub](https://github.com/MudBlazor/MudBlazor)
- [CoinGecko API docs](https://docs.coingecko.com/)
