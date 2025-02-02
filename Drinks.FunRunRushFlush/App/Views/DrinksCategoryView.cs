using Drinks.FunRunRushFlush.Data.Model;
using Drinks.FunRunRushFlush.Services.Interfaces;
using Spectre.Console;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

namespace Drinks.FunRunRushFlush.App.Views;

public class DrinksCategoryView
{
    private readonly IDrinkService _drink;
    private const string CloseAppString = "--Close App--";
    public DrinksCategoryView(IDrinkService drink)
    {
        _drink = drink;
    }


    public async Task RunCatergoryView()
    {

        var categorys = await _drink.ShowAllCategoryAsync();

        while (true)
        {
            AnsiConsole.Clear();

            AppHeader("Drink Info App");
            string category;
            while (true)
            {
                category = SelectCategory(categorys);

                if (category == CloseAppString && CloseApp())
                {
                    return;
                }
                else if (category != CloseAppString)
                {
                    break; 
                }
            }


            var drinks = await _drink.ShowAllDrinksFromCategoryAsync(category);

            var drink = SelectDrink(drinks);
            var drinkDetails = await _drink.ShowDrinkInfoForIdAsync(drink.IdDrink);

            CreateDetailsTable(drinkDetails);
            Console.ReadKey(true);
        }
    }

    private void CreateDetailsTable(DrinksResponse? drinkDetails)
    {
        var table = new Table().Centered().Expand();
        table.Border = TableBorder.Rounded;

        table.AddColumn("");
        table.AddColumn("Details");


        foreach (var dr in drinkDetails.Drinks)
        {
            foreach (var prop in dr.GetType().GetProperties())
            {
                var value = prop.GetValue(dr);

                if (value != null)
                {
                    table.AddRow(prop.Name, value.ToString());
                }
            }
        }
        AnsiConsole.Write(table);
    }

    private Drink SelectDrink(DrinksResponse? drinks)
    {
        var drinkChoices = drinks?.Drinks
      .Where(x => x.StrDrink != null)
      //.Select(x => x.StrDrink)?
      .ToArray();

        return AnsiConsole.Prompt(
            new SelectionPrompt<Drink>()
                .Title("[yellow]Select an option: [/]")
                .PageSize(10)
                .EnableSearch()
                .AddChoices(drinkChoices)
                .UseConverter(x => x.StrDrink)
        );
    }

    private string SelectCategory(DrinksResponse? categorys)
    {
        var catergoryChoices = categorys?.Drinks
    .Where(x => x.StrCategory != null)
    .Select(x => x.StrCategory)?
    .ToArray()
    ?? new[] { "None was Found, Try later again ..." };

        return  AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[yellow]Select an option: [/]")
                .PageSize(10)
                .EnableSearch()
                .AddChoices(catergoryChoices)
                .AddChoices(CloseAppString)
        );
    }

    public void AppHeader(string headerTitel, bool link = false)
    {
        AnsiConsole.Write(new FigletText(headerTitel).Centered().Color(Color.Blue));

        if (link)
        {
            AnsiConsole.Write(
             new Markup("[blue]Inspired by the [link=https://thecsharpacademy.com/project/15/drinks]C#Academy[/][/]")
             .Centered());
        }
        AnsiConsole.MarkupLine("");
    }

    public bool CloseApp()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<bool>($"[yellow]Are you sure you want to Close the App[/]")
            .AddChoice(true)
            .AddChoice(false)
            .DefaultValue(false)
            .WithConverter(choice => choice ? "y" : "n"));
    }

}
