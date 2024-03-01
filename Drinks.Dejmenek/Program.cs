using Drinks.Dejmenek.Models;
using Spectre.Console;

namespace Drinks.Dejmenek
{
    internal class Program
    {
        private static async Task Main()
        {
            HttpDrinksClient client = new();

            List<DrinkCategory> drinksCategories = await client.GetDrinksCategoriesAsync();
            string drinkCategory = UserInteraction.GetDrinkCategory(drinksCategories);

            List<Drink> drinks = await client.GetDrinksByCategoryAsync(drinkCategory);
            string drink = UserInteraction.GetDrink(drinks);

            var drinkInfo = await client.GetDrinkInfoAsync(drink);
            var drinkProperties = drinkInfo.GetType().GetProperties();
            var values = drinkProperties.ToDictionary(prop => prop.Name, prop => prop.GetValue(drinkInfo) as string ?? "lack of data");

            var table = new Table();
            table.AddColumn("Property");
            table.AddColumn("Value");

            foreach (var kvp in values)
            {
                if (kvp.Value.Equals("lack of data")) continue;
                table.AddRow(kvp.Key, kvp.Value);
            }

            AnsiConsole.Write(table);
        }
    }
}