using Notes.Web.ViewModel.NoteViewModels.Interfaces;

namespace Notes.Web.ViewModel.NoteViewModels;

public class ListNoteVm : IListNoteVm
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
}
