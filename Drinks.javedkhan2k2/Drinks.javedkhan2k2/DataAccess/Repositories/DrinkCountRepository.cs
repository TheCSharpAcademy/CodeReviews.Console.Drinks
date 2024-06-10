
using Drinks.Database;
using Drinks.Models;

namespace Drinks.DataAccess.Repositories;

internal class DrinkCountRepository
{
    private readonly DbManager _dbManager;

    public DrinkCountRepository(DbManager dbManager)
    {
        _dbManager = dbManager;
    }
    
    public void UpdateDrinkCount(Drink drink)
    {
        var drinkCount = _dbManager.GetDrinkCountById(Convert.ToInt32(drink.idDrink));
        if(drinkCount == null)
        {
            var record = _dbManager.AddDrinkCount(new DrinkCount{ idDrink = drink.idDrink, strDrink = drink.strDrink, SearchCount = 1 });
        }
        else
        {
            drinkCount.SearchCount += 1;
            _dbManager.UpdateDrinkCount(drinkCount);
        }
    }

    internal IEnumerable<DrinkCount>? GetTopTenSearchedDrinks() => _dbManager.GetTopTenSearchedDrinks();
    
}