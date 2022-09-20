using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModels.NoteViewModels.Interfaces;

namespace Notes.Web.Views.NoteViews;

public partial class ListNoteView : ComponentBase
{
    [Inject]
    public IListNoteVm Vm { get; set; } = default!;

    protected async override Task OnInitializedAsync() => 
        await Vm.GetNotesAsync();
}
