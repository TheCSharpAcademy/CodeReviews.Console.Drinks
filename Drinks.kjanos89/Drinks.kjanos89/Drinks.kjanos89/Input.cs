namespace Drinks.kjanos89;

public class Input
{
    ApiController controller = new ApiController();
    Validation validation = new Validation();

    public void GetCategories()
    {
        Console.Clear();
        controller.GetCategories();
        Console.WriteLine("Type in the name of a category from the list below:");
        string choice = Console.ReadLine();
        while (!validation.IsValidString(choice) || !controller.categoryNames.Contains(choice))
        {
            Console.WriteLine("Invalid category. Please try again or press '0' to return to reset the menu:");
            choice = Console.ReadLine();
            if(choice=="0")
            {
                GetCategories();
                return;
            }
        }
        GetDrinks(choice);
    }

    public void GetDrinks(string choice)
    {
        Console.Clear();
        controller.GetDrinks(choice);
        Console.WriteLine("Choose a drink from the list below or press '0' to go back to the Categories menu:");
        string drinkChoice = Console.ReadLine();
        if (drinkChoice == "0")
        {
            GetCategories();
            return;
        }
        while (!IsValidDrinkId(drinkChoice))
        {
            Console.WriteLine("Invalid drink ID. Please try again or press '0' to return to the menu:");
            drinkChoice = Console.ReadLine();
            if (drinkChoice == "0")
            {
                GetCategories();
                return;
            }
        }
        controller.GetIngredients(drinkChoice);
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadLine();
        GetCategories();
    }

    private bool IsValidDrinkId(string id)
    {
        var drinkIds = controller.GetDrinkIds();
        return drinkIds.Contains(id);
    }
}