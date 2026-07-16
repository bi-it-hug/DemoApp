using MudBlazor;

namespace DemoApp.Models;

public class Notification(string href, string title, string description, Severity severity)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Href { get; set; } = href;
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public Severity Severity { get; set; } = severity;
}
