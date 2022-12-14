using Microsoft.AspNetCore.Components;
using Notes.Web.ViewModels.NoteViewModels.Interfaces;

namespace Notes.Web.Views.NoteViews;

public partial class SaveNoteView
{
    [Inject]
    public ISaveNoteVm Vm { get; set; } = default!;
}
