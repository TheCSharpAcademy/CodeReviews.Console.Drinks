
using Drinks.Database;

namespace Drinks.DataAccess.Repositories;

internal class FavoriteDrinkRepository
{
    private readonly DbManager _dbManager;

    public FavoriteDrinkRepository(DbManager dbManager)
    {
        _dbManager = dbManager;
    }

    

}