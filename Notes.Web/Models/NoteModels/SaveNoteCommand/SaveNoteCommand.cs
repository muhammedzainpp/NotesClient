namespace Notes.Web.Models.NoteModels.SaveNoteCommand;

public class SaveNoteCommand
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public int UserId { get; set; }
}
