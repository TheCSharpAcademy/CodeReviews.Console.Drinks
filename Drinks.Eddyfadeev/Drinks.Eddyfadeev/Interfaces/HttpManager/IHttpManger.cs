namespace Drinks.Interfaces.HttpManager;

/// <summary>
/// Represents an interface for making HTTP requests and getting responses.
/// </summary>
internal interface IHttpManger
{
    /// <summary>
    /// Retrieves a response from the API based on the given request and optional parameters.
    /// </summary>
    /// <typeparam name="TApi">The enum type representing the API endpoint.</typeparam>
    /// <param name="request">The API endpoint.</param>
    /// <param name="parameters">Optional parameters for the API request.</param>
    /// <returns>A Drinks object containing the response data from the API.</returns>
    /// <remarks>
    /// This method sends an HTTP request to the API based on the given request and parameters.
    /// It retrieves the response, reads the content, and processes it into a Drinks object.
    /// The Drinks object contains a list of Drink objects representing the response data.
    /// </remarks>
    public Models.Drinks GetResponse<TApi>(TApi request, string? parameters = null)
        where TApi : Enum;
}