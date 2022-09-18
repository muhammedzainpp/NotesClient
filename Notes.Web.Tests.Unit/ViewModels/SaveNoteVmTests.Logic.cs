using FluentAssertions;
using Moq;
using Notes.Web.Dtos.Notes.SaveNoteCommand;

namespace Notes.Web.Tests.Unit.ViewModels;

public partial class SaveNoteVmTests
{
    [Fact]
    public async Task ShouldCreateNoteAsync()
    {
        //given
        var randomNote = CreateRandomNote();
        var inputNote = randomNote;
        var expectedNote = inputNote;

        _settingsMock
            .SetupGet(setting => setting.UserId)
            .Returns(inputNote.Id);

        _vm.Id = inputNote.Id;
        _vm.Title = inputNote.Title;
        _vm.Description = inputNote.Description;

        _apiServiceMock
            .Setup(service => service.SaveNoteAsync(It.IsAny<SaveNoteCommand>()))
            .Returns(Task.FromResult(inputNote.Id));

        //when

        var actualNoteId = await _vm.SaveNoteAsync();

        //then

        actualNoteId.Should().Be(expectedNote.Id);

        _apiServiceMock.Verify(service => 
            service.SaveNoteAsync(It.IsAny<SaveNoteCommand>()), Times.Once);

        _apiServiceMock.VerifyNoOtherCalls();
    }
}
