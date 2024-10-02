public static class ConsoleUI
{
    public static void DisplayCategories(List<DrinkCategory> categories)
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("|       Categories Menu           |");
        Console.WriteLine("-----------------------------------");
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"| {i + 1}. {categories[i].StrCategory}                  |");
        }
        Console.WriteLine("-----------------------------------");
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

        Console.WriteLine("-----------------------------------");
        Console.WriteLine("|       Drinks List               |");
        Console.WriteLine("-----------------------------------");

        for (int i = 0; i < drinks.Count; i++)
        {
            Console.WriteLine($"| {i + 1}. {drinks[i].StrDrink}              |");
        }

        Console.WriteLine("-----------------------------------");
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
        Console.WriteLine("-----------------------------------");
        if (!string.IsNullOrEmpty(drinkDetails.IdDrink))
            Console.WriteLine($"ID: {drinkDetails.IdDrink}");
        if (!string.IsNullOrEmpty(drinkDetails.StrDrink))
            Console.WriteLine($"Name: {drinkDetails.StrDrink}");
        if (!string.IsNullOrEmpty(drinkDetails.StrTags))
            Console.WriteLine($"Tags: {drinkDetails.StrTags}");
        if (!string.IsNullOrEmpty(drinkDetails.StrCategory))
            Console.WriteLine($"Category: {drinkDetails.StrCategory}");
        if (!string.IsNullOrEmpty(drinkDetails.StrIBA))
            Console.WriteLine($"IBA: {drinkDetails.StrIBA}");
        if (!string.IsNullOrEmpty(drinkDetails.StrAlcoholic))
            Console.WriteLine($"Alcohol Content: {drinkDetails.StrAlcoholic}");
        if (!string.IsNullOrEmpty(drinkDetails.StrGlass))
            Console.WriteLine($"Glass Type: {drinkDetails.StrGlass}");
        if (!string.IsNullOrEmpty(drinkDetails.StrInstructions))
            Console.WriteLine($"Instructions: {drinkDetails.StrInstructions}");
        if (!string.IsNullOrEmpty(drinkDetails.StrInstructionsDE))
            Console.WriteLine($"Instructions (DE): {drinkDetails.StrInstructionsDE}");
        if (!string.IsNullOrEmpty(drinkDetails.StrInstructionsIT))
            Console.WriteLine($"Instructions (IT): {drinkDetails.StrInstructionsIT}");
        if (!string.IsNullOrEmpty(drinkDetails.StrDrinkThumb))
            Console.WriteLine($"Thumbnail: {drinkDetails.StrDrinkThumb}");
        if (!string.IsNullOrEmpty(drinkDetails.StrIngredient1))
            Console.WriteLine($"Ingredient 1: {drinkDetails.StrIngredient1}");
        if (!string.IsNullOrEmpty(drinkDetails.StrIngredient2))
            Console.WriteLine($"Ingredient 2: {drinkDetails.StrIngredient2}");
        if (!string.IsNullOrEmpty(drinkDetails.StrIngredient3))
            Console.WriteLine($"Ingredient 3: {drinkDetails.StrIngredient3}");
        if (!string.IsNullOrEmpty(drinkDetails.StrIngredient4))
            Console.WriteLine($"Ingredient 4: {drinkDetails.StrIngredient4}");
        if (!string.IsNullOrEmpty(drinkDetails.StrMeasure1))
            Console.WriteLine($"Measure 1: {drinkDetails.StrMeasure1}");
        if (!string.IsNullOrEmpty(drinkDetails.StrMeasure2))
            Console.WriteLine($"Measure 2: {drinkDetails.StrMeasure2}");
        if (!string.IsNullOrEmpty(drinkDetails.StrMeasure3))
            Console.WriteLine($"Measure 3: {drinkDetails.StrMeasure3}");
        if (!string.IsNullOrEmpty(drinkDetails.StrImageSource))
            Console.WriteLine($"Image Source: {drinkDetails.StrImageSource}");
        if (!string.IsNullOrEmpty(drinkDetails.StrImageAttribution))
            Console.WriteLine($"Image Attribution: {drinkDetails.StrImageAttribution}");
        if (!string.IsNullOrEmpty(drinkDetails.StrCreativeCommonsConfirmed))
            Console.WriteLine($"Creative Commons Confirmed: {drinkDetails.StrCreativeCommonsConfirmed}");
        if (!string.IsNullOrEmpty(drinkDetails.DateModified))
            Console.WriteLine($"Date Modified: {drinkDetails.DateModified}");


        Console.WriteLine("-----------------------------------");
    }
}
