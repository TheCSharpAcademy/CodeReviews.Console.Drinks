using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drinks.iamnikitakostin.Controllers;
using Drinks.iamnikitakostin.Data;
using Drinks.iamnikitakostin.Models;
using Newtonsoft.Json;
using RestSharp;
using Spectre.Console;

namespace Drinks.iamnikitakostin.Services;

internal class DrinkService : ConsoleController
{
    private readonly DataContext _context;

    public DrinkService(DataContext context)
    {
        _context = context;
    }

    public static List<string>? GetCategories()
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

            List<string> returnedList = serialize.CategoriesList.Select(category => category.strCategory).ToList();
            return returnedList;
        } else
        {
            return null;
        }
    }

    public static DrinkDetail? GetDrinkById(string id) {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"lookup.php?i={id}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);
            DrinkDetail drink = serialize.DrinkDetailList[0];
            drink.IdInt = Int32.Parse(drink.idDrink);
            return drink;
        } else
        {
            return null;
        }
    }
    public static Dictionary<string,string>? GetDrinksByCategory(string category)
    {
        var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
        var request = new RestRequest($"filter.php?c={category}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Models.Drinks>(rawResponse);

            Dictionary<string, string> returnedDict = serialize.DrinksList.Select(drink => drink).ToDictionary(drink => drink.idDrink, drink => drink.strDrink);

            return returnedDict;
        } else
        {
            return null;
        }
    }

    public List<DrinkDetail>? GetFavorites()
    {
        List<DrinkDetail> cocktails = _context.FavoriteCocktails.ToList();
       
        return cocktails;
      
    }

    public bool AddDrinkToFavorites(DrinkDetail drink)
    {
        try
        {
            drink.DateModified = DateTime.Now;
            _context.FavoriteCocktails.Add(drink);
            _context.SaveChanges();
            return true;
        } catch (Exception err)
        {
            ErrorMessage($"There has been an error: {err.Message} {err.InnerException}");
            return false;
        }
    }

    public bool AddDrinkToHistory(string name, string drinkId)
    {
        try
        {
            HistoryItem historyItem = new HistoryItem();
            historyItem.Name = name;
            historyItem.DrinkId = drinkId;

            _context.History.Add(historyItem);
            _context.SaveChanges();
            return true;
        }
        catch (Exception err)
        {
            ErrorMessage($"There has been an error: {err.Message}");
            return false;
        }
    }

    public Dictionary<string, int>? GetMostSearched()
    {
        try
        {
            List<HistoryItem>? history = _context.History.ToList();

            if (history == null) return null;

            Dictionary<string, int> historyTop = history
                .GroupBy(i => i.DrinkId)
                .OrderByDescending(i => i.Count())
                .Take(10)
                .ToDictionary(
                    drink => drink.Key,
                    drink => drink.Count()
                 );

            return historyTop;

        }
        catch (Exception err) {
            ErrorMessage($"There has been an error: {err.Message}");
            return null;
        }
    }

    public string GetNameFromHistory(string id)
    {
        try
        {
            string name = _context.History.Where(i => i.DrinkId == id).Select(i => i.Name).FirstOrDefault();

            return name;
        }
        catch (Exception err)
        {
            ErrorMessage($"There has been an error: {err.Message}");
            return null;
        }
    }

    public List<HistoryItem>? GetHistory()
    {
        try
        {
            List<HistoryItem> history = _context.History.ToList();

            return history;
        }
        catch (Exception err)
        {
            ErrorMessage($"There has been an error: {err.Message}");
            return null;
        }
    }
}