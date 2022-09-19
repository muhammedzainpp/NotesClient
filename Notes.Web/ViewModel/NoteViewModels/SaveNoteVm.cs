using Notes.Web.Models;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.Base;
using Notes.Web.ViewModel.ButtonWithSpinnerViewModel;
using Notes.Web.ViewModel.NoteViewModels.Interfaces;

namespace Notes.Web.ViewModel.NoteViewModels;

public partial class SaveNoteVm : BaseVm, ISaveNoteVm
{
    private readonly ISettings _settings;

    public SaveNoteVm(IApiService apiService, ISettings settings, IButtonWithSpinnerVm spinnerVm) : base(apiService)
    {
        _settings = settings;
        SpinnerVm = spinnerVm;
    }

    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public IButtonWithSpinnerVm SpinnerVm { get; set; }

    public async Task<int> SaveNoteAsync() => 
        await TryCatchAsync(async () =>
            {
                SpinnerVm.IsBusy = true;
                var command = this.MapTo(_settings);
                ValidateNote(command);
                var result = await _apiService.SaveNoteAsync(command);
                SpinnerVm.IsBusy = false;
                return result;
            });
}
