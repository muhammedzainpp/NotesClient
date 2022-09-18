using Moq;
using Notes.Web.Dtos.Notes.SaveNoteCommand;
using Notes.Web.Models;
using Notes.Web.Services.Interfaces;
using Notes.Web.ViewModel.NoteViewModels;
using Notes.Web.ViewModel.NoteViewModels.Interfaces;
using Tynamix.ObjectFiller;

namespace Notes.Web.Tests.Unit.ViewModels;

public partial class SaveNoteVmTests
{
    private readonly Mock<IApiService> _apiServiceMock;
    private readonly Mock<ISettings> _settingsMock;
    private readonly ISaveNoteVm _vm;

    public SaveNoteVmTests()
    {
        _apiServiceMock = new Mock<IApiService>();
        _settingsMock = new Mock<ISettings>();
        _vm = new SaveNoteVm(_apiServiceMock.Object, _settingsMock.Object);
    }

    private static SaveNoteCommand CreateRandomNote() =>
        CreateNoteFiller().Create();

    private static Filler<SaveNoteCommand> CreateNoteFiller()
    {
        var filler = new Filler<SaveNoteCommand>();

        return filler;
    }
}
