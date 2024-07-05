using jollejonas.Drinks.Models;
using Spectre.Console;

namespace jollejonas.Drinks.Services
{
    public class DrinksService
    {
        ApiService apiService = new ApiService("https://www.thecocktaildb.com/api/json/v1/1");
        public async Task<string> SelectCategory()
        {
            var categoryList = await apiService.GetAsync<Dictionary<string, List<Category>>>("list.php?c=list");

            if (categoryList == null || !categoryList.ContainsKey("drinks") || !categoryList["drinks"].Any())
            {
                Console.WriteLine("No categories found.");
                return null;
            }

            var categories = categoryList["drinks"];

            var menuSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a category")
                    .PageSize(10)
                    .AddChoices(categories.Select(c => c.strCategory).ToArray())
            );

            return menuSelection;
        }

        public async Task<string> SelectDrink(string category)
        {
            var drinkList = await apiService.GetAsync<Dictionary<string, List<Drink>>>($"filter.php?c={category}");

            if (drinkList == null || !drinkList.ContainsKey("drinks") || !drinkList["drinks"].Any())
            {
                Console.WriteLine("No drinks found.");
                return null;
            }

            var drinks = drinkList["drinks"];

            var menuSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a drink")
                    .PageSize(10)
                    .AddChoices(drinks.Select(d => d.strDrink).ToArray())
            );

            string selectedDrinkId = drinks.First(d => d.strDrink == menuSelection).idDrink;

            return selectedDrinkId;
        }

        public async Task<Drink> GetDrink(string drinkId)
        {
            var drink = await apiService.GetAsync<Dictionary<string, List<Drink>>>($"lookup.php?i={drinkId}");

            if (drink == null || !drink.ContainsKey("drinks") || !drink["drinks"].Any())
            {
                Console.WriteLine("No drink found.");
                return null;
            }

            return drink["drinks"].First();
        }

        public void DisplayDrinkDetails(Drink drink)
        {
            if(drink == null)
            {
                Console.WriteLine("No drink found.");
                return;
            }

            AnsiConsole.MarkupLine($"[bold]{drink.strDrink}[/]");
            AnsiConsole.MarkupLine($"[bold]Category:[/] {drink.strCategory}");
            AnsiConsole.MarkupLine($"[bold]Alcoholic:[/] {drink.strAlcoholic}");
            AnsiConsole.MarkupLine($"[bold]Glass:[/] {drink.strGlass}");
            Console.WriteLine();
            AnsiConsole.MarkupLine($"[bold]Instructions:[/] {drink.strInstructions}");

            var ingredients = new[]
            {
               drink.strIngredient1,
                drink.strIngredient2,
                drink.strIngredient3,
                drink.strIngredient4,
                drink.strIngredient5,
                drink.strIngredient6,
                drink.strIngredient7,
                drink.strIngredient8,
                drink.strIngredient9,
                drink.strIngredient10,
                drink.strIngredient11,
                drink.strIngredient12,
                drink.strIngredient13,
                drink.strIngredient14,
                drink.strIngredient15
            };
        
            var measures = new[]
            {
                drink.strMeasure1,
                drink.strMeasure2,
                drink.strMeasure3,
                drink.strMeasure4,
                drink.strMeasure5,
                drink.strMeasure6,
                drink.strMeasure7,
                drink.strMeasure8,
                drink.strMeasure9,
                drink.strMeasure10,
                drink.strMeasure11,
                drink.strMeasure12,
                drink.strMeasure13,
                drink.strMeasure14,
                drink.strMeasure15
            };

            Console.WriteLine();
            AnsiConsole.MarkupLine("[bold]Ingredients:[/]");
            for (int i = 0; i < ingredients.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(ingredients[i]))
                {
                    AnsiConsole.MarkupLine($"{ingredients[i]}: {measures[i]}");
                }
            }
        }
    }
}
