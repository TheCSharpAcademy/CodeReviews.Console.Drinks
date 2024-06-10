
using Drinks.DataAccess.Repositories;
using Drinks.Database;

namespace Drinks.DataAccess;

internal class RepositoryManager
{
    private readonly DbManager _dbManager;
    
    private DrinkCountRepository _drinkCountRepository;
    private FavoriteDrinkRepository _favoriteDrinkRepository;
    
    public RepositoryManager(DbManager dbManager)
    {
        _dbManager = dbManager;
    }

    internal DrinkCountRepository DrinkCountRepository
    {
        get
        {
            if(_drinkCountRepository == null)
            {
                _drinkCountRepository = new DrinkCountRepository(_dbManager);
            }
            return _drinkCountRepository;
        }
    }

    internal FavoriteDrinkRepository FavoriteDrinkRepository
    {
        get
        {
            if(_favoriteDrinkRepository == null)
            {
                _favoriteDrinkRepository = new FavoriteDrinkRepository(_dbManager);
            }
            return _favoriteDrinkRepository;
        }
    }

}