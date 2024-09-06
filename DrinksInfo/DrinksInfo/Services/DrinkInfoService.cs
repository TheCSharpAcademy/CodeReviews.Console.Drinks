using CodingTracker;
using Spectre.Console;

namespace DrinksInfo;

public static class DrinkInfoService
{
    public static async Task ShowDrinkInfo(string drinkId)
    {
        AnsiConsole.Clear();
        var info = await DrinkInfoController.GetDrinkInfo(drinkId);
        OutputRenderer.ShowPanel<DrinkProperties>(info.Info.FirstOrDefault(), "Drink Info");
        Console.Write("Press a key to continue...");
        Console.ReadKey();
    }
}