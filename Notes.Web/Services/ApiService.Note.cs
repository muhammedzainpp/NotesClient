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
}
