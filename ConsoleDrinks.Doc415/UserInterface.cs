using ConsoleDrinks.Doc415.Models;
using Spectre.Console;

namespace ConsoleDrinks.Doc415
{
    internal class UserInterface
    {
        static DataAccess dataaccess = new();
        static List<Category> categories;
        static List<string> categorySelections;

        public async Task GetCategoriesFromApi()
        {
            categories = await dataaccess.GetCategories();
            categorySelections = categories.Select(x => x.strCategory).ToList();
        }

        public async Task<List<string>> GetDrinkListFromApi(string _category)
        {
            var drinkList = await dataaccess.GetDrinksFromCategory(_category);
            var drinkListSelections = drinkList.Select(x => x.strDrink).ToList();
            return drinkListSelections;
        }
        public async Task MainMenu()
        {
            Task.Run(() => GetCategoriesFromApi()).Wait();
            while (true)
            {
                AnsiConsole.Write(new FigletText("Drinks").Color(Color.CadetBlue));
                string selectedCategory = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                            .Title("Select category")
                                            .AddChoices(categorySelections));
                await Task.Run(() => CategoryMenu(selectedCategory));
            }
        }

        public async Task CategoryMenu(string _category)
        {
            var drinkList = await dataaccess.GetDrinksFromCategory(_category);
            var drinkSelections = drinkList.Select(x => x.strDrink).ToList();
            string selectedDrink = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                            .Title($"Select drink from Category: {_category}")
                                            .AddChoices(drinkSelections));
            var drink = drinkList.Single(x => x.strDrink == selectedDrink);

            await Task.Run(() => DisplaySelectedDrink(drink.idDrink));
            Console.Clear();
        }

        public async Task DisplaySelectedDrink(string _selectedDrink)
        {
            Drink drink = await dataaccess.GetDrinkInformation(_selectedDrink);
            List<string> ingredients = new();

            for (int i = 1; i < 16; i++)  //iterate through ingredients to get non null ones
            {
                string property = $"strIngredient{i}";
                var ingredientValue = drink.GetType().GetProperty(property)?.GetValue(drink, null);
                if (ingredientValue != null)
                    ingredients.Add(ingredientValue.ToString());
            }

            string drinkIngredients = string.Join(",", ingredients);

            var layout = new Layout("Root")
             .SplitRows(
               new Layout("Top"),
               new Layout("Bottom").
                  SplitRows(
                   new Layout("Up"),
                   new Layout("Down")));

            layout["Top"].Update(
             new Panel(
                 Align.Center(
                     new FigletText($"{drink.strDrink}").Color(Spectre.Console.Color.Aquamarine1),
                     VerticalAlignment.Middle))
                 .Expand());
            layout.GetLayout("Up").Update(
             new Panel(
                 Align.Left(new Markup($"[Purple]Served in:[/] [mistyrose3]{drink.strGlass}[/]\n" +
                                       $"[Purple]Alcohol:[/] [mistyrose3]{drink.strAlcoholic}[/]\n" +
                                       $"[Purple]Ingredients:[/] [mistyrose3]{drinkIngredients}[/]\n" +
                                       $"[Purple]Preparation:[/] [mistyrose3]{drink.strInstructions}[/] "))));
            layout.GetLayout("Down").Update(
                new Panel(
                    Align.Center(new Markup("[mistyrose3]Press Enter to continue...[/]"))));
            AnsiConsole.Write(layout);
            Console.ReadLine();
            Console.Clear();
        }
    }
}
