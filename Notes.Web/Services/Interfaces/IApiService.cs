namespace Notes.Web.Services.Interfaces;

public interface IApiService
{
    Task DeleteAsync(int id, string url, bool autherize = true);
    Task<TResponse?> GetAsync<TResponse>(string url, bool autherize = true);
    Task<TResponse> PostAsync<TRequest, TResponse>(TRequest? requestBody, string url, bool autherize = true);
    Task PostAsync<TRequest>(TRequest? requestBody, string url, bool autherize = true);
    Task<TResponse> PutAsync<TRequest, TResponse>(TRequest requestBody, string url, bool autherize = true);
    Task PutAsync<TRequest>(TRequest? requestBody, string url, bool autherize = true);
}
