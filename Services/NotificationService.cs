using DemoApp.Models;
using MudBlazor;

namespace DemoApp.Services;

public sealed class NotificationService(LocalStorageService storage)
{
    private const string StorageKey = "app-notifications";

    private List<Notification> _notifications = [];

    public IReadOnlyList<Notification> Notifications => _notifications;

    public bool IsInitialized { get; private set; }

    public event Action? Changed;

    public async Task InitializeAsync()
    {
        if (IsInitialized) return;
        var stored = await storage.GetAsync<List<Notification>>(StorageKey);

        if (stored is null or [])
        {
            _notifications = CreateDefaults();
            await storage.SetAsync(StorageKey, _notifications);
        }
        else
        {
            _notifications = stored;
        }

        IsInitialized = true;
        NotifyChanged();
    }

    public async Task AddAsync(Notification notification)
    {
        _notifications.Insert(0, notification);
        await SaveAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        var removed = _notifications.RemoveAll(n => n.Id == id);
        if (removed == 0) return;
        await SaveAsync();
    }

    public async Task ClearAsync()
    {
        if (_notifications.Count == 0) return;
        _notifications.Clear();
        await SaveAsync();
    }

    private async Task SaveAsync()
    {
        await storage.SetAsync(StorageKey, _notifications);
        NotifyChanged();
    }

    private void NotifyChanged()
    {
        Changed?.Invoke();
    }

    private static List<Notification> CreateDefaults() =>
    [
        new(
            "",
            "Lorem ipsum dolor sit amet",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Severity.Normal
        ),
        new(
            "",
            "Lorem ipsum dolor sit amet",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Severity.Info
        ),
        new(
            "",
            "Lorem ipsum dolor sit amet",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Severity.Success
        ),
        new(
            "",
            "Lorem ipsum dolor sit amet",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Severity.Warning
        ),
        new(
            "",
            "Lorem ipsum dolor sit amet",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Severity.Error
        ),
    ];
}
