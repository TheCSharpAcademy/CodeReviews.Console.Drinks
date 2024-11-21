
public class UserInput {

    private DrinksService drinksService = new DrinksService();

    internal void GetCategoriesInput() {
        drinksService.GetCategories();

        Console.WriteLine("Choose category:");

        string category = Console.ReadLine();

        while (!Validator.IsStringValid(category)) {
            Console.WriteLine("\nInvalid category");
            category = Console.ReadLine();
        }

        GetDrinksInput(category);
    }

    private void GetDrinksInput(string category)
    {
        drinksService.GetDrinksByCategory(category);
    }
}