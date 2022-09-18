namespace Notes.Web.Exceptions.NoteExceptions;

public class InvalidSaveNoteCommandException : Exception
{
	public InvalidSaveNoteCommandException(string parameterName, object parameterValue)
		:base($"Invalid Note error occured, " +
            $"parameter name {parameterName}" +
            $"parameter value {parameterValue}") {}
}
