using System.Text.Json;
using Spectre.Console;
using Drinks.kwm0304.Models;
using Drinks.kwm0304.Utils;
namespace Drinks.kwm0304.Services;

public class ExternalService
{
  private readonly HttpClient _httpClient;

  public ExternalService(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  public async Task<List<T>?> GetExternalContent<T>(string api, string? input = null) where T : class
  {
    string endpoint = CleanEndpoint.GetEndpoint(api, input);
    try
    {
      var response = await _httpClient.GetAsync(endpoint);
      response.EnsureSuccessStatusCode();
      var jsonResponse = await response.Content.ReadAsStringAsync();

      var options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      };
      var deserialized = JsonSerializer.Deserialize<DrinkResponse<T>>(jsonResponse, options);

      if (deserialized == null)
      {
        AnsiConsole.WriteLine("Deserialization returned null.");
        return null;
      }
      if (deserialized.Drinks != null)
      {
        if (typeof(T) == typeof(DrinkDetail))
        {
          foreach (var drink in deserialized.Drinks)
          {
            DrinkDetailProcessor.ProcessDrinkDetail(drink! as DrinkDetail ?? new());
          }
        }
        return deserialized.Drinks;
      }
      else
      {
        AnsiConsole.WriteLine("Response was null");
        return null;
      }
    }
    catch (Exception e)
    {
      AnsiConsole.WriteException(e);
      throw;
    }
  }
}