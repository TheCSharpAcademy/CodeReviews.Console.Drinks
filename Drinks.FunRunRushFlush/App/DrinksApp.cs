using Drinks.FunRunRushFlush.App.Views;
using Drinks.FunRunRushFlush.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Spectre.Console;

namespace Drinks.FunRunRushFlush.App;

public class DrinksApp
{
    private DrinksCategoryView _categoryView;
    private ILogger<DrinksApp> _log;

    public DrinksApp(DrinksCategoryView categoryView, ILogger<DrinksApp> log)
    {
        _categoryView = categoryView;
        _log = log;
    }

    public async Task RunApp()
    {
        try
        {
            await _categoryView.RunCatergoryView();
        }
        catch (Exception ex)
        {
            _log.LogError(ex.Message, ex);
            await _categoryView.RunCatergoryView();
        }
    }
}
