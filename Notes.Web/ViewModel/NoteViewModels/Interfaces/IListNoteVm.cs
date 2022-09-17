using Notes.Web.Dtos.Notes.GetNotesQuery;

namespace Notes.Web.ViewModel.NoteViewModels.Interfaces;

public interface IListNoteVm
{
    public IEnumerable<GetNotesDto>? Notes { get; set; }

    Task GetNotesAsync();
}
