namespace DemoApp.Models;

public sealed class AppSettings
{
    public ThemeMode ThemeMode { get; set; } = ThemeMode.System;
    public bool IsDrawerOpen { get; set; } = true;
    public bool TestSwitch { get; set; } = false;
}
