using Notes.Web.Models.NoteModels.GetNotesQuery;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.NoteViewModels.Interfaces;

namespace Notes.Web.ViewModel.NoteViewModels;

public class ListNoteVm : IListNoteVm
{
    private readonly INoteService _service;
    public ListNoteVm(INoteService service) => _service = service;

    public IEnumerable<GetNotesDto>? Notes { get; set; }

    public async Task GetNotesAsync() => 
        Notes = await _service.GetNotesAsync();
}
