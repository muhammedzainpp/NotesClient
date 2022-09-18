using Moq;
using Notes.Web.Dtos.Notes.SaveNoteCommand;
using Notes.Web.Exceptions.NoteExceptions;

namespace Notes.Web.Tests.Unit.ViewModels;

public partial class SaveNoteVmTests
{
    [Fact]
    public async Task ShouldThrowValidationExceptionOnSaveNoteIfTitleIsNullAsync()
    {
        //given
        var randomNote = CreateRandomNote();
        randomNote.Title = string.Empty;
        var invalidNote = randomNote;
        _vm.Title = randomNote.Title;

        var invalidNoteException = new InvalidSaveNoteCommandException(
            parameterName: nameof(SaveNoteCommand.Title),
            parameterValue: invalidNote.Title);

        var expectedNoteValidationException = new SaveNoteCommandValidationException(invalidNoteException);
       
        //when
        var saveNoteTask = _vm.SaveNoteAsync();

        //then
        await Assert.ThrowsAsync<SaveNoteCommandValidationException>(() => saveNoteTask);

        _apiServiceMock.Verify(service => 
            service.SaveNoteAsync(It.IsAny<SaveNoteCommand>()), Times.Never);

        _apiServiceMock.VerifyNoOtherCalls();

    }
}
