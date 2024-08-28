namespace Drinks.Interfaces.Resolvers;

/// <summary>
/// Provides the interface for resolving URI for API endpoints.
/// </summary>
internal interface IUriResolver
{
    /// <summary>
    /// Resolves the URI for a specific API endpoint and optional parameter.
    /// </summary>
    /// <typeparam name="TApi">The API endpoint enum.</typeparam>
    /// <param name="endpoint">The API endpoint.</param>
    /// <param name="parameter">The optional parameter.</param>
    /// <returns>The URI for the API endpoint.</returns>
    public Uri ResolveUri<TApi>(TApi endpoint, string? parameter = null) 
        where TApi : Enum;
}