using Notes.Web.Models.NoteModels.GetNotesQuery;
using Notes.Web.Models.NoteModels.SaveNoteCommand;
using Notes.Web.Services.Interfaces;

namespace Notes.Web.Services;

public partial class NoteService : INoteService
{
    private readonly IApiService _apiService;

    public NoteService(IApiService apiService) => _apiService = apiService;

    public async Task<int> SaveNoteAsync(SaveNoteCommand request) => 
        await TryCatchAsync(async () =>
        {
            ValidateNote(request);
            var url = "notes";
            var response = await _apiService.PostAsync<SaveNoteCommand, int>(request, url);
            return response;
        });

    public async Task<IEnumerable<GetNotesDto>?> GetNotesAsync()
    {
        var url = "notes";
        var response = await _apiService.GetAsync<IEnumerable<GetNotesDto>>(url);
        return response;
    }
}
