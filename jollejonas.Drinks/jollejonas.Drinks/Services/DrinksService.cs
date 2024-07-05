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
                    .AddChoices(drinks.Select(d => d.StrDrink).ToArray())
            );

            string selectedDrinkId = drinks.First(d => d.StrDrink == menuSelection).IdDrink;

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

            AnsiConsole.MarkupLine($"[bold]{drink.StrDrink}[/]");
            AnsiConsole.MarkupLine($"[bold]Category:[/] {drink.StrCategory}");
            AnsiConsole.MarkupLine($"[bold]Alcoholic:[/] {drink.StrAlcoholic}");
            AnsiConsole.MarkupLine($"[bold]Glass:[/] {drink.StrGlass}");
            Console.WriteLine();
            AnsiConsole.MarkupLine($"[bold]Instructions:[/] {drink.StrInstructions}");

            var ingredients = new[]
            {
               drink.StrIngredient1,
                drink.StrIngredient2,
                drink.StrIngredient3,
                drink.StrIngredient4,
                drink.StrIngredient5,
                drink.StrIngredient6,
                drink.StrIngredient7,
                drink.StrIngredient8,
                drink.StrIngredient9,
                drink.StrIngredient10,
                drink.StrIngredient11,
                drink.StrIngredient12,
                drink.StrIngredient13,
                drink.StrIngredient14,
                drink.StrIngredient15
            };
        
            var measures = new[]
            {
                drink.StrMeasure1,
                drink.StrMeasure2,
                drink.StrMeasure3,
                drink.StrMeasure4,
                drink.StrMeasure5,
                drink.StrMeasure6,
                drink.StrMeasure7,
                drink.StrMeasure8,
                drink.StrMeasure9,
                drink.StrMeasure10,
                drink.StrMeasure11,
                drink.StrMeasure12,
                drink.StrMeasure13,
                drink.StrMeasure14,
                drink.StrMeasure15
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
