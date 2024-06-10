namespace DrinksInfo.kalsson;

public class UserInput
{
    DrinksService _drinksService = new();

    internal void GetCategoriesInput()
    {
        _drinksService.GetCategories();
        
        Console.WriteLine("Choose category:");

        string category = Console.ReadLine();

        while (!Validator.IsStringValid(category))
        {
            Console.WriteLine("\nInvalid category");
            category = Console.ReadLine();
        }

        GetDrinksInput(category);
    }

    private void GetDrinksInput(string category)
    {
        _drinksService.GetDrinksByCategory(category);
    }
}