using Notes.Web.Dtos.Notes.SaveNoteCommand;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.Base;
using Notes.Web.ViewModel.NoteViewModels.Interfaces;

namespace Notes.Web.ViewModel.NoteViewModels;

public class SaveNoteVm : BaseVm, ISaveNoteVm
{
    public SaveNoteVm(IApiService apiService) : base(apiService) { }

    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }

    public async Task SaveNoteAsync()
    {
        var command = new SaveNoteCommand
        {
            Id = Id,
            Title = Title,
            Description = Description
        };

        await _apiService.SaveNoteAsync(command);
    }
}
