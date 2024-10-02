public static class ConsoleUI
{
    public static void DisplayCategories(List<DrinkCategory> categories)
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("|       Categories Menu           |");
        Console.WriteLine("-----------------------------------");
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"| {i + 1}. {categories[i].strCategory}                  |");
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
            Console.WriteLine($"| {i + 1}. {drinks[i].strDrink}              |");
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
        if (!string.IsNullOrEmpty(drinkDetails.idDrink))
            Console.WriteLine($"ID: {drinkDetails.idDrink}");
        if (!string.IsNullOrEmpty(drinkDetails.strDrink))
            Console.WriteLine($"Name: {drinkDetails.strDrink}");
        if (!string.IsNullOrEmpty(drinkDetails.strTags))
            Console.WriteLine($"Tags: {drinkDetails.strTags}");
        if (!string.IsNullOrEmpty(drinkDetails.strCategory))
            Console.WriteLine($"Category: {drinkDetails.strCategory}");
        if (!string.IsNullOrEmpty(drinkDetails.strIBA))
            Console.WriteLine($"IBA: {drinkDetails.strIBA}");
        if (!string.IsNullOrEmpty(drinkDetails.strAlcoholic))
            Console.WriteLine($"Alcohol Content: {drinkDetails.strAlcoholic}");
        if (!string.IsNullOrEmpty(drinkDetails.strGlass))
            Console.WriteLine($"Glass Type: {drinkDetails.strGlass}");
        if (!string.IsNullOrEmpty(drinkDetails.strInstructions))
            Console.WriteLine($"Instructions: {drinkDetails.strInstructions}");
        if (!string.IsNullOrEmpty(drinkDetails.strInstructionsDE))
            Console.WriteLine($"Instructions (DE): {drinkDetails.strInstructionsDE}");
        if (!string.IsNullOrEmpty(drinkDetails.strInstructionsIT))
            Console.WriteLine($"Instructions (IT): {drinkDetails.strInstructionsIT}");
        if (!string.IsNullOrEmpty(drinkDetails.strDrinkThumb))
            Console.WriteLine($"Thumbnail: {drinkDetails.strDrinkThumb}");
        if (!string.IsNullOrEmpty(drinkDetails.strIngredient1))
            Console.WriteLine($"Ingredient 1: {drinkDetails.strIngredient1}");
        if (!string.IsNullOrEmpty(drinkDetails.strIngredient2))
            Console.WriteLine($"Ingredient 2: {drinkDetails.strIngredient2}");
        if (!string.IsNullOrEmpty(drinkDetails.strIngredient3))
            Console.WriteLine($"Ingredient 3: {drinkDetails.strIngredient3}");
        if (!string.IsNullOrEmpty(drinkDetails.strIngredient4))
            Console.WriteLine($"Ingredient 4: {drinkDetails.strIngredient4}");
        if (!string.IsNullOrEmpty(drinkDetails.strMeasure1))
            Console.WriteLine($"Measure 1: {drinkDetails.strMeasure1}");
        if (!string.IsNullOrEmpty(drinkDetails.strMeasure2))
            Console.WriteLine($"Measure 2: {drinkDetails.strMeasure2}");
        if (!string.IsNullOrEmpty(drinkDetails.strMeasure3))
            Console.WriteLine($"Measure 3: {drinkDetails.strMeasure3}");
        if (!string.IsNullOrEmpty(drinkDetails.strImageSource))
            Console.WriteLine($"Image Source: {drinkDetails.strImageSource}");
        if (!string.IsNullOrEmpty(drinkDetails.strImageAttribution))
            Console.WriteLine($"Image Attribution: {drinkDetails.strImageAttribution}");
        if (!string.IsNullOrEmpty(drinkDetails.strCreativeCommonsConfirmed))
            Console.WriteLine($"Creative Commons Confirmed: {drinkDetails.strCreativeCommonsConfirmed}");
        if (!string.IsNullOrEmpty(drinkDetails.dateModified))
            Console.WriteLine($"Date Modified: {drinkDetails.dateModified}");

        Console.WriteLine("-----------------------------------");
    }
}
