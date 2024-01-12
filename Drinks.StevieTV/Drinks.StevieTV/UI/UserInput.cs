using DrinksInfo.StevieTV.Data;
using DrinksInfo.StevieTV.Helpers;
using DrinksInfo.StevieTV.Models;
using Spectre.Console;

namespace DrinksInfo.StevieTV.UI;

internal class UserInput
{
    private readonly DrinksService _drinksService = new();

    internal void GetCategoriesInput()
    {
        var availableCategories = DrinksService.GetCategories();

        var categorySelector = new SelectionPrompt<Category>();
        categorySelector.Title("Select the category you wish to view");
        categorySelector.AddChoices(availableCategories);
        categorySelector.UseConverter(category => category.strCategory);

        var categorySelected = AnsiConsole.Prompt(categorySelector);
        
        GetDrinksInput(categorySelected.strCategory);
    }

    private void GetDrinksInput(string category)
    {
        var availableDrinks = DrinksService.GetDrinksByCategory(category);

        var drinkSelector = new SelectionPrompt<Drink>();
        drinkSelector.Title("Select the drink you wish to view");
        drinkSelector.AddChoices(availableDrinks);
        drinkSelector.UseConverter(drink => drink.strDrink);

        ShowDrink(AnsiConsole.Prompt(drinkSelector));
    }

    private void ShowDrink(Drink drink)
    {
        var drinkSelected = DrinksService.GetDrink(drink);
        var thumbnail = new CanvasImage(GetDrinkThumbnail.SavedThumbnail(drink.strDrinkThumb));
        thumbnail.MaxWidth(16);

        Table details = TableVisualisation.ShowTable(drinkSelected);
        
        var layout = new Layout("Root")
            .SplitColumns(
                new Layout("Left")
                    .SplitRows(
                        new Layout("Top"),
                        new Layout("Bottom"))
                    .Ratio(1),
                new Layout("Right")
                    .Ratio((2)));

        layout["Bottom"].Update(
            new Panel(
                Align.Center(
                    thumbnail, 
                    VerticalAlignment.Middle
                    ))
                .Expand());

        layout["Top"].Update(
            new Panel(
                    Align.Center(
                        new Markup($"[blue]{drink.strDrink}[/]"),
                        VerticalAlignment.Middle))
                .Collapse());
        layout["Right"].Update(details);
        AnsiConsole.Write(layout);
        ExitProgram();
    }

    private static void ExitProgram()
    {
        if(!AnsiConsole.Confirm("Press enter to continue"))
            Environment.Exit(1);
    }
}