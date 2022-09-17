using Notes.Web.Dtos.Notes.SaveNoteCommand;
using Notes.Web.Models;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.Base;
using Notes.Web.ViewModel.NoteViewModels.Interfaces;

namespace Notes.Web.ViewModel.NoteViewModels;

public class SaveNoteVm : BaseVm, ISaveNoteVm
{
    private readonly Settings _settings;

    public SaveNoteVm(IApiService apiService, Settings settings) : base(apiService) => 
        _settings = settings;

    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }

    public async Task SaveNoteAsync()
    {
        var command = new SaveNoteCommand
        {
            Id = Id,
            Title = Title,
            Description = Description,
            UserId=_settings.UserId
        };

        await _apiService.SaveNoteAsync(command);
    }
}
