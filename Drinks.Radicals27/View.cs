using Spectre.Console;

namespace cocktails
{
    class View
    {
        internal static void DisplayCategoriesMenu(List<Category> categories)
        {
            int index = 1;

            var table = new Table();
            table.AddColumn("Categories:");

            foreach (var category in categories)
            {
                table.AddRow($"{index}. {category.strCategory}");
                index++;
            }

            AnsiConsole.Write(table);
        }

        internal static void DisplayDrinksTable(List<Drink> drinks)
        {
            var table = new Table();
            table.AddColumn("Drinks:");

            foreach (Drink drink in drinks)
            {
                table.AddRow($"{drink.idDrink}. {drink.strDrink}");
            }

            AnsiConsole.Write(table);
        }

        internal static void DisplayDrinkTable(List<object> prepList, int drinkID)
        {
            var table = new Table();
            table.AddColumn($"Drink: {prepList[0].GetType().GetProperty("Value")?.GetValue(prepList[0])?.ToString()} (ID: {drinkID})");

            string ingredientLabel = "Ingredient";
            string measureLabel = "Measure";

            // Prepare pairs of ingredients and measures
            var ingredients = prepList
                .Where(p => p.GetType().GetProperty("Key")?.GetValue(p)?.ToString()?.StartsWith(ingredientLabel) ?? false)
                .ToList();
            var measures = prepList
                .Where(p => p.GetType().GetProperty("Key")?.GetValue(p)?.ToString()?.StartsWith(measureLabel) ?? false)
                .ToList();

            // Show cocktail info
            for (var i = 0; i < prepList.Count; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                var key = prepList[i].GetType().GetProperty("Key")?.GetValue(prepList[i])?.ToString();
                var value = prepList[i].GetType().GetProperty("Value")?.GetValue(prepList[i])?.ToString();

                // Ignore the ingredients and measures, we'll show them last
                if (!key.StartsWith(ingredientLabel) && !key.StartsWith(measureLabel))
                {
                    table.AddRow($"{key}: {value}");
                }
            }

            // Show ingredients and measures now
            for (int i = 0; i < ingredients.Count; i++)
            {
                var ingredient = ingredients[i].GetType().GetProperty("Value")?.GetValue(ingredients[i])?.ToString();
                var measure = i < measures.Count
                    ? measures[i].GetType().GetProperty("Value")?.GetValue(measures[i])?.ToString()
                    : null;

                if (!string.IsNullOrEmpty(ingredient))
                {
                    table.AddRow($"{ingredient}: {(!string.IsNullOrEmpty(measure) ? measure : "As needed")}");
                }
            }

            AnsiConsole.Write(table);
        }
    }
}