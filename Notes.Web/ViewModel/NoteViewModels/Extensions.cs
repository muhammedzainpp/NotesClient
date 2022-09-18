using Notes.Web.Dtos.Notes.SaveNoteCommand;
using Notes.Web.Models;
using Notes.Web.ViewModel.NoteViewModels.Interfaces;

namespace Notes.Web.ViewModel.NoteViewModels;

public static class Extensions
{
    public static SaveNoteCommand MapTo(this ISaveNoteVm vm, ISettings settings) =>
        new()
        {
            Id = vm.Id,
            Title = vm.Title,
            Description = vm.Description,
            UserId = settings.UserId
        };
}
