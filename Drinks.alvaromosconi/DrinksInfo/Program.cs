using DrinksInfo.API;
using DrinksInfo.Controllers;
using DrinksInfo.UI;
using Microsoft.Extensions.DependencyInjection;

void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IDrinksInfoClient, DrinksInfoClient>();
    services.AddSingleton<IDrinksController, DrinksController>();
    services.AddSingleton<UserInteface>();
    services.AddHttpClient("Drinks", client =>
    {
        client.BaseAddress = new Uri("http://www.thecocktaildb.com/api/json/v1/1/");
    });
}

IServiceCollection _services = new ServiceCollection();
ConfigureServices(_services);
IServiceProvider builder = _services.BuildServiceProvider();

async Task InitializeUI()
{
    await builder.GetService<UserInteface>().Start();
}

await InitializeUI();
