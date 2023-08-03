namespace DrinksInfoCarDioLogics;

public class UserInput
{
    Validation validation = new Validation();
    DrinkService drinkService = new DrinkService();

    public void GetCategoriesInput()
    {
        bool isNull;
        string categoryChosen;

        do
        {
            drinkService.GetCategories();
            Console.WriteLine("Choose a category:");
            categoryChosen = Console.ReadLine();

            while (!validation.IsStringValid(categoryChosen))
            {
                Console.Write("Invalid category! Type a valid category:");
                categoryChosen = Console.ReadLine();
            }

            isNull = drinkService.GetDrinksByCategories(categoryChosen);
        } while (isNull == true);

        GetDrinksInput(categoryChosen);
    }

    public void GetDrinksInput(string categoryChosen)
    {
        Console.Clear();
        bool isNull;

        do
        {
            drinkService.GetDrinksByCategories(categoryChosen);
            Console.WriteLine("Choose a drink or go to category menu by typing 0:");
            string drink = Console.ReadLine();

            if (drink == " 0")
                GetCategoriesInput();

            while (!validation.IsIdValid(drink))
            {
                Console.Write("Invalid drink! Choose a valid drink ID:");
                drink = Console.ReadLine();
            }

            isNull = drinkService.GetDrinks(drink);
        } while (isNull = true);
    }
}