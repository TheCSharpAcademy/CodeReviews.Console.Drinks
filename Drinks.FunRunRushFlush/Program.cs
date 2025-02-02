using Drinks.FunRunRushFlush.App;
using Drinks.FunRunRushFlush.App.Views;
using Drinks.FunRunRushFlush.Data;
using Drinks.FunRunRushFlush.Data.Model;
using Drinks.FunRunRushFlush.Services;
using Drinks.FunRunRushFlush.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


var host = Host.CreateDefaultBuilder(args)
   .ConfigureServices((context, services) =>
   {
      services.AddOptions<DrinksApiSettings>()
       .BindConfiguration(nameof(DrinksApiSettings))
       .Validate(settings =>
       {
           if (settings.ApiBasePath.StartsWith("https://"))
           {
               return true;
           }
           return false;
       })
       .ValidateOnStart();

       services.AddHttpClient<DrinksRequest>();
       services.AddSingleton<DrinksApp>();
       services.AddScoped<IDrinkService, DrinkService>();
       services.AddScoped<DrinksCategoryView>();

   })
    .ConfigureLogging(logger =>
    {
        logger.ClearProviders();
        logger.AddDebug();
    }).Build();



var app = host.Services.GetRequiredService<DrinksApp>();
await app.RunApp();
