using Notes.Web.Models.LabelModels.Commands;
using Notes.Web.Models.LabelModels.Queries;
using Notes.Web.Services.Interfaces;

namespace Notes.Web.Services;

public class LabelService : ILabelService
{
    private readonly IApiService _apiService;

    public LabelService(IApiService apiService) => _apiService = apiService;

    public async Task<int> SaveLabelAsync(SaveLabelCommand request)
    {
        var url = "label";
        var response = await _apiService.PostAsync<SaveLabelCommand, int>(request, url);
        return response;
    }

    public async Task DeleteLabelAsync(int id)
    {
        var url = $"label/{id}";
        await _apiService.DeleteAsync(id, url);
    }

    public async Task<GetLabelQueryDto?> GetLabelAsync(int id)
    {
        var url = $"label/{id}";
        var response = await _apiService.GetAsync<GetLabelQueryDto>(url);
        return response;
    }

    public async Task<GetLabelsQueryDto?> GetLabelsAsync()
    {
        var url = "labels";
        var response = await _apiService.GetAsync<GetLabelsQueryDto?>(url);
        return response;
    }
}
