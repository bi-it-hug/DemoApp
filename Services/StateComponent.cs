using Microsoft.AspNetCore.Components;

namespace DemoApp.Services;

public abstract class StateComponent : ComponentBase, IDisposable
{
	[Inject]
	protected AppStateService AppStateService { get; set; } = default!;

	[Inject]
	protected NotificationService NotificationService { get; set; } = default!;

	protected override void OnInitialized()
	{
		AppStateService.Changed += OnStateChanged;
		NotificationService.Changed += OnStateChanged;
	}

	private void OnStateChanged()
	{
		InvokeAsync(StateHasChanged);
	}

	public virtual void Dispose()
	{
		AppStateService.Changed -= OnStateChanged;
		NotificationService.Changed -= OnStateChanged;
	}
}
