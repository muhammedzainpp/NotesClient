using Notes.Web.Models.Constants;
using Notes.Web.Models.Enums;
using Notes.Web.Models.Settings;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModels.ButtonWithSpinnerViewModels;
using Notes.Web.ViewModels.NoteViewModels.Interfaces;
using Notes.Web.ViewModels.NotifierViewModels.Interfaces;

namespace Notes.Web.ViewModels.NoteViewModels;

public partial class SaveNoteVm : ISaveNoteVm
{
    private readonly ISetting _settings;
    private readonly INoteService _service;
    private readonly INotifierViewModel _notifier;

    public SaveNoteVm(ISetting settings,
        IButtonWithSpinnerVm spinnerVm,
        INoteService noteService,
        INotifierViewModel notifier)
    {
        _settings = settings;
        SpinnerVm = spinnerVm;
        _service = noteService;
        _notifier = notifier;
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

        _notifier.Show(NotifierType.Success, NotifierConstants.SuccessFullySaved);

        return result;
    }
}
