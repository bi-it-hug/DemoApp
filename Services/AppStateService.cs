using DemoApp.Models;

namespace DemoApp.Services;

public sealed class AppStateService(LocalStorageService storage)
{
    private const string StorageKey = "app-settings";

    public AppSettings Settings { get; private set; } = new();

    public bool IsInitialized { get; private set; }

    public event Action? Changed;

    public async Task InitializeAsync()
    {
        if (IsInitialized) return;
        Settings = await storage.GetAsync<AppSettings>(StorageKey) ?? new AppSettings();
        IsInitialized = true;
        NotifyChanged();
    }

    public async Task SetThemeModeAsync(ThemeMode mode)
    {
        if (Settings.ThemeMode == mode) return;
        Settings.ThemeMode = mode;
        await SaveAsync();
    }

    public async Task SetDrawerOpenAsync(bool value)
    {
        if (Settings.IsDrawerOpen == value) return;
        Settings.IsDrawerOpen = value;
        await SaveAsync();
    }

    public async Task SetTestSwitchAsync(bool value)
    {
        if (Settings.TestSwitch == value) return;
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
