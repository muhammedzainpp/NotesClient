namespace Notes.Web.Exceptions.NoteExceptions;

public class SaveNoteCommandValidationException : Exception
{
	public SaveNoteCommandValidationException(Exception innerException)
		:base("Note validation error occured, try again", innerException)
	{}
}
