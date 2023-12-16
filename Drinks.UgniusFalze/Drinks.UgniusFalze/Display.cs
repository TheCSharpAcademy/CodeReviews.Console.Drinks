using ConsoleTableExt;

namespace Drinks.UgniusFalze;

public class Display
{
    private DrinksService Api { get; set; } = new();

    public bool DisplayCategories()
    {
        var exit = false;
        var categories = Api.GetDrinkCategories();
        ConsoleTableBuilder
            .From(categories.DrinkCategories)
            .WithTitle("Categories Menu")
            .WithColumn("Category")
            .ExportAndWriteLine();
        do
        {
            var input = GetUserInput("Please enter which category's drink would you like to choose or 0 to exit");
            var category = categories.DrinkCategories.Find(x => x.StrCategory == input);
            if (category != null)
            {
                exit = DisplayDrinks(category);
                break;
            }else if (input == "0")
            {
                exit = true;
                break;
            }
            else{
                Console.WriteLine("Category not found.");
            }
        } while (true);

        return exit;
    }

    private bool DisplayDrinks(Category category)
    {
        var drinks = Api.GetDrinksRecord(category);
        ConsoleTableBuilder
            .From(drinks.Drinks)
            .WithTitle(category.StrCategory + " drinks")
            .WithColumn("Drink", "Drink Image", "Id")
            .ExportAndWriteLine();
        Drink drink;
        do
        {
            var input = GetUserInput("Please enter which drink details would like to see or 0 to exit");

            var isNumeric = int.TryParse(input, out var drinkId);
            if (isNumeric)
            {
                if (drinkId == 0)
                {
                    return true;
                }
                drink = drinks.Drinks.Find(x => x.IdDrink == drinkId);
            }
            else
            {
                drink = drinks.Drinks.Find(x => x.StrDrink == input);
            }
            
            if (drink != null)
            {
                break;
            }

            {
                Console.WriteLine("Drink not found.");
            }
        } while (true);

        return DisplayDrinkDetails(drink);
    }

    private bool DisplayDrinkDetails(Drink drink)
    {
        var drinkDetailsRecord = Api.GetDrinkDetailsRecord(drink);
        var drinkDetail = drinkDetailsRecord.DrinkDetailsList.First();
        ConsoleTableBuilder
            .From(drinkDetail.ConvertToList())
            .WithColumn("Detail", "Value")
            .ExportAndWriteLine();
        do
        { 
            var input = GetUserInput("Would you like to search for a drink again? (type yes or no)");
            switch (input)
            {
                case "yes":
                    return false;
                case "no":
                    return true;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        } while (true);
    }
    
    private static string GetUserInput(string message)
    {
        string? userInput;
        do
        {
            Console.WriteLine(message);
            userInput = Console.ReadLine();
            if (userInput != null)
            {
                break;
            }
            else
            {
                Console.WriteLine("Input shouldn't be null");
            }
        } while (true);

        return userInput;
    }
}