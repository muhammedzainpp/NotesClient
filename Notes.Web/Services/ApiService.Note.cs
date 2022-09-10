using Notes.Web.Dtos.Notes.SaveNoteCommand;
using Notes.Web.Services.Interfaces;

namespace Notes.Web.Services;

public partial class ApiService
{
    private const string Url = "notes";

    public async Task<int> SaveNoteAsync(SaveNoteCommand request)
    {
        var response = await PostAsync<SaveNoteCommand, int>(request, Url);
        return response;
    }
}
