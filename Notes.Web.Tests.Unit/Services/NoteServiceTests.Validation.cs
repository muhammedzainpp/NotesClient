using Moq;
using Notes.Web.Dtos.Notes.SaveNoteCommand;
using Notes.Web.Exceptions.NoteExceptions;

namespace Notes.Web.Tests.Unit.Services;

public partial class NoteServiceTests
{
    [Fact]
    public async Task ShouldThrowValidationExceptionOnSaveNoteIfTitleIsNullAsync()
    {
        //given
        var randomNote = CreateRandomNote();
        randomNote.Title = string.Empty;
        var invalidNote = randomNote;

        var invalidNoteException = new InvalidSaveNoteCommandException(
            parameterName: nameof(SaveNoteCommand.Title),
            parameterValue: invalidNote.Title);

        var expectedNoteValidationException = new SaveNoteCommandValidationException(invalidNoteException);

        //when
        var saveNoteTask = _service.SaveNoteAsync(invalidNote);

        //then
        await Assert.ThrowsAsync<SaveNoteCommandValidationException>(() => saveNoteTask);

        _apiServiceMock.Verify(service =>
            service.PostAsync<SaveNoteCommand, int>(It.IsAny<SaveNoteCommand>(), 
            It.IsAny<string>(), It.IsAny<bool>()), Times.Never);

        _apiServiceMock.VerifyNoOtherCalls();
    }
}
