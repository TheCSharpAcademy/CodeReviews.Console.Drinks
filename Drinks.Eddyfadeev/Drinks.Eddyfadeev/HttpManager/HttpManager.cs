using System.Net.Http.Headers;
using Drinks.Eddyfadeev.Extensions;
using Drinks.Eddyfadeev.Interfaces.HttpManager;
using Drinks.Eddyfadeev.Interfaces.Resolvers;
using Drinks.Eddyfadeev.Models;

namespace Drinks.Eddyfadeev.HttpManager;

/// <summary>
/// The HttpManager class is responsible for making HTTP requests and getting responses.
/// </summary>
internal class HttpManager : IHttpManger
{
    private const string AcceptHeader = "application/json";
    private readonly IUriResolver _uriResolver;

    public HttpManager(IUriResolver uriResolver)
    {
        _uriResolver = uriResolver;
    }

    /// <summary>
    /// Retrieves the response for the HTTP request based on the provided API endpoint and parameters.
    /// </summary>
    /// <typeparam name="TApi">The type of the API endpoint.</typeparam>
    /// <param name="request">The API endpoint request.</param>
    /// <param name="parameters">Optional parameters for the request.</param>
    /// <returns>The response data wrapped in a <see cref="Drinks"/> object.</returns>
    public Models.Drinks GetResponse<TApi>(TApi request, string? parameters = null) 
        where TApi : Enum
    {
        var uri = _uriResolver.ResolveUri(request, parameters);
        using var client = CreateHttpClient();

        var response = client.GetAsync(uri).Result;
        EnsureSuccessStatusCode(response);
        
        var content = response.Content.ReadAsStringAsync().Result;
        return ProcessResponseContent(content);
    }

    private static HttpClient CreateHttpClient()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(SetAcceptHeader());
        return client;
    }
    
    private static MediaTypeWithQualityHeaderValue SetAcceptHeader() => 
        new(AcceptHeader);
    
    private static void EnsureSuccessStatusCode(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }
    }
    
    private static Models.Drinks ProcessResponseContent(string content)
    {
        return content.ConvertToDrinksList();
    }
}