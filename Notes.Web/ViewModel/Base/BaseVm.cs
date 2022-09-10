using Notes.Web.Services.Interfaces;

namespace Notes.Web.ViewModel.Base;

public class BaseVm
{
    protected readonly IApiService _apiService;

    public BaseVm(IApiService apiService) =>
        _apiService = apiService;
}
