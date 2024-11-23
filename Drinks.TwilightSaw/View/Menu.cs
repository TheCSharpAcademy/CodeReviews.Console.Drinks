using Drinks.TwilightSaw.Controller;
using Drinks.TwilightSaw.Helpers;
using Drinks.TwilightSaw.Model;
using Spectre.Console;

namespace Drinks.TwilightSaw.View;

public class Menu(DrinksController controller)
{
    public async Task MainMenu()
    {
       var drinkTypeList = await controller.GetDrinkTypeList();
       while (true)
       {
            Console.Clear();
            AnsiConsole.Write(new Rule("[olive]Welcome to the Drinks![/]"));
            var userInput = UserInput.CreateChoosingList(drinkTypeList.Select(drinksType => drinksType.strCategory).ToList());
            if (userInput == "Exit") break;
            var drinkList = await controller.GetDrinkList(userInput);
            while(true){
                Console.Clear();
                AnsiConsole.Write(new Rule($"[olive]{userInput}[/]"));
                var userDrinksInput = UserInput.CreateChoosingList(drinkList.Select(drinksShort => drinksShort.strDrink).ToList());
                if (userDrinksInput == "Exit") break;
                await CreateDrinkTable(userDrinksInput);
            }
       }
    }

    public string CheckIngredients(List<DrinksFull> drinkList)
    {
        string k = "";
        foreach (var ingredient in drinkList.SelectMany(drinks => drinks.ingredientsAndMeasurementsList()))
            try
            {
                if (ingredient != "")
                    k += $"{ingredient}\n";
            }
            catch (NullReferenceException)
            {
            }
        return k;
    }

    public async Task CreateDrinkTable(string userDrinksInput)
    {
        
        var drinkFullList = await controller.GetDrinkFullList(userDrinksInput);
        var drinkList = await controller.GetDrinkFullListId(drinkFullList[0].idDrink);
        
        var mainTable = new Table();
        mainTable.AddColumns(["Instructions", "Ingredients", "Type", "Glass"])
            .Centered();
        foreach (var drink in drinkList)
        {
            var ingredientList = CheckIngredients(drinkList);
            mainTable.AddRow($"{drink.strInstructions}", $"{ingredientList}", $"{drink.strAlcoholic}", $"{drink.strGlass}");
        }

        AnsiConsole.Write(new Panel(new Markup($"[seagreen1][bold]{drinkList[0].strDrink}[/][/]").Centered()).Expand());
        AnsiConsole.Write(mainTable);
        AnsiConsole.Write(new Markup("[grey]Press any key to return to previous menu.[/]").Centered());
        Console.ReadKey(false);
        Console.Clear();
    }
}