using Drinks.Enums;
using Drinks.Handlers;
using Drinks.Interfaces.Handlers;
using Drinks.Interfaces.HttpManager;
using Drinks.Interfaces.Mappers;
using Drinks.Interfaces.Resolvers;
using Drinks.Interfaces.View;
using Drinks.Interfaces.View.Factory;
using Drinks.Mappers;
using Drinks.Models;
using Drinks.Resolvers;
using Drinks.View;
using Drinks.View.Factory;
using Drinks.View.Factory.Initializers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Drinks.Services;

internal static class ServicesConfigurator
{
    private const string JsonFileName = "appsettings.json";
    public static ServiceCollection ServiceCollection { get; } = new();
    private static IConfiguration Configuration { get; }
    
    static ServicesConfigurator()
    {
        Configuration = GetConfiguration().Build();
        ConfigureServices(ServiceCollection);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.Configure<ApiConfig>(Configuration.GetSection("ApiConfig"));
        
        services.AddTransient<IMenuCommandFactory<MainMenuEntries>, MenuCommandFactory<MainMenuEntries>>();
        services.AddTransient<IMenuCommandFactory<FilterMenuEntries>, MenuCommandFactory<FilterMenuEntries>>();
        services.AddTransient<IMenuCommandFactory<SearchMenuEntries>, MenuCommandFactory<SearchMenuEntries>>();

        services.AddTransient<IMenuEntriesInitializer<MainMenuEntries>, MainMenuEntriesInitializer>();
        services.AddTransient<IMenuEntriesInitializer<FilterMenuEntries>, FilterMenuEntriesInitializer>();
        services.AddTransient<IMenuEntriesInitializer<SearchMenuEntries>, SearchMenuEntriesInitializer>();

        services.AddTransient<IMenuEntries<MainMenuEntries>, MenuEntries<MainMenuEntries>>();
        services.AddTransient<IMenuEntries<FilterMenuEntries>, MenuEntries<FilterMenuEntries>>();
        services.AddTransient<IMenuEntries<SearchMenuEntries>, MenuEntries<SearchMenuEntries>>();

        services.AddSingleton<IMenuEntriesHandler<MainMenuEntries>, MenuEntriesHandler<MainMenuEntries>>();
        services.AddSingleton<IMenuEntriesHandler<FilterMenuEntries>, MenuEntriesHandler<FilterMenuEntries>>();
        services.AddSingleton<IMenuEntriesHandler<SearchMenuEntries>, MenuEntriesHandler<SearchMenuEntries>>();
        
        services.AddTransient<IUriResolver, UriResolver>();
        services.AddTransient<IApiEndpointMapper, ApiEndpointMapper>();
        services.AddTransient<IHttpManger, HttpManager.HttpManager>();
        services.AddTransient<ITableConstructor, TableConstructor>();
    }

    private static IConfigurationBuilder GetConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile(JsonFileName, optional: false, reloadOnChange: true);

        return builder;
    }
}