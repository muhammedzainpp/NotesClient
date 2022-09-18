using Notes.Web.Exceptions.NoteExceptions;

namespace Notes.Web.ViewModel.NoteViewModels;

public partial class SaveNoteVm
{
    private async Task<int> TryCatchAsync(Func<Task<int>> returningIntFunction)
    {
		try
		{
			return await returningIntFunction();
		}
		catch (InvalidSaveNoteCommandException exception)
		{
			throw exception switch
			{
				InvalidSaveNoteCommandException => 
					new SaveNoteCommandValidationException(exception)
			};
		}
    }
}
