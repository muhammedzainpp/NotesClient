using FluentAssertions;
using Moq;
using Notes.Web.Models.NoteModels.SaveNoteCommand;

namespace Notes.Web.Tests.Unit.Services;

public partial class NoteServiceTests
{
    [Fact]
    public async Task ShouldCreateNoteAsync()
    {
        //given
        var randomNote = CreateRandomNote();
        var inputNote = randomNote;
        var expectedNote = inputNote;

        _apiServiceMock
            .Setup(service => service.PostAsync<SaveNoteCommand, int>(It.IsAny<SaveNoteCommand>(), 
            It.IsAny<string>(), It.IsAny<bool>()))
            .Returns(Task.FromResult(inputNote.Id));

        //when

        var actualNoteId = await _service.SaveNoteAsync(inputNote);

        //then

        actualNoteId.Should().Be(expectedNote.Id);

        _apiServiceMock.Verify(service => 
            service.PostAsync<SaveNoteCommand, int>(It.IsAny<SaveNoteCommand>(),
            It.IsAny<string>(), It.IsAny<bool>()), Times.Once);

        _apiServiceMock.VerifyNoOtherCalls();
    }
}
