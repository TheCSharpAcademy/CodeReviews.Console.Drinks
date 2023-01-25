namespace DrinksInfo;

class Program
{
    private static bool exitApp = false;
    static void Main(string[] args)
    {
        UserInput userInput = new();
        DrinksService drinksService = new();
        while (!exitApp)
        {
            string category = userInput.GetCategory();
            if (category == "0") { exitApp = true; }

            string drinkId = userInput.GetDrinkId(category);
            if (drinkId == null) { continue; }

            drinksService.GetDrinkDetails(drinkId);

            string option = userInput.GetOption();
            if (option == "1") { continue; } else { exitApp = true; }
        }
    }
}
