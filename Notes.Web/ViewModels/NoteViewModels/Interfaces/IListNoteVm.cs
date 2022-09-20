using Notes.Web.Models.NoteModels.GetNotesQuery;

namespace Notes.Web.ViewModels.NoteViewModels.Interfaces;

public interface IListNoteVm
{
    public IEnumerable<GetNotesDto>? Notes { get; set; }

    Task GetNotesAsync();
}
