
using Drinks.Database;
using Drinks.Models;
using Spectre.Console;

namespace Drinks.DataAccess.Repositories;

internal class FavoriteDrinkRepository
{
    private readonly DbManager _dbManager;

    public FavoriteDrinkRepository(DbManager dbManager)
    {
        _dbManager = dbManager;
    }

    public bool Add(Drink drink)
    {
        if(_dbManager.GetFavoriteDrinkById(Convert.ToInt32(drink.idDrink)) != null)
        {
            AnsiConsole.Markup($"[maroon]{drink.strDrink}[/] is already added to Favorites\n");
            return false;
        }
        _dbManager.AddFavriteDrink(drink);
        return true;
    }

    internal IEnumerable<Drink>? All() =>  _dbManager.GetAllFavoriteDrinks();
    
}