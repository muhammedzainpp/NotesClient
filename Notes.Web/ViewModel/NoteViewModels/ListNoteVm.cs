using Notes.Web.Dtos.Notes.GetNotesQuery;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.Base;
using Notes.Web.ViewModel.NoteViewModels.Interfaces;

namespace Notes.Web.ViewModel.NoteViewModels;

public class ListNoteVm : BaseVm, IListNoteVm
{
    public ListNoteVm(IApiService apiService) : base(apiService)
    {}

    public IEnumerable<GetNotesDto>? Notes { get; set; }

    public async Task GetNotesAsync() => 
        Notes = await _apiService.GetNotesAsync();
}
