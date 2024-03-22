using Spectre.Console;

namespace drinksInfo.Fennikko;

public class UserInput
{
    public void GetCategoriesInput()
    {
        var categories = DrinksService.GetCategories();

        Console.Write("Choose a category or type quit to exit: ");
        var category = Console.ReadLine();

        while (!Validator.IsStringValid(category))
        {
            Console.Write("Invalid category. Please try again: ");
            category = Console.ReadLine();
        }

        if (category.ToLower() == "quit")
        {
            Console.WriteLine("Thank you for using Drinks Info! Press any key to continue");
            Console.ReadKey();
            Environment.Exit(0);
        }

        if (categories.All(x => x.StrCategory.ToUpper() != category.ToUpper()))
        {
            Console.WriteLine("Category does not exist, press any key to continue.");
            Console.ReadKey();
            GetCategoriesInput();
        }

        GetDrinksInput(category);
    }

    private void GetDrinksInput(string category)
    {
        var drinks = DrinksService.GetDrinksByCategory(category);

        var pageSize = 15;
        var pageCount = drinks.Count / pageSize;
        var currentPage = 1;
        var running = true;
        var drinkInput = "";

        TableVisualizationEngine.ShowTable(Paginator(drinks,currentPage, pageSize), $"Drinks Menu: Page {currentPage} / {pageCount}");

        do
        {
            var choices = new List<string>{"Next Page","Previous Page","Enter Drink","Return to Categories"};
            if (currentPage >= pageCount)
            {
                choices.Remove("Next Page");
            }
            else if (currentPage <= 1)
            {
                choices.Remove("Previous Page");
            }
            var pageSelect = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a function")
                    .PageSize(10)
                    .AddChoices(choices));
            switch (pageSelect)
            {
                case "Next Page":
                    currentPage++;
                    TableVisualizationEngine.ShowTable(Paginator(drinks,currentPage, pageSize), $"Drinks Menu: Page {currentPage} / {pageCount}");
                    break;
                case "Previous Page":
                    currentPage--;
                    TableVisualizationEngine.ShowTable(Paginator(drinks,currentPage, pageSize), $"Drinks Menu: Page {currentPage} / {pageCount}");
                    break;
                case "Enter Drink":
                    AnsiConsole.Write("Enter your drink selection: ");
                    drinkInput = Console.ReadLine();
                    while (!Validator.IsIdValid(drinkInput))
                    {
                        AnsiConsole.Write("Invalid drink, please try again or go back to category menu by typing 0: ");
                        drinkInput = Console.ReadLine();
                        if(drinkInput == "0") GetCategoriesInput();
                    }
                    if (drinks.All(x => x.IdDrink != drinkInput))
                    {
                        AnsiConsole.WriteLine("Drink doesn't exist. Please try again or go back to category menu by typing 0: .");
                        drinkInput = Console.ReadLine();
                        if(drinkInput == "0") GetCategoriesInput();
                    }
                    running = false;
                    break;
                case "Return to Categories":
                    running = false;
                    GetCategoriesInput();
                    break;
            }
        } while (running);

        DrinksService.GetDrink(drinkInput);

        Console.Write("Press any key to return to categories menu");
        Console.ReadKey();
        if(!Console.KeyAvailable) GetCategoriesInput();
    }

    public static List<T> Paginator<T>(List<T> paginatorList, int pages, int pageSize)
    {
        return paginatorList.Skip((pages - 1) * pageSize).Take(pageSize).ToList();
    }
}