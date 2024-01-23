using System.Reflection.Metadata.Ecma335;

namespace DrinksInfo;

internal class Program
{
    static async Task Main(string[] args)
    {
        bool endApplication = false;

        while (!endApplication)
        {
            var category = await UserInput.GetCategoryInput();

            if (category == "0")
            {
                endApplication = true;
                continue;
            }

            var drink = await UserInput.GetDrinkInput(category);

            if (drink == "0")
            {
                continue;
            }

            await DrinkService.GetDrink(drink);

            await Console.Out.WriteLineAsync("Enter any key to continue:");
            Console.ReadKey();
        }
    }
}
