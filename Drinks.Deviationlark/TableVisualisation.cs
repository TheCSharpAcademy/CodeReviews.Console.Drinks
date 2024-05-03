using Spectre.Console;

namespace DrinksInfo
{
    public class TableVisualisation
    {
        public static void ShowCategories(List<Category> categories)
        {
            Table table = new Table();

            table.AddColumn("Id");
            table.AddColumn("Categories");
            int id = 0;

            foreach (var category in categories)
            {
                table.AddRow(id.ToString(), category.strCategory);
                id++;
            }
            table.AddRow(id.ToString(), "FavoriteDrinks");
            AnsiConsole.Write(table);
        }

        public static void ShowDrinks(List<Drink> drinks)
        {
            Table table = new();
            table.AddColumn("Id");
            table.AddColumn("Drinks");

            foreach (var drink in drinks)
            {
                table.AddRow(drink.idDrink, drink.strDrink);
            }

            AnsiConsole.Write(table);
        }

        internal static void ShowDrinkDetail(DrinkDetail drinkDetails)
        {
            UserInput menu = new();
            DrinkDetail drinkDetail = new();
            Table table = new();
            var name = drinkDetails.strDrink;
            var alcoholic = drinkDetails.strAlcoholic;
            var glass = drinkDetails.strGlass;
            var instructions = drinkDetails.strInstructions;
            var ingredientsList = drinkDetails.GetIngredients();
            string ingredients = "";
            int num = 1;
            foreach (var ingredient in ingredientsList)
            {
                ingredients += ingredient;
                if (num < ingredientsList.Count) ingredients += ",";
                num++;
            }

            table.AddColumns("Name", "Alcoholic", "Glass", "Ingredients", "Instructions");

            table.AddRow(name, alcoholic, glass, ingredients, instructions);

            AnsiConsole.Write(table);
        }

        internal static void ShowFavoriteDrinks(List<DrinkDB> favDrinks)
        {
            Table table = new();

            table.AddColumn("Id");
            table.AddColumn("Category");
            table.AddColumn("Name");

            foreach (var drink in favDrinks)
            {
                table.AddRow(drink.Id, drink.Category, drink.Name);
            }

            AnsiConsole.Write(table);
        }
    }
}