using Notes.Web.ViewModels.ButtonWithSpinnerViewModels;

namespace Notes.Web.ViewModels.NoteViewModels.Interfaces;

public interface ISaveNoteVm
{
    int Id { get; set; }
    string Title { get; set; }
    string? Description { get; set; }
    IButtonWithSpinnerVm SpinnerVm { get; set; }

    Task<int> SaveNoteAsync();
}
