using Drinks.Eddyfadeev.Enums;
using Drinks.Eddyfadeev.Interfaces.HttpManager;
using Drinks.Eddyfadeev.Interfaces.View;
using Drinks.Eddyfadeev.Models;
using Drinks.Eddyfadeev.Services;
using Spectre.Console;

namespace Drinks.Eddyfadeev.View.Commands;

internal abstract class BaseCommand<T> : ICommand
{
    private protected const string BackOption = "Back";
    
    private readonly ITableConstructor TableConstructor;
    
    private protected readonly IHttpManger HttpManager;
    
    protected BaseCommand(IHttpManger httpManager, ITableConstructor tableConstructor)
    {
        HttpManager = httpManager;
        TableConstructor = tableConstructor;
    }
    
    public abstract void Execute();
    
    private protected abstract Eddyfadeev.Models.Drinks FetchQuery(T input);
    
    private protected abstract string[] FetchPropertyArray(Eddyfadeev.Models.Drinks drinks);
    
    private protected Drink FetchDrink(string drinkName) =>
        HttpManager
            .GetResponse(ApiEndpoints.Search.CocktailByName, drinkName).DrinksList[0];
    
    private protected void DisplayDrinkDetail(Drink drink)
    {
        var table = TableConstructor.CreateDrinkTable(drink);

        AnsiConsole.Write(table);
        HelpService.WaitForEnter();
    }
    
    private protected static void HandleNoResults(string message) =>
        AnsiConsole.MarkupLine($"[red]{message}[/]");
    
    private protected static bool IsBackOption(string userChoice) =>
        userChoice == BackOption;
}