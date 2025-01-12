using Drinks.AshtonLeeSeloka.Repositories;
using System.Collections.Specialized;
using System.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;
namespace Drinks.AshtonLeeSeloka.Services;

public class DrinksService()
{

	public async Task<List<Categories>> GetCategories(HttpClient client) 
	{
		string? _categories = ConfigurationManager.AppSettings.Get("Categories");
		await using Stream stream =
			await client.GetStreamAsync(_categories);
		var repositories =
			await JsonSerializer.DeserializeAsync<List<Categories>>(stream);
		Console.WriteLine(repositories);
		return repositories ?? new();
	}
}
