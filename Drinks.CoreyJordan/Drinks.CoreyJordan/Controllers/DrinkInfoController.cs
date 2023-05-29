using Drinks.CoreyJordan.UI;
using DrinksLibrary.Data;
using DrinksLibrary.Models;
using System.Reflection;

namespace Drinks.CoreyJordan.Controllers;
internal class DrinkInfoController
{
    public string DrinkId { get; set; }
    DrinksService drinksService  = new();
    ConsoleEngine display = new();
    public DrinkInfoController(string drinkId)
    {
        DrinkId = drinkId;
    }

    internal void ShowDrink()
    {
        RawInfoModel rawInfo = drinksService.GetDrink(DrinkId);

        // Parse into seperate lists to build tables
        InfoMetaModel drinkMeta = new(rawInfo);
        IngredientListModel ingredientsList = new(rawInfo);
        MeasureListModel measureList = new(rawInfo);

        List<object> metaList = PrepareMetaInfo(drinkMeta);
        string[] header = new string[] { "" };

        Console.Clear();
        display.DisplayTable(metaList, header);

        List<IngredientModel> ingredientsData = PrepareIngredients(ingredientsList, measureList);
        string[] headers = new string[] { "INGREDIENT", "MEASURE" };

        display.DisplayTable(ingredientsData, headers);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static List<IngredientModel> PrepareIngredients(IngredientListModel ingredientsList, MeasureListModel measureList)
    {
        List<string> ingredients = new();
        foreach (PropertyInfo property in ingredientsList.GetType().GetProperties())
        {
            if (string.IsNullOrEmpty(property.GetValue(ingredientsList)?.ToString()) == false)
            {
                ingredients.Add((string)property.GetValue(ingredientsList)!);
            }
        }

        List<string> measure = new();
        foreach (PropertyInfo property in measureList.GetType().GetProperties())
        {
            if (string.IsNullOrEmpty(property.GetValue(measureList)?.ToString()) == false)
            {
                measure.Add((string)property.GetValue(measureList)!);
            }
        }

        // Even out lists
        while (measure.Count < ingredients.Count)
        {
            measure.Add("");
        }

        List<IngredientModel> ingredientsData = new();
        for (int i = 0; i < ingredients.Count; i++)
        {
            ingredientsData.Add(new IngredientModel
            {
                
                Ingredient = ingredients[i],
                Measure = measure[i]
            });
        }

        return ingredientsData;
    }

    private static List<object> PrepareMetaInfo(InfoMetaModel drinkMeta)
    {
        List<object> metaList = new();
        foreach (PropertyInfo property in drinkMeta.GetType().GetProperties())
        {
            if (string.IsNullOrEmpty(property.GetValue(drinkMeta)?.ToString()) == false)
            {
                metaList.Add(new
                {
                    Key = property.Name.ToUpper(),
                    Value = property.GetValue(drinkMeta)
                });
            }
        }

        return metaList;
    }
}
