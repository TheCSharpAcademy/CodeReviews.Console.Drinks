using Drinks.iamnikitakostin.Controllers;
using Drinks.iamnikitakostin.Data;
using Drinks.iamnikitakostin.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Drinks.iamnikitakostin;

internal class Program : ConsoleController
{
    static void Main(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        string? connectionString = config["ConnectionStrings:DefaultConnection"];
        if (connectionString == null) {
            ErrorMessage("Dear user, please ensure that you have your connection string set up in the appsettings.json.");
            return;
        }

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer(connectionString);

        using var context = new DataContext(optionsBuilder.Options);
        context.Database.Migrate();

        var drinkService = new Services.DrinkService(context);

        UserInterface userInterface = new(drinkService);

        bool isContinued = true;

        while (isContinued)
        {
            isContinued = userInterface.ShowMainMenu();
        }
    }
}