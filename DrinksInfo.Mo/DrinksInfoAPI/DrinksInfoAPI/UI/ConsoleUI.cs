public static class ConsoleUI
{
    private const int ColumnWidth = 35;

    public static void DisplayCategories(List<DrinkCategory> categories)
    {
        PrintTableHeader("Categories Menu");

        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"| {i + 1,-4} | {categories[i].StrCategory,-ColumnWidth} |");
        }
        PrintTableFooter();
    }

    public static int GetUserCategorySelection(int maxIndex)
    {
        Console.WriteLine("Choose a category: ");
        int selection = int.Parse(Console.ReadLine()) - 1;
        if (selection < 0 || selection >= maxIndex)
        {
            Console.WriteLine("Invalid selection, please try again.");
            return GetUserCategorySelection(maxIndex);
        }
        return selection;
    }

    public static void DisplayDrinks(List<Drink> drinks)
    {
        if (drinks == null || drinks.Count == 0)
        {
            Console.WriteLine("No drinks available for the selected category.");
            return;
        }

        PrintTableHeader("Drinks List");

        for (int i = 0; i < drinks.Count; i++)
        {
            Console.WriteLine($"| {i + 1,-4} | {drinks[i].StrDrink,-ColumnWidth} |");
        }

        PrintTableFooter();
    }

    public static int GetUserDrinkSelection(int maxIndex)
    {
        Console.WriteLine("Choose a drink: ");
        int selection = int.Parse(Console.ReadLine()) - 1;
        if (selection < 0 || selection >= maxIndex)
        {
            Console.WriteLine("Invalid selection, please try again.");
            return GetUserDrinkSelection(maxIndex);
        }
        return selection;
    }

    public static void DisplayDrinkDetails(DrinkDetails drinkDetails)
    {
        Console.WriteLine(new string('-', 45));
        if (!string.IsNullOrEmpty(drinkDetails.IdDrink))
            Console.WriteLine($"ID: {drinkDetails.IdDrink}");

        if (!string.IsNullOrEmpty(drinkDetails.StrDrink))
            Console.WriteLine($"Name: {drinkDetails.StrDrink}");

        if (!string.IsNullOrEmpty(drinkDetails.StrCategory))
            Console.WriteLine($"Category: {drinkDetails.StrCategory}");

        if (!string.IsNullOrEmpty(drinkDetails.StrAlcoholic))
            Console.WriteLine($"Alcoholic: {drinkDetails.StrAlcoholic}");

        if (!string.IsNullOrEmpty(drinkDetails.StrGlass))
            Console.WriteLine($"Glass: {drinkDetails.StrGlass}");

        Console.WriteLine("Ingredients:");

        DisplayIngredientWithMeasure(drinkDetails.StrIngredient1, drinkDetails.StrMeasure1);
        DisplayIngredientWithMeasure(drinkDetails.StrIngredient2, drinkDetails.StrMeasure2);
        DisplayIngredientWithMeasure(drinkDetails.StrIngredient3, drinkDetails.StrMeasure3);
        DisplayIngredientWithMeasure(drinkDetails.StrIngredient4, drinkDetails.StrMeasure4);
        DisplayIngredientWithMeasure(drinkDetails.StrIngredient5, drinkDetails.StrMeasure5);
        DisplayIngredientWithMeasure(drinkDetails.StrIngredient6, drinkDetails.StrMeasure6);
        DisplayIngredientWithMeasure(drinkDetails.StrIngredient7, drinkDetails.StrMeasure7);
        DisplayIngredientWithMeasure(drinkDetails.StrIngredient8, drinkDetails.StrMeasure8);
        DisplayIngredientWithMeasure(drinkDetails.StrIngredient9, drinkDetails.StrMeasure9);
        DisplayIngredientWithMeasure(drinkDetails.StrIngredient10, drinkDetails.StrMeasure10);
        DisplayIngredientWithMeasure(drinkDetails.StrIngredient11, drinkDetails.StrMeasure11);
        DisplayIngredientWithMeasure(drinkDetails.StrIngredient12, drinkDetails.StrMeasure12);
        DisplayIngredientWithMeasure(drinkDetails.StrIngredient13, drinkDetails.StrMeasure13);
        DisplayIngredientWithMeasure(drinkDetails.StrIngredient14, drinkDetails.StrMeasure14);
        DisplayIngredientWithMeasure(drinkDetails.StrIngredient15, drinkDetails.StrMeasure15);

        if (!string.IsNullOrEmpty(drinkDetails.StrInstructions))
            Console.WriteLine($"Instructions: {drinkDetails.StrInstructions}");

        Console.WriteLine(new string('-', 45));
    }

    private static void DisplayIngredientWithMeasure(string ingredient, string measure)
    {
        if (!string.IsNullOrEmpty(ingredient))
        {
            Console.WriteLine($"- {ingredient}: {(string.IsNullOrEmpty(measure) ? "To taste" : measure)}");
        }
    }


    private static void PrintTableHeader(string title)
    {
        Console.WriteLine(new string('-', ColumnWidth + 10));
        Console.WriteLine($"| {"ID",-4} | {title,-ColumnWidth} |");
        Console.WriteLine(new string('-', ColumnWidth + 10));
    }

    private static void PrintTableFooter()
    {
        Console.WriteLine(new string('-', ColumnWidth + 10));
    }
}
