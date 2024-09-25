using Spectre.Console;

namespace DrinksInfo
{
    public class UserInput
    {
        DrinksService drinksService = new();
        public void GetCategoriesInput()
        {

            var categories = drinksService.GetCategories();

            string category = TableVisualisationEngine.ShowCategory(categories, "Categories Menu");

            if(category.Contains("Exit"))
            {
                AnsiConsole.Markup("[red]Exiting......[/]\n");
                Environment.Exit(0);
            }
            else if (!category.Contains("View"))
            {
               GetDrinksInput(category);
            }
            else
            {
                if (category.Contains("Favorite"))
                {
                    AnsiConsole.Markup("\n[blue]Displaying Favorite Drinks[/]\n\n");
                    drinksService.GetFavDrink();
                    AnsiConsole.Markup("\n[blue]Press any key to return to menu[/] ");
                    Console.ReadLine();
                    Console.Clear();
                    GetCategoriesInput();
                }
                else
                {
                    AnsiConsole.Markup("\n[blue]Drinks Searched[/]\n\n");
                    drinksService.GetCountOfDrink();
                    AnsiConsole.Markup("\n[blue]Press any key to return to menu[/] ");
                    Console.ReadLine();
                    Console.Clear();
                    GetCategoriesInput();
                }
            }
            
        }

        private void GetDrinksInput(string category)
        {
            var drinks = drinksService.GetDrinksByCategory(category);

            Console.Write("Choose a drink or go back to category menu by typing 0: ");
            string drink = Console.ReadLine();
            if (drink == "0")
            {
                Console.Clear();
                GetCategoriesInput();
            }

            while (!Validation.IsIdValid(drink))
            {
                Console.WriteLine("\nInvalid drink. Enter again.\n");
                Console.Write("Choose a drink or go back to category menu by typing 0: ");
                drink = Console.ReadLine();
                if(drink == "0") GetCategoriesInput();
            }

            if (!drinks.Any(x => x.IdDrink == drink))
            {
                Console.WriteLine("Drink doesn't exist. Enter again.");
                Thread.Sleep(1000);
                Console.Clear();
                GetDrinksInput(category);
            }

            drinksService.GetDrink(drink, category);
            Console.Write("Press any key to go back to categories menu: ");
            Console.ReadLine();
            Console.Clear();
            GetCategoriesInput();
        }
    }
}