namespace DrinksInfoCarDioLogics;

public class UserInput
{
    Validation validation = new Validation();
    DrinkService drinkService = new DrinkService();

    public void GetCategoriesInput()
    {
        bool isCategoryValid = true;
        string categoryChosen;

        do
        {
            do
            {
                drinkService.ShowCategories();
                Console.WriteLine("Choose a category or press 0 to exit App:");
                categoryChosen = Console.ReadLine();

                if(categoryChosen != "0")
                {
                    isCategoryValid = validation.IsCategoryValid(categoryChosen);
                }
            } while (isCategoryValid == false);

            if(categoryChosen != "0")
            {
                GetDrinksInput(categoryChosen);
            }
        } while (categoryChosen != "0");
    }

    public void GetDrinksInput(string categoryChosen)
    {
        Console.Clear();
        bool isDrinkValid;
        string drinkChosen;

        do
        {
            drinkService.ShowDrinksByCategory(categoryChosen);
            Console.WriteLine("Choose a drink or go to category menu by typing 0:");
            drinkChosen = Console.ReadLine();

            if (drinkChosen == "0")
                GetCategoriesInput();

            isDrinkValid = validation.IsDrinkValid(drinkChosen);
        } while (isDrinkValid == false);

        drinkService.ShowDrinkDetails(drinkChosen);

        Console.WriteLine("Press any key to continue!");
        Console.ReadLine();
    }
}