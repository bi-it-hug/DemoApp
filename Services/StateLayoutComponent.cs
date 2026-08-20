using Microsoft.AspNetCore.Components;

namespace DemoApp.Services;

public abstract class StateLayoutComponent : LayoutComponentBase, IDisposable
{
	[Inject]
	protected AppStateService AppStateService { get; set; } = default!;

	[Inject]
	protected NotificationService NotificationService { get; set; } = default!;

	protected override void OnInitialized()
	{
		AppStateService.Changed += OnAppStateChanged;
		NotificationService.Changed += OnNotificationStateChanged;
	}

	protected virtual void OnAppStateChanged()
	{
		_ = InvokeAsync(StateHasChanged);
	}

	protected virtual void OnNotificationStateChanged()
	{
		_ = InvokeAsync(StateHasChanged);
	}

	public virtual void Dispose()
	{
		AppStateService.Changed -= OnAppStateChanged;
		NotificationService.Changed -= OnNotificationStateChanged;
	}
}
