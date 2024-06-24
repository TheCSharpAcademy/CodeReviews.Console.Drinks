using drinks_info_console.APIConsumerServices;
using drinks_info_console.Input;
using drinks_info_console.Models;
using drinks_info_console.UI;

namespace drinks_info_console.Controller;

public static class DrinksInfoController
{
    private static UserInput UserInput = new UserInput();
    private static TableBuilder TableBuilder = new TableBuilder();
    private static Validation Validator = new Validation();
    private static DrinksProcessor DrinksProcessor = new(new HttpClient());

    public static async Task StartProgram()
    {
        string ans, categoryName, drinkId;
        List<DrinkDetail> drinkDetails;
        List<object> cleanDrinkDetails;

        do
        {
            categoryName = await SelectCategoryAsync();
            drinkId = await SelectDrinkAsync(categoryName);

            drinkDetails = await DrinksProcessor.GetDrinksDetailsAsync(drinkId);
            cleanDrinkDetails = GetCleanDetailsList(drinkDetails);

            TableBuilder.DisplayTable(cleanDrinkDetails, "");

            Console.Write("Do you want to check another drink? (y/n): ");
            ans = UserInput.GetInput().ToLower();
            while (!Validator.IsValidAns(ans))
            {
                Console.WriteLine("Invalid Input!");
                Console.Write("Do you want to check another drink? (y/n): ");
                ans = UserInput.GetInput().ToLower();
            }
        } while (ans == "y");
    }

    private static async Task<string> SelectCategoryAsync()
    {
        var categoryList = await DrinksProcessor.GetCategoriesListAsync();

        TableBuilder.DisplayTable(categoryList, "Category");

        var categoryChoice = GetValidCategoryChoice();
        while (!Validator.IsValidCategory(categoryList, categoryChoice))
        {
            Console.WriteLine("Invalid Category!");
            categoryChoice = GetValidCategoryChoice();
        }

        return categoryChoice;
    }

    private static string GetValidCategoryChoice()
    {
        Console.Write("Enter a category name to select: ");
        var categoryChoice = UserInput.GetInput();
        while (!Validator.IsValidString(categoryChoice))
        {
            Console.WriteLine("Invalid Input!");
            Console.Write("Enter a category name to select: ");
            categoryChoice = UserInput.GetInput();
        }

        return categoryChoice;
    }

    private static async Task<string> SelectDrinkAsync(string category)
    {
        var drinksList = await DrinksProcessor.GetDrinksListAsync(category);

        TableBuilder.DisplayTable(drinksList, category);
        var id = GetValidIdChoice();
        while (!Validator.IsValidDrinkId(drinksList, id))
        {
            Console.WriteLine("Invalid Input!");
            id = GetValidIdChoice();
        }

        return id;
    }

    private static string GetValidIdChoice()
    {
        Console.Write("Enter a category Id to display drinks: ");
        var id = UserInput.GetInput();
        while (!Validator.IsValidId(id))
        {
            Console.WriteLine("Invalid Input!");
            Console.Write("Enter a category Id to display drinks: ");
            id = UserInput.GetInput();
        }

        return id;
    }

    private static List<object> GetCleanDetailsList(List<DrinkDetail> drinkDetails)
    {
        // Used reflection to get the properties of the DrinkDetails object 
        // and passed them as list of property object using an anonymous object 
        List<object> cleanDrinkDetails = new();
        foreach (var detail in drinkDetails)
        {
            var type = detail.GetType();
            foreach (var prop in type.GetProperties())
            {
                var property = prop.GetValue(detail);
                if (property is null)
                {
                    continue;
                }

                cleanDrinkDetails.Add(new { Value = property });
            }
        }

        return cleanDrinkDetails;
    }
}
