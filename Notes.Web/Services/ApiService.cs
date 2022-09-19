using Notes.Web.Services.Interfaces;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using Blazored.LocalStorage;
using Notes.Web.Models.Constants;
using System.Net;
using Microsoft.AspNetCore.Components;

namespace Notes.Web.Services;

public class ApiService : IApiService
{
    private const string MediaType = "application/json";
    private readonly HttpClient _client;
    private readonly ILocalStorageService _localStorage;
    private readonly NavigationManager _navManager;

    public ApiService(HttpClient client, ILocalStorageService localStorage,
        NavigationManager navManager)
    {
        _client = client;
        _localStorage = localStorage;
        _navManager = navManager;
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest? requestBody, string url,
        bool autherize = true)
    {

        var request = HttpRequest(url, requestBody, HttpMethod.Post);
        await Autherize(autherize);
        var httpResponse = await _client.SendAsync(request);
        Validate(httpResponse);
        var content = await httpResponse.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<TResponse>(content, Options());

        if (response is null) throw new NullReferenceException();

        return response;
    }


    public async Task PostAsync<TRequest>(TRequest? requestBody, string url,
        bool autherize = true)
    {
        var request = HttpRequest(url, requestBody, HttpMethod.Post);
        await Autherize(autherize);
        var response = await _client.SendAsync(request);
        Validate(response);
    }


    public async Task<TResponse> PutAsync<TRequest, TResponse>(TRequest requestBody, string url,
        bool autherize = true)
    {
        var request = HttpRequest(url, requestBody, HttpMethod.Put);
        await Autherize(autherize);
        var httpResponse = await _client.SendAsync(request);
        httpResponse.EnsureSuccessStatusCode();

        var content = await httpResponse.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<TResponse>(content, Options());

        Validate(httpResponse);

        if (response is null) throw new NullReferenceException();

        return response;
    }

    public async Task PutAsync<TRequest>(TRequest? requestBody, string url, bool autherize = true)
    {

        var request = HttpRequest(url, requestBody, HttpMethod.Put);
        await Autherize(autherize);
        var httpResponse = await _client.SendAsync(request);
        Validate(httpResponse);
    }

    public async Task DeleteAsync(int id, string url, bool autherize = true)
    {

        string requestUri = $"{url}/{id}";
        var request = new HttpRequestMessage(HttpMethod.Delete, requestUri);
        await Autherize(autherize);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
        var response = await _client.SendAsync(request);
        Validate(response);
    }

    public async Task<TResponse?> GetAsync<TResponse>(string url, bool autherize = true)
    {
        await Autherize(autherize);
        var httpResponse = await _client.GetAsync(url);
        Validate(httpResponse);
        var content = await httpResponse.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<TResponse>(content, Options());
        return response;
    }

    private static HttpRequestMessage HttpRequest<TRequest>(string url, TRequest requestBody, HttpMethod method)
    {
        var serializedRequest = JsonSerializer.Serialize(requestBody);
        var request = new HttpRequestMessage(method, url);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
        request.Content = new StringContent(serializedRequest, Encoding.UTF8);
        request.Content.Headers.ContentType = new MediaTypeHeaderValue(MediaType);
        return request;
    }
    private async Task Autherize(bool autherize)
    {
        if (autherize)
        {
            var token = await _localStorage.GetItemAsync<string>(LocalStorageConstants.AuthToken);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        }
    }
    private void Validate(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var statusCode = response.StatusCode;
            switch (statusCode)
            {
                case HttpStatusCode.NotFound:
                    _navManager.NavigateTo("/404");
                    break;
                case HttpStatusCode.Unauthorized:
                    _navManager.NavigateTo("/unauthorized");
                    break;
                default:
                    _navManager.NavigateTo("/500");
                    break;
            }

            throw new ApplicationException($"Reasong: {response.ReasonPhrase}");
        }
    }
    private static JsonSerializerOptions Options()
    {
        return new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }
}
