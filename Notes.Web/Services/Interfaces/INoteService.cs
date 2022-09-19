using Notes.Web.Dtos.Notes.GetNotesQuery;
using Notes.Web.Dtos.Notes.SaveNoteCommand;

namespace Notes.Web.Services.Interfaces;

public interface INoteService
{
    Task<int> SaveNoteAsync(SaveNoteCommand request);
    Task<IEnumerable<GetNotesDto>?> GetNotesAsync( );
}
