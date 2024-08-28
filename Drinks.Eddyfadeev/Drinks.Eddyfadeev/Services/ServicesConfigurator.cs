using Drinks.Eddyfadeev.Enums;
using Drinks.Eddyfadeev.Handlers;
using Drinks.Eddyfadeev.Interfaces.Handlers;
using Drinks.Eddyfadeev.Interfaces.HttpManager;
using Drinks.Eddyfadeev.Interfaces.Mappers;
using Drinks.Eddyfadeev.Interfaces.Resolvers;
using Drinks.Eddyfadeev.Interfaces.View;
using Drinks.Eddyfadeev.Interfaces.View.Factory;
using Drinks.Eddyfadeev.Mappers;
using Drinks.Eddyfadeev.Models;
using Drinks.Eddyfadeev.Resolvers;
using Drinks.Eddyfadeev.View;
using Drinks.Eddyfadeev.View.Factory;
using Drinks.Eddyfadeev.View.Factory.Initializers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Drinks.Eddyfadeev.Services;

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