using Notes.Web.Services.Interfaces;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using System;
using System.Net.Http.Json;
using Blazored.LocalStorage;

namespace Notes.Web.Services;

public partial class ApiService : IApiService
{
    private const string MediaType = "application/json";
    private readonly HttpClient _client;
    private readonly ILocalStorageService _localStorage;

    public ApiService(HttpClient client, ILocalStorageService localStorage)
    {
        _client = client;
        _localStorage = localStorage;
    }

    private async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest? requestBody, string url, bool autherize = true)
    {
        try
        {
            var request = GetHttpRequest(url, requestBody, HttpMethod.Post);

            if (autherize)
            {
                var token = await _localStorage.GetItemAsync<string>("authToken");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
            var httpResponse = await _client.SendAsync(request);
            httpResponse.EnsureSuccessStatusCode();
            var content = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<TResponse>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (response is null) throw new NullReferenceException();

            return response;
        }
        catch (Exception e)
        {

            throw;
        }
    }


    private async Task PostAsync<TRequest>(TRequest? requestBody, string url)
    {
        try
        {
            var request = GetHttpRequest(url, requestBody, HttpMethod.Post);
            var httpResponse = await _client.SendAsync(request);
            httpResponse.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<TResponse> PutAsync<TRequest, TResponse>(TRequest requestBody, string url)
    {
        try
        {
            var request = GetHttpRequest(url, requestBody, HttpMethod.Put);
            var httpResponse = await _client.SendAsync(request);
            httpResponse.EnsureSuccessStatusCode();

            var content = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<TResponse>(content);

            if (response is null) throw new NullReferenceException();

            return response;
        }
        catch (Exception)
        {

            throw;
        }
    }

    private async Task PutAsync<TRequest>(TRequest? requestBody, string url)
    {
        try
        {
            var request = GetHttpRequest(url, requestBody, HttpMethod.Put);
            var httpResponse = await _client.SendAsync(request);
            httpResponse.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {

            throw;
        }
    }

    private async Task DeleteAsync(int id, string url)
    {
        try
        {
            string requestUri = $"{url}/{id}";
            var request = new HttpRequestMessage(HttpMethod.Delete, requestUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {

            throw;
        }
    }

    private async Task<TResponse?> GetAsync<TResponse>(string url)
    {
        var response = await _client.GetFromJsonAsync<TResponse>(url);
        return response;
    }

    private static HttpRequestMessage GetHttpRequest<TRequest>(string url, TRequest requestBody, HttpMethod method)
    {
        var serializedRequest = JsonSerializer.Serialize(requestBody);
        var request = new HttpRequestMessage(method, url);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
        request.Content = new StringContent(serializedRequest, Encoding.UTF8);
        request.Content.Headers.ContentType = new MediaTypeHeaderValue(MediaType);
        return request;
    }
}
