using DrinksInfo.Models;

namespace DrinksInfo.Utilities;

public static class Validator
{
    internal static bool IsCategoryValid(List<Category> categories, string selectedCategory)
    {
        foreach (Category category in categories)
        {
            if (category.StrCategory == selectedCategory) return true;
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

    internal static List<string> ValidMeasures(List<Measure> measures)
    {
        List<string?> measureValues = new List<string?>()
        {
            measures[0].Measure1,
            measures[0].Measure2,
            measures[0].Measure3,
            measures[0].Measure4,
            measures[0].Measure5,
            measures[0].Measure6,
            measures[0].Measure7,
            measures[0].Measure8,
            measures[0].Measure9,
            measures[0].Measure10,
            measures[0].Measure11,
            measures[0].Measure12,
            measures[0].Measure13,
            measures[0].Measure14,
            measures[0].Measure15
        };
        return measureValues.Where(ingredient => ingredient != null).ToList();
    }
}