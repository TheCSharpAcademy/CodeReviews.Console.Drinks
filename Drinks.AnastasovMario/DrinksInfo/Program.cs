using DrinksInfo;
using System.Net.Http.Headers;

var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("https://thecocktaildb.com/api/json/v1/1/");
httpClient.DefaultRequestHeaders.Accept.Clear();
httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

var drinksApiClient = new DrinksApiClient(httpClient);

await drinksApiClient.GetCategories();