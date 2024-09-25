using drinksLibrary;
using drinksLibrary.Models;
using Spectre.Console;

namespace drinks.jakubmikolajewski;

class Program
{
    static bool exit;
    public static void Main(string[] args)
    {
        while (!exit)
        {
            Console.Clear();
            MainAsync().Wait();
            exit = UserInput.ChooseToExit();
        }    
    }
    static async Task MainAsync()
    {
        try
        {
            string category = await UserInput.ChooseCategory();
            (int drinkId, string drinkChoice) = await UserInput.ChooseDrink(category);
            DrinkDetailObject details = await UserInput.ShowDrinkDetails(drinkId);
            TableVisualizationEngine.ShowTable(details.DrinkDetailList, drinkChoice);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
        }       
    }   
}

