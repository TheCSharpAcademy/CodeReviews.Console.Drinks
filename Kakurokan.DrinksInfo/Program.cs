using Kakurokan.DrinksInfo.Models;
using Spectre.Console;
using System.Text.RegularExpressions;

namespace Kakurokan.DrinksInfo
{
    internal class Program
    {

        static async Task Main()
        {

            Helper.Initialize();

            var category = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Choose a [green]category[/]")
        .PageSize(15)
        .MoreChoicesText("[grey](Move up and down to reveal more categories)[/]")
        .AddChoices(Processor.GetAllCategories().Result));

            var drinks = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Choose a [green]drink[/]")
        .PageSize(15)
        .MoreChoicesText("[grey](Move up and down to reveal more categories)[/]")
        .AddChoices(Processor.GetAllDrinksByCategory(category).Result));

            Drink drink = Processor.GetDrink(drinks).Result;

            var table = new Table();

            // Add some columns
            table.AddColumn("Category");
            table.AddColumn(new TableColumn("Recipe").Centered());
                
            var properties = drink.GetType().GetProperties();
            
            for (int i = 0; i < typeof(Drink).GetProperties().Count();  i++)
            {
                if (properties[i].GetValue(drink) != null)
                {
                    string value = properties[i].GetValue(drink).ToString();
                    string propriety = Regex.Replace(properties[i].ToString(), @"^([\S]+)", "").Trim();
                    propriety = Regex.Replace(propriety, @"^(^str)+", "");
                    table.AddRow(propriety, value).LeftAligned();
                }

            }
            table.Expand();
            AnsiConsole.Write(table);

            var choice = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .AddChoices(new[] {"Home", "Leave" }));

            AnsiConsole.Clear();

            if (choice == "Home") await Main();
            Environment.Exit(0);
        }
         

    }
}