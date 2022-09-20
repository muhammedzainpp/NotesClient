using Notes.Web.Models.Settings;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.ButtonWithSpinnerViewModel;
using Notes.Web.ViewModel.NoteViewModels.Interfaces;

namespace Notes.Web.ViewModel.NoteViewModels;

public partial class SaveNoteVm : ISaveNoteVm
{
    private readonly ISetting _settings;
    private readonly INoteService _service;

    public SaveNoteVm(ISetting settings, 
        IButtonWithSpinnerVm spinnerVm, 
        INoteService noteService)
    {
        _settings = settings;
        SpinnerVm = spinnerVm;
        _service = noteService;
    }

    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public IButtonWithSpinnerVm SpinnerVm { get; set; }

    public async Task<int> SaveNoteAsync()
    {
        SpinnerVm.IsBusy = true;
        var command = this.MapTo(_settings);
        var result = await _service.SaveNoteAsync(command);
        SpinnerVm.IsBusy = false;
        return result;
    }
}
