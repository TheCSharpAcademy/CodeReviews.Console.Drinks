using Drinks.AshtonLeeSeloka.Repositories;
using Drinks.AshtonLeeSeloka.Services;
using System.Net.Http.Headers;

HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
	new MediaTypeWithQualityHeaderValue("application/json"));

DrinksService drinksService = new DrinksService();
var cat = drinksService.GetCategories(client);
Console.WriteLine(cat);
