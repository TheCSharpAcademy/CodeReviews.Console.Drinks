
using Drinks.Database;

namespace Drinks.DataAccess.Repositories;

internal class DrinkCountRepository
{
    private readonly DbManager _dbManager;

    public DrinkCountRepository(DbManager dbManager)
    {
        _dbManager = dbManager;
    }
    
}