
public class UserInput {

    private DrinksService drinksService = new DrinksService();

    internal void GetCategoriesInput() {
        List<Category> categories = drinksService.GetCategories();

        Console.WriteLine("Choose category:");

        string category = Console.ReadLine();

        while (!Validator.IsStringValid(category)) {
            Console.WriteLine("\nInvalid category");
            category = Console.ReadLine();
        }

        if (!categories.Any(x => x.StrCategory == category)) {
            Console.WriteLine("Category doesn't exist.");
            this.GetCategoriesInput();
        }

        GetDrinksInput(category);
    }

    private void GetDrinksInput(string category)
    {
        List<Drink> drinks = drinksService.GetDrinksByCategory(category);

        Console.WriteLine("Choose a drink or go back to category menu by typing 0:");

        string drink = Console.ReadLine();

        if (drink == "0") GetCategoriesInput();
        
        while (!Validator.IsIdValid(drink)) {
            Console.WriteLine("\nInvalid drink");
            drink = Console.ReadLine();
        }

        if (!drinks.Any(x => x.IdDrink == drink)) {
            Console.WriteLine("Drink doesn't exist.");
            this.GetDrinksInput(category);
        }

        drinksService.GetDrink(drink);

        Console.WriteLine("Press any key to go back to categories menu.");
        Console.ReadKey();
        if(!Console.KeyAvailable) GetCategoriesInput();
    }
}