using Drinks.FunRunRushFlush.Data;
using Drinks.FunRunRushFlush.Data.Model;
using Drinks.FunRunRushFlush.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Drinks.FunRunRushFlush.Services;

public class DrinkService : IDrinkService
{
    private readonly DrinksRequest _drinkReq;
    private readonly ILogger<DrinkService> _log;

    public DrinkService(DrinksRequest drinkReq, ILogger<DrinkService> logger)
    {
        _drinkReq = drinkReq;
        _log = logger;
    }

    public async Task<DrinksResponse?> ShowAllCategoryAsync()
    {
        try
        {
            var response = await _drinkReq.GetAllCategorysAsync();
            return response;
        }
        catch (Exception ex)
        {
            _log.LogError(ex.Message, ex);
            return null;
        }
    }


    public async Task<DrinksResponse?> ShowAllDrinksFromCategoryAsync(string selection)
    {
        try
        {
            var response = await _drinkReq.GetDrinksFromCategoryAsync(selection);
            return response;
        }
        catch (Exception ex)
        {
            _log.LogError(ex.Message, ex);
            return null;
        }
    }

    public async Task<DrinksResponse?> ShowDrinkInfoForIdAsync(string selection)
    {
        try
        {
            var response = await _drinkReq.GetDrinkInfoForIdAsync(selection);
            return response;
        }
        catch (Exception ex)
        {
            _log.LogError(ex.Message, ex);
            return null;
        }
    }
}
