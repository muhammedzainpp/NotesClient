namespace Notes.Web.Models;

public class Settings : ISettings
{
    public int UserId { get; set; }
    public string FirstName { get; set; } = default!;
}
