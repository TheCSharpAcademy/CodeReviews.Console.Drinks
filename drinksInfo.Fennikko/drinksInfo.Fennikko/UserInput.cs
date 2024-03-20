namespace drinksInfo.Fennikko;

public class UserInput
{
    private readonly DrinksService _drinksService = new();

    public void GetCategoriesInput()
    {
        var categories = DrinksService.GetCategories();

        Console.Write("Choose a category: ");
        var category = Console.ReadLine();

        while (!Validator.IsStringValid(category))
        {
            Console.Write("Invalid category. Please try again: ");
            category = Console.ReadLine();
        }

        if (categories.All(x => x.StrCategory != category))
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

        Console.Write("Choose a drink or go back to category menu by typing 0: ");
        var drink = Console.ReadLine();

        if(drink == "0") GetCategoriesInput();

        while (!Validator.IsIdValid(drink))
        {
            Console.Write("Invalid drink, please try again: ");
            drink = Console.ReadLine();
        }

        if (drinks.All(x => x.IdDrink != drink))
        {
            Console.WriteLine("Drink doesn't exist. Press any key to continue.");
            Console.ReadKey();
            GetDrinksInput(category);
        }

        DrinksService.GetDrink(drink);

        Console.Write("Press any key to return to categories menu");
        Console.ReadKey();
        if(!Console.KeyAvailable) GetCategoriesInput();
    }
}