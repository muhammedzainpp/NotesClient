namespace Notes.Web.ViewModel.NoteViewModels.Interfaces;

public interface ISaveNoteVm
{
    int Id { get; set; }
    string Title { get; set; }
    string? Description { get; set; }

    Task<int> SaveNoteAsync();
}
