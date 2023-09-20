namespace Drinks;

using Microsoft.Extensions.Configuration;

class Configuration
{
    IConfigurationRoot config;

    public Configuration()
    {
        config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    }

    public string? TheCocktailDbBaseUri
    {
        get
        {
            return config["TheCocktailDb:BaseUri"];
        }
    }

    public string? TheCocktailDbCategories
    {
        get
        {
            return config["TheCocktailDb:Categories"];
        }
    }

    public string? TheCocktailDbDrinksByCategory
    {
        get
        {
            return config["TheCocktailDb:DrinksByCategory"];
        }
    }

    public string? TheCocktailDbDrinkById
    {
        get
        {
            return config["TheCocktailDb:DrinkById"];
        }
    }
}