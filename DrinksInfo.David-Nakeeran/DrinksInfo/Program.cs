using DrinksInfo.Controllers;
using DrinksInfo.Coordinators;
using DrinksInfo.Utilities;
using DrinksInfo.Views;
using Microsoft.Extensions.DependencyInjection;

namespace DrinksInfo;

internal class Program
{
    static async Task Main()
    {
        var services = new ServiceCollection();

        services.AddSingleton<MenuHandler>();
        services.AddSingleton<DrinksControllers>();
        services.AddSingleton<DrinksService>();
        services.AddSingleton<FindMatching>();
        services.AddSingleton<GetObjectPropertyValues>();
        services.AddSingleton<Validation>();
        services.AddSingleton<AppCoordinator>();

        var serviceProvider = services.BuildServiceProvider();

        await serviceProvider.GetRequiredService<AppCoordinator>().Start();

    }
}

