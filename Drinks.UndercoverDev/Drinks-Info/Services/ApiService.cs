using System.Net;
using Drinks_Info.Models;
using Newtonsoft.Json;

namespace Drinks_Info.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;

        public ApiService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                var response = await _client.GetStringAsync("http://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
                var drinksCategory = JsonConvert.DeserializeObject<Categories>(response);

                return drinksCategory?.CategoriesList ?? [];
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Forbidden)
            {
                Console.WriteLine($"API access forbidden: {ex.Message}");
                return [];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting categories: {ex.Message}");
                return [];
            }
        }
    }
}

//         public async Task<List<Category>> GetCategoriesAsync()
// {
//     try
//     {
//         Console.WriteLine("Sending request to API...");
//         var response = await _client.GetStringAsync("http://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
//         Console.WriteLine("Response received from API.");
        
//         var drinksCategory = JsonConvert.DeserializeObject<Categories>(response);
//         Console.WriteLine("Deserialization complete.");

//         if (drinksCategory?.CategoriesList != null)
//         {
//             Console.WriteLine($"Deserialized {drinksCategory.CategoriesList.Count} categories.");
//         }
//         else
//         {
//             Console.WriteLine("No categories found.");
//         }

//         return drinksCategory?.CategoriesList ?? [];
//     }
//     catch (HttpRequestException ex)
//     {
//         Console.WriteLine($"HttpRequestException occurred: {ex.Message}");
//         if (ex.StatusCode.HasValue)
//         {
//             Console.WriteLine($"Status code: {ex.StatusCode}");
//         }
//         return [];
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine($"Error getting categories: {ex.Message}");
//         return [];
//     }
// }

//     }
// }