using Notes.Web.Models.NoteModels.GetNotesQuery;
using Notes.Web.Models.NoteModels.SaveNoteCommand;

namespace Notes.Web.Services.Interfaces;

public interface INoteService
{
    Task<int> SaveNoteAsync(SaveNoteCommand request);
    Task<IEnumerable<GetNotesDto>?> GetNotesAsync( );
}
