using Spectre.Console;

namespace DrinksInfo;

public class UserInterface
{
    public static void Menu()
    {
        DrinksService service = new();
        
        Console.CursorVisible = false;
        
        while (true)
        {
            Console.Clear();
            
            List<Models.Category> categories = service.GetCategories();
            
            var categoryChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[mediumpurple2]Categories[/]")
                    .AddChoices(categories.Select(c => c.CategoryName))
                    .HighlightStyle(Color.MediumOrchid)
                );
            
            List<Models.Drink> drinks = service.GetDrinksByCategory(categoryChoice);
            
            var drinkChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[mediumpurple2]Drinks[/]")
                    .AddChoices(drinks.Select(d => d.DrinkName))
                    .HighlightStyle(Color.MediumOrchid)
                );
            
            var selectedDrink = drinks.FirstOrDefault(d => d.DrinkName == drinkChoice);
            service.GetDrinkDetails(selectedDrink.DrinkId);
        }
    }
}