namespace Notes.Web.Models.Settings;

public class Setting : ISetting
{
    public int UserId { get; set; }
    public string FirstName { get; set; } = default!;
}
