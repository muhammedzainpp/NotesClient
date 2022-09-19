namespace Notes.Web.Exceptions.NoteExceptions;

public class NullSaveNoteCommandException : Exception
{
	public NullSaveNoteCommandException() 
		: base("Null Note error occured") {}
}
