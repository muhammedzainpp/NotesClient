namespace Notes.Web.Models.NoteModels.GetNotesQuery;

public class GetNotesDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public int UserId { get; set; }
}
