using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModel.ButtonWithSpinnerViewModel;
using Notes.Web.ViewModel.NoteViewModels.Interfaces;

namespace Notes.Web.Views.NoteViews;

public partial class SaveNoteView
{
    [Inject]
    public ISaveNoteVm Vm { get; set; } = default!;
}
