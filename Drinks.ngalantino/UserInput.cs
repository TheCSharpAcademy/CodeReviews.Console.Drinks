
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

        Console.WriteLine("Choose a drink or go back to category menu by typing 0:");

        string drink = Console.ReadLine();

        if (drink == "0") GetCategoriesInput();
        
        while (!Validator.IsIdValid(drink)) {
            Console.WriteLine("\nInvalid drink");
            drink = Console.ReadLine();
        }

        drinksService.GetDrink(drink);
    }
}