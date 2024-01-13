using DrinksInfo.StevieTV.Data;
using DrinksInfo.StevieTV.Helpers;
using DrinksInfo.StevieTV.Models;
using Spectre.Console;

namespace DrinksInfo.StevieTV.UI;

internal class UserInput
{
    internal void GetCategoriesInput()
    {
        var availableCategories = DrinksService.GetCategories();

        var categorySelector = new SelectionPrompt<Category>();
        categorySelector.Title("Select the category you wish to view");
        categorySelector.AddChoices(availableCategories);
        categorySelector.UseConverter(category => category.strCategory);
        categorySelector.PageSize(25);

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
        drinkSelector.PageSize(25);

        ShowDrink(AnsiConsole.Prompt(drinkSelector));
    }

    private void ShowDrink(Drink drink)
    {
        var drinkSelected = DrinksService.GetDrink(drink);

        Table details = TableVisualisation.ShowTable(drinkSelected);

        var thumbnailFilename = GetDrinkThumbnail.SavedThumbnail(drink.strDrinkThumb);
        
        var layout = new Layout("Root")
            .SplitColumns(
                new Layout("Left")
                    .SplitRows(
                        new Layout("Top").Ratio(1),
                        new Layout("Bottom").Ratio(5))
                    .Ratio(4),
                new Layout("Right")
                    .Ratio((5)));

        
        if (!string.IsNullOrWhiteSpace(thumbnailFilename))
        {
            var thumbnail = new CanvasImage(thumbnailFilename);
            thumbnail.MaxWidth(28);
            layout["Bottom"].Update(
                new Panel(
                        Align.Center(
                            thumbnail, 
                            VerticalAlignment.Middle
                        ))
                    .Expand());
        }
        else
        {
            layout["Bottom"].Update(
                new Panel(
                    Align.Center(new Text("No Image Available"))
                        )
                    .Expand());
        }

        layout["Top"].Update(
            new Panel(
                    Align.Center(
                        new Markup($"[blue]{drink.strDrink}[/]"),
                        VerticalAlignment.Middle))
                .Expand());
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