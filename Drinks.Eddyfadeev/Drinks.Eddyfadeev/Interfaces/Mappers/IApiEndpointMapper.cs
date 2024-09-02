using Drinks.Eddyfadeev.Enums;

namespace Drinks.Eddyfadeev.Interfaces.Mappers;

/// <summary>
/// Represents a mapper that provides methods to map API endpoints to their relative paths.
/// </summary>
internal interface IApiEndpointMapper
{
    /// <summary>
    /// Gets the relative path for the specified API endpoint.
    /// </summary>
    /// <typeparam name="TApi">The type of the API endpoint <see cref="ApiEndpoints"/></typeparam>
    /// <param name="endpoint">The API endpoint.</param>
    /// <returns>The relative path for the API endpoint.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when no endpoints are found for the specified endpoint type.</exception>
    /// <exception cref="ArgumentException">Thrown when the endpoint path is not found in the configuration.</exception>
    string GetRelativePath<TApi>(TApi endpoint) where TApi : Enum;
}