using Moq;
using Notes.Web.Models.NoteModels.SaveNoteCommand;
using Notes.Web.Services;
using Notes.Web.Services.Interfaces;
using Tynamix.ObjectFiller;

namespace Notes.Web.Tests.Unit.Services;

public partial class NoteServiceTests
{
    private readonly Mock<IApiService> _apiServiceMock;
    private readonly INoteService _service;

    public NoteServiceTests()
    {
        _apiServiceMock = new Mock<IApiService>();
        _service = new NoteService(_apiServiceMock.Object);
    }

    private static SaveNoteCommand CreateRandomNote() =>
        CreateNoteFiller().Create();

    private static Filler<SaveNoteCommand> CreateNoteFiller()
    {
        var filler = new Filler<SaveNoteCommand>();

        return filler;
    }
}
