using Notes.Web.Models;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.Base;
using Notes.Web.ViewModel.NoteViewModels.Interfaces;

namespace Notes.Web.ViewModel.NoteViewModels;

public partial class SaveNoteVm : BaseVm, ISaveNoteVm
{
    private readonly ISettings _settings;

    public SaveNoteVm(IApiService apiService, ISettings settings) : base(apiService) => 
        _settings = settings;

    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }

    public async Task<int> SaveNoteAsync() => 
        await TryCatchAsync(async () =>
            {
                var command = this.MapTo(_settings);
                ValidateNote(command);
                var result = await _apiService.SaveNoteAsync(command);
                return result;
            });
}
