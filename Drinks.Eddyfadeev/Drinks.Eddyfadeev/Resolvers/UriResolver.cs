using Drinks.Interfaces.Mappers;
using Drinks.Interfaces.Resolvers;
using Drinks.Models;
using Drinks.View;
using Microsoft.Extensions.Options;

namespace Drinks.Resolvers;

/// <summary>
/// The UriResolver class is responsible for resolving URIs for API endpoints.
/// </summary>
internal class UriResolver : IUriResolver
{
    private readonly IApiEndpointMapper _apiEndpointMapper;
    private readonly string _baseUrl;

    public UriResolver(IApiEndpointMapper apiEndpointMapper, IOptions<ApiConfig> apiConfig)
    {
        _apiEndpointMapper = apiEndpointMapper ?? throw new ArgumentNullException(nameof(apiEndpointMapper));
        _baseUrl = apiConfig.Value.BaseUrl ?? throw new ArgumentException(Messages.ApiConfigurationError);
    }

    /// <summary>
    /// Resolves the URI for an API endpoint.
    /// </summary>
    /// <typeparam name="TApi">The type of the API endpoint.</typeparam>
    /// <param name="endpoint">The API endpoint.</param>
    /// <param name="parameter">The optional parameter to append to the URI.</param>
    /// <returns>The resolved URI for the API endpoint.</returns>
    public Uri ResolveUri<TApi>(TApi endpoint, string? parameter = null) 
        where TApi : Enum
    {
        string relativePath = _apiEndpointMapper.GetRelativePath(endpoint);
        
        if (!string.IsNullOrEmpty(parameter))
        {
            relativePath = string.Concat(relativePath, parameter);
        }

        return new Uri($"{_baseUrl}{relativePath}");
    }
}