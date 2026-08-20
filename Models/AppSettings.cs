namespace DemoApp.Models;

public sealed class AppSettings
{
	public ThemeMode ThemeMode { get; set; } = ThemeMode.System;
	public bool IsDrawerOpen { get; set; } = false;
	public bool TestSwitch { get; set; } = false;
	//public AppSettings Clone() => (AppSettings)MemberwiseClone();
}
