using Notes.Web.Exceptions.NoteExceptions;

namespace Notes.Web.Services;

public partial class NoteService
{
    private static async Task<int> TryCatchAsync(Func<Task<int>> returningIntFunction)
    {
		try
		{
			return await returningIntFunction();
		}
		catch (Exception exception)
		{
			throw exception switch
			{
				NullSaveNoteCommandException => 
					new SaveNoteCommandValidationException(exception),

				InvalidSaveNoteCommandException => 
					new SaveNoteCommandValidationException(exception),

					_ => new Exception()
			};
		}
    }
}
