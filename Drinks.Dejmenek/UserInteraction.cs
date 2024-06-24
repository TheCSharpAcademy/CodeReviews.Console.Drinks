using Drinks.Dejmenek.Models;
using Spectre.Console;

namespace Drinks.Dejmenek
{
    public static class UserInteraction
    {
        public static string GetDrink(List<Drink> drinks)
        {
            return AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Which drink would you like to know more about?")
                        .AddChoices(drinks.Select(d => d.StrDrink))
                    );
        }

        public static string GetDrinkCategory(List<DrinkCategory> drinksCategories)
        {
            return AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What is your favourite drink?")
                        .AddChoices(drinksCategories.Select(c => c.StrCategory))
                    );
        }
    }
}
