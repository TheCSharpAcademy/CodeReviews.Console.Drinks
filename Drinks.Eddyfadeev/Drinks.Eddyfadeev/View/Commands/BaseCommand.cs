using Drinks.Eddyfadeev.Enums;
using Drinks.Eddyfadeev.Extensions;
using Drinks.Eddyfadeev.Handlers;
using Drinks.Eddyfadeev.Interfaces.HttpManager;
using Drinks.Eddyfadeev.Interfaces.View;
using Drinks.Eddyfadeev.Models;
using Drinks.Eddyfadeev.Services;
using Spectre.Console;

namespace Drinks.Eddyfadeev.View.Commands;

internal abstract class BaseCommand<T> : ICommand
{
    private readonly ITableConstructor _tableConstructor;
    
    private protected readonly IHttpManger HttpManager;
    
    protected BaseCommand(IHttpManger httpManager, ITableConstructor tableConstructor)
    {
        HttpManager = httpManager;
        _tableConstructor = tableConstructor;
    }
    
    public abstract void Execute();
    
    private protected abstract Models.Drinks FetchQuery(T input);
    
    private protected Drink FetchDrink(string drinkName) =>
        HttpManager
            .GetResponse(ApiEndpoints.Search.CocktailByName, drinkName).DrinksList[0];
    
    private protected void DisplayDrinkDetail(Drink drink)
    {
        var table = _tableConstructor.CreateDrinkTable(drink);

        AnsiConsole.Write(table);
        HelpService.WaitForEnter();
    }
    
    private protected static string? GetUserDrinkChoice(Models.Drinks drinks)
    {
        var drinkNames = FetchDrinkNames(drinks);
        
        return GetUserChoice(drinkNames, Messages.NoDrinksFound);
    }
    
    private protected static void HandleNoResults(string message) =>
        AnsiConsole.MarkupLine($"[red]{message}[/]");
    
    private protected static bool IsBackOption(string userChoice) =>
        userChoice == Messages.BackOption;
    
    private static string? GetUserChoice(string[] options, string emptyMessage)
    {
        if (options.Length == 0)
        {
            HandleNoResults(emptyMessage);
            return null;
        }

        var userChoice = DynamicEntriesHandler.HandleDynamicEntries(options);
        return IsBackOption(userChoice) ? null : userChoice;
    }
    
    private static string[] FetchDrinkNames(Models.Drinks drinks) =>
        drinks.GetPropertyArray(d => d.DrinkName);
}