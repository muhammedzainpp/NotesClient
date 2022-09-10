﻿using Notes.Web.Services.Interfaces;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace Notes.Web.Services;

public partial class ApiService : IApiService
{
    private const string MediaType = "application/json";
    private readonly HttpClient _client;

	public ApiService(HttpClient client) => _client = client;

	private async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest requestBody, string url)
	{
        try
        {
            var serializedRequest = JsonSerializer.Serialize(requestBody);
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
            request.Content = new StringContent(serializedRequest, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(MediaType);

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

    private async Task PostAsync<TRequest>(TRequest requestBody, string url)
    {
        try
        {
            var serializedRequest = JsonSerializer.Serialize(requestBody);
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
            request.Content = new StringContent(serializedRequest, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(MediaType);

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
            var serializedRequest = JsonSerializer.Serialize(requestBody);
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
            request.Content = new StringContent(serializedRequest, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(MediaType);
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

    private async Task PutAsync<TRequest>(TRequest requestBody, string url)
    {
        try
        {
            var serializedRequest = JsonSerializer.Serialize(requestBody);
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
            request.Content = new StringContent(serializedRequest, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(MediaType);
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

}
