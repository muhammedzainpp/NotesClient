using Notes.Web.Models.LabelModels.Commands;
using Notes.Web.Models.LabelModels.Queries;

namespace Notes.Web.Services.Interfaces;

public interface ILabelService
{
    Task DeleteLabelAsync(int id);
    Task<GetLabelQueryDto?> GetLabelAsync(int id);
    Task<GetLabelsQueryDto?> GetLabelsAsync();
    Task<int> SaveLabelAsync(SaveLabelCommand request);
}