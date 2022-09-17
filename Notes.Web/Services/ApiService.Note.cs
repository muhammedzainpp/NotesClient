using Notes.Web.Dtos.Notes.GetNotesQuery;
using Notes.Web.Dtos.Notes.SaveNoteCommand;
using Notes.Web.Services.Interfaces;

namespace Notes.Web.Services;

public partial class ApiService
{
    public async Task<int> SaveNoteAsync(SaveNoteCommand request)
    {
        var url = "notes";
        var response = await PostAsync<SaveNoteCommand, int>(request, url);
        return response;
    }

    public async Task<IEnumerable<GetNotesDto>?> GetNotesAsync()
    {
        var url = "notes";
        var response = await GetAsync<IEnumerable<GetNotesDto>>(url);
        return response;
    }
}
