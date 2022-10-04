namespace Notes.Web.Models.LabelModels.Queries;

public class GetLabelQueryDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public int UserId { get; set; }
}
