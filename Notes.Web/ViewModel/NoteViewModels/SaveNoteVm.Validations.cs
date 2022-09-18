using Notes.Web.Dtos.Notes.SaveNoteCommand;
using Notes.Web.Exceptions.NoteExceptions;

namespace Notes.Web.ViewModel.NoteViewModels;

public partial class SaveNoteVm
{
    private void ValidateNote(SaveNoteCommand command)
    {
        switch (command)
        {
            case { } when IsInvalid(Title):
                throw new InvalidSaveNoteCommandException(parameterName:nameof(Title),
                    parameterValue:Title);
        }
    }

    private static bool IsInvalid(string title) => string.IsNullOrWhiteSpace(title);
}
