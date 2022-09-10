using Notes.Web.Dtos.Notes.SaveNoteCommand;

namespace Notes.Web.Services.Interfaces;

public partial interface IApiService
{
    Task<int> SaveNoteAsync(SaveNoteCommand request);
}
