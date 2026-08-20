using DemoApp.Models;

namespace DemoApp.Services;

public sealed class AppStateService(LocalStorageService storage)
{
    private const string StorageKey = "app-settings";

    public AppSettings Settings { get; private set; } = new();

    // Always Light or Dark; not persisted. System mode follows the OS preference at runtime.
    public ThemeMode ResolvedTheme { get; private set; } = ThemeMode.Light;

    public bool IsDarkMode => ResolvedTheme == ThemeMode.Dark;

    public bool IsInitialized { get; private set; }

    public event Action? Changed;

    public async Task InitializeAsync()
    {
        if (IsInitialized)
            return;
        Settings =
            await storage.GetAsync<AppSettings>(StorageKey)
            ?? new AppSettings();

        if (Settings.ThemeMode != ThemeMode.System)
            ResolvedTheme = Settings.ThemeMode;

        IsInitialized = true;
        NotifyChanged();
    }

    public async Task SetSettings(AppSettings settings)
    {
        if (Settings == settings)
            return;
        Settings = settings;
        await SaveAsync();
    }

    public async Task SetThemeModeAsync(ThemeMode mode)
    {
        if (Settings.ThemeMode == mode)
            return;
        Settings.ThemeMode = mode;

        if (mode != ThemeMode.System)
            ResolvedTheme = mode;

        await SaveAsync();
    }

    public void SetResolvedTheme(bool isDarkMode)
    {
        var theme = isDarkMode ? ThemeMode.Dark : ThemeMode.Light;
        if (ResolvedTheme == theme)
            return;
        ResolvedTheme = theme;
        NotifyChanged();
    }

    public async Task SetDrawerOpenAsync(bool value)
    {
        if (Settings.IsDrawerOpen == value)
            return;
        Settings.IsDrawerOpen = value;
        await SaveAsync();
    }

    public async Task SetTestSwitchAsync(bool value)
    {
        if (Settings.TestSwitch == value)
            return;
        Settings.TestSwitch = value;
        await SaveAsync();
    }

    public Task ToggleDrawerAsync()
    {
        return SetDrawerOpenAsync(!Settings.IsDrawerOpen);
    }

    public Task ToggleTestSwitchAsync()
    {
        return SetTestSwitchAsync(!Settings.TestSwitch);
    }

    private async Task SaveAsync()
    {
        await storage.SetAsync(StorageKey, Settings);
        NotifyChanged();
    }

    private void NotifyChanged()
    {
        Changed?.Invoke();
    }
}
