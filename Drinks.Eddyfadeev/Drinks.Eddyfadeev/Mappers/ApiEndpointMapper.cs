using Drinks.Eddyfadeev.Enums;
using Drinks.Eddyfadeev.Interfaces.Mappers;
using Drinks.Eddyfadeev.Models;
using Drinks.Eddyfadeev.View;
using Microsoft.Extensions.Options;

namespace Drinks.Eddyfadeev.Mappers;

/// <summary>
/// Represents a mapper that provides methods to map API endpoints to their relative paths.
/// </summary>
internal class ApiEndpointMapper : IApiEndpointMapper
{
    private const string RandomCocktail = "RandomCocktail";
    private readonly ApiConfig _apiConfig;
    private readonly Dictionary<Type, Dictionary<string, string>> _endpoints;
    
    public ApiEndpointMapper(IOptions<ApiConfig> apiConfig)
    {
        _apiConfig = apiConfig.Value ?? 
                     throw new ArgumentNullException(nameof(apiConfig), Messages.ApiConfigurationError);
        _endpoints = InitializeEndpoints();
    }

    /// <summary>
    /// Gets the relative path of an API endpoint.
    /// </summary>
    /// <typeparam name="TApi">The type of the API endpoint.</typeparam>
    /// <param name="endpoint">The API endpoint.</param>
    /// <returns>The relative path of the API endpoint.</returns>
    public string GetRelativePath<TApi>(TApi endpoint) where TApi : Enum
    {
        if (!_endpoints.TryGetValue(endpoint.GetType(), out var resultEndpoint))
        {
            throw new ArgumentOutOfRangeException(
                nameof(endpoint), 
                $"[red]No endpoints found for type '{endpoint.GetType().Name}'[/]"
            );
        }

        return GetEndpointPath(resultEndpoint, endpoint.ToString()!);
    }

    private Dictionary<Type, Dictionary<string, string>> InitializeEndpoints() =>
        new()
        {
            { typeof(ApiEndpoints.Lists), _apiConfig.Lists },
            { typeof(ApiEndpoints.Search), _apiConfig.Search },
            { typeof(ApiEndpoints.Filter), _apiConfig.Filter },
            { 
                typeof(ApiEndpoints.Random), 
                new Dictionary<string, string> {
                    {
                        RandomCocktail, _apiConfig.RandomCocktail! 
                    } 
                } 
            }
        };
    
    private static string GetEndpointPath(Dictionary<string, string> endpoints, string key)
    {
        if (endpoints.TryGetValue(key, out string path))
        {
            return path;
        }
        throw new ArgumentException($"[red]Endpoint path for '{key}' not found in the configuration![/]");
    }
}