namespace Notes.Web.ViewModels.LabelViewModels.Interfaces;

public interface ISaveLabelVm
{
    string? Description { get; set; }
    int Id { get; set; }
    string Title { get; set; }
    int UserId { get; set; }

    Task SaveAsync();
}