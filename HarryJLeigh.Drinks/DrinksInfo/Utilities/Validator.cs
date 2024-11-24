using DrinksInfo.Models;

namespace DrinksInfo.Utilities;

public static class Validator
{
    internal static bool IsCategoryValid(List<Category> categories, string selectedCategory)
    {
        foreach (Category category in categories)
        {
            if (category.strCategory == selectedCategory) return true;
        }
        return false;
    }

    internal static bool IsDrinkValid(List<Drink> drinks, int selectedDrinkId)
    {
        foreach (Drink drink in drinks)
        {
            if (drink.IdDrink == selectedDrinkId) return true;
        }
        return false;
    }

    internal static List<string> ValidIngredients(List<Ingredients> ingredients)
    {
        List<string?> ingredientValues = new List<string?>()
        {
            ingredients[0].Ingredient1,
            ingredients[0].Ingredient2,
            ingredients[0].Ingredient3,
            ingredients[0].Ingredient4,
            ingredients[0].Ingredient5,
            ingredients[0].Ingredient6,
            ingredients[0].Ingredient7,
            ingredients[0].Ingredient8,
            ingredients[0].Ingredient9,
            ingredients[0].Ingredient10,
            ingredients[0].Ingredient11,
            ingredients[0].Ingredient12,
            ingredients[0].Ingredient13,
            ingredients[0].Ingredient14,
            ingredients[0].Ingredient15
        };
        
        return ingredientValues.Where(ingredient => ingredient != null).ToList();
    }
}