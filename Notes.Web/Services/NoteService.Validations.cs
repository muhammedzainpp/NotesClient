using Notes.Web.Dtos.Notes.SaveNoteCommand;
using Notes.Web.Exceptions.NoteExceptions;

namespace Notes.Web.Services;

public partial class NoteService
{
    private void ValidateNote(SaveNoteCommand command)
    {
        switch (command)
        {
            case null: throw new NullSaveNoteCommandException();
            case { } when IsInvalid(command.Title):
                throw new InvalidSaveNoteCommandException(parameterName:nameof(SaveNoteCommand.Title),
                    parameterValue:command.Title);
        }
    }

    private static bool IsInvalid(string title) => string.IsNullOrWhiteSpace(title);
}
