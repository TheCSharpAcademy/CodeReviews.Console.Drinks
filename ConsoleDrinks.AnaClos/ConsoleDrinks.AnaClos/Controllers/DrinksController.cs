using ConsoleDrinks.AnaClos.Models;
using ConsoleDrinks.AnaClos.DTOs;
using Newtonsoft.Json;

namespace ConsoleDrinks.AnaClos.Controllers;

public class DrinksController
{
    ServiceController serviceController;

    public DrinksController(ServiceController serviceController)
    {
        this.serviceController = serviceController;
    }

    public DrinkDetail GetDrinkDetails(int drinkId)
    {
        var rawResponse = serviceController.GetResponse($"lookup.php?i={drinkId}");
        var drinks = JsonConvert.DeserializeObject<DrinksDetails>(rawResponse);
        DrinkDetail drink = drinks.DrinksList?.FirstOrDefault() ?? null;
        return drink; 
    }
    
    public List<Drink> GetDrinks(string category)
    {
        var rawResponse = serviceController.GetResponse($"filter.php?c={category}");
        List<Drink> listDrinks;

        if (rawResponse != string.Empty)
        {
            var drinks = JsonConvert.DeserializeObject<Drinks>(rawResponse);
            listDrinks = drinks.DrinksList;
        }
        else
        {
            listDrinks = null;
        }

        return listDrinks;
    }

    public List<TableRecordDto> DrinksToTableRecord(List<Drink> listDrinks)
    {
        var tableRecord = new List<TableRecordDto>();

        foreach (var drink in listDrinks)
        {
            var record = new TableRecordDto { Column1 = drink.IdDrink.ToString(), Column2 = drink.StrDrink };
            tableRecord.Add(record);
        }

        return tableRecord;
    }

    public List<TableRecordDto> DrinkDetailToTableRecord(DrinkDetail drink)
    {
        var tableRecord = new List<TableRecordDto>();

        foreach (var property in drink.GetType().GetProperties())
        {
            if (property.GetValue(drink) != null)
            {
                var record = new TableRecordDto { Column1 = property.Name, Column2 = property.GetValue(drink).ToString() };
                tableRecord.Add(record);
            }            
        }

        return tableRecord;
    }
}