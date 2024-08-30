namespace Drinks.tonyissa.Models;

public class DrinkIngredientObject(string ingredient, string measure)
{
    public string Ingredient = ingredient;
    public string Measure = measure;
}

public class DrinkDetailObject
{
    public string strDrink;
    public string strTags;
    public string strCategory;
    public string strIBA;
    public string strAlcoholic;
    public string strGlass;
    public string strInstructions;
    public List<DrinkIngredientObject> strIngredients = [];

    public DrinkDetailObject(DrinkDetail drinkDetail)
    {
        strDrink = drinkDetail.strDrink;
        strTags = drinkDetail.strTags;
        strCategory = drinkDetail.strCategory;
        strIBA = drinkDetail.strIBA;
        strAlcoholic = drinkDetail.strAlcoholic;
        strGlass = drinkDetail.strGlass;
        strInstructions = drinkDetail.strInstructions;

        var drinkProperties = drinkDetail.GetType().GetProperties();

        for (int i = 1; i < 15; i++)
        {
            var ingredientProp = drinkProperties.First(property => property.Name == $"strIngredient{i}");
            var measureProp = drinkProperties.First(property => property.Name == $"strMeasure{i}");

            var ingredient = ingredientProp.GetValue(drinkDetail)?.ToString();
            var measure = measureProp.GetValue(drinkDetail)?.ToString();

            if (ingredient == null || measure == null) break;

            strIngredients.Add(new DrinkIngredientObject(ingredient, measure));
        }
    }
}