namespace DrinksInfo;

internal class UserInput
{

    internal static async Task<string> GetCategoryInput()
    {
        var categories = await DrinkService.GetCategories();

        await Console.Out.WriteLineAsync("Choose category (enter '0' to end application):");

        var userInput = Console.ReadLine().Trim();

        if (userInput == "0") return "0";

        while (!Validation.ValidInput(userInput, categories))
        {
            Console.WriteLine("category doesn't exist\n");
            userInput = Console.ReadLine().Trim();
        }

        return userInput;
    }

    internal static async Task<string> GetDrinkInput(string category)
    {
        var drinks = await DrinkService.GetDrinks(category);

        await Console.Out.WriteLineAsync("Choose drink (enter '0' to return to category menu):");

        var userInput = Console.ReadLine().Trim();

        if (userInput == "0") return "0";

        while (!Validation.ValidInput(userInput, drinks))
        {
            Console.WriteLine("drink doesn't exist\n");
            userInput = Console.ReadLine().Trim();
        }

        return userInput;
    }

}
