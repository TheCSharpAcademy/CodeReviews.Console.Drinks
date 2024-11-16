using Drinks.TwilightSaw.Controller;
using Drinks.TwilightSaw.Helpers;
using Spectre.Console;

namespace Drinks.TwilightSaw.View;

public class Menu(DrinksController controller)
{
    public async Task MainMenu()
    {
        var t = await controller.GetDrinkTypeList();
        var x = new List<string>();
        foreach (var r in t)
            x.Add(r.strCategory);
        var end = false;
        while (!end)
        {
            var userInput = UserInput.CreateChoosingList(x);
            if (userInput == "Return") break;
            var l = await controller.GetDrinkList(userInput);
            var x1 = new List<string>();
            foreach (var r in l)
                x1.Add(r.strDrink);
            var userDrinksInput = UserInput.CreateChoosingList(x1);
            if (userDrinksInput == "Return") break;
            var b = await controller.GetDrinkFullList(userDrinksInput);
            var b1 = await controller.GetDrinkFullListId(b[0].idDrink);
            var table = new Table();
            table.AddColumns(["Name", "Category", "Instructions", "Ingredients"])
                .Centered();

            foreach (var r in b1)
                table.AddRow(@$"{r.strDrink}", $"{r.strCategory}", $"{r.strInstructions}", $"{r.strIngredient1} + {r.strIngredient2} + {r.strIngredient3} + {r.strIngredient4} + {r.strIngredient5}");

            AnsiConsole.Write(table);
            Console.ReadKey(false);
            Console.Clear();
        }
    }
}