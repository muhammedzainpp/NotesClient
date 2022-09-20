using Notes.Web.Models.NoteModels.SaveNoteCommand;
using Notes.Web.Models.Settings;
using Notes.Web.ViewModel.NoteViewModels.Interfaces;

namespace Notes.Web.ViewModel.NoteViewModels;

public static class Extensions
{
    public static SaveNoteCommand MapTo(this ISaveNoteVm vm, ISetting settings) =>
        new()
        {
            Id = vm.Id,
            Title = vm.Title,
            Description = vm.Description,
            UserId = settings.UserId
        };
}
