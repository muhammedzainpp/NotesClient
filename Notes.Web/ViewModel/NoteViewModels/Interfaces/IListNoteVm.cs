namespace Notes.Web.ViewModel.NoteViewModels.Interfaces;

public interface IListNoteVm
{
    int Id { get; set; }
    string Title { get; set; }
    string? Description { get; set; }
}
