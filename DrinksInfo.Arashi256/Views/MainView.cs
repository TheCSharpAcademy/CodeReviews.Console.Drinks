using Spectre.Console;
using DrinksInfo.Arashi256.Classes;
using DrinksInfo.Arashi256.Models;
using System.Reflection;
using System.ComponentModel.Design;

namespace DrinksInfo.Arashi256.Views
{
    internal class MainView
    {
        private Table? _tblMainMenu;
        private string _appTitle = "[DRINKS KIOSK]";
        private FigletText _figletAppTitle;

        private DrinksService _drinksService;
        private bool _isRunning = true;

        public MainView()
        {
            _figletAppTitle = new FigletText(_appTitle);
            _figletAppTitle.Centered();
            _figletAppTitle.Color = Color.Yellow3_1;
            _drinksService = new DrinksService();
            Process();
        }

        private void Process()
        {
            do
            {
                Console.Clear();
                AnsiConsole.Write(_figletAppTitle);
                ProcessDrinkCategories();
            } while (_isRunning);
            AnsiConsole.MarkupLine("[lime]Goodbye![/]");
            Environment.Exit(0);
        }

        private void ProcessDrinkCategories()
        {
            List<Category>? drinksCategories;
            _tblMainMenu = new Table();
            _tblMainMenu.AddColumn(new TableColumn("[white]CHOICE[/]").Centered());
            _tblMainMenu.AddColumn(new TableColumn("[white]CATEGORY[/]").LeftAligned());
            _tblMainMenu.Alignment(Justify.Center);
            int selectedValue = 0;
            drinksCategories = _drinksService.GetCategories();
            if (drinksCategories != null || drinksCategories.Count == 0)
            {
                for (int i = 0; i < drinksCategories.Count; i++)
                {
                    _tblMainMenu.AddRow($"[yellow]{i + 1}[/]", $"[lightgoldenrod2]{drinksCategories[i].strCategory}[/]");
                }
                _tblMainMenu.AddRow($"[yellow]{drinksCategories.Count + 1}[/]", $"[honeydew2]Exit Kiosk[/]");
                AnsiConsole.Write(_tblMainMenu);
                selectedValue = CommonUI.MenuOption($"Enter an option between 1 and {drinksCategories.Count + 1}: ", 1, drinksCategories.Count + 1);
                if (selectedValue == drinksCategories.Count + 1)
                    _isRunning = false;
                else
                    ProcessDrinks(drinksCategories[selectedValue - 1].strCategory);
            }
            else
            {
                AnsiConsole.Markup($"[red]Error contacting remote API for drinks categories or no categories returned. Please contact your beverage provider.[/]\n");
            }
        }

        private void ProcessDrinks(string category)
        {
            List<Drink>? drinks;
            Table drinksTable = new Table();
            drinksTable.AddColumn(new TableColumn("[white]CHOICE[/]").Centered());
            drinksTable.AddColumn(new TableColumn("[white]DRINK[/]").LeftAligned());
            drinksTable.Alignment(Justify.Center);
            int selectedValue = 0;
            drinks = _drinksService.GetDrinksByCategory(category);
            if (drinks != null || drinks.Count == 0)
            {
                for (int i = 0; i < drinks.Count; i++)
                {
                    drinksTable.AddRow($"[yellow]{i + 1}[/]", $"[lightgoldenrod2]{drinks[i].strDrink}[/]");
                }
                drinksTable.AddRow($"[yellow]{drinks.Count + 1}[/]", $"[honeydew2]Go Back[/]");
                AnsiConsole.Write(drinksTable);
                selectedValue = CommonUI.MenuOption($"Enter an option between 1 and {drinks.Count + 1}: ", 1, drinks.Count + 1);
                if (selectedValue == drinks.Count + 1)
                    return;
                else
                   ProcessDrinkDetail(drinks[selectedValue - 1].idDrink, drinks[selectedValue - 1].strDrink);
            }
            else
            {
                AnsiConsole.Markup($"[red]Error contacting remote API for drinks or no drinks returned. Please contact your beverage provider.[/]\n");
            }
        }

        private void ProcessDrinkDetail(string did, string name)
        {
            List<DrinkDetailKeyValue> drinkDetails = ParseDrinkDetails(_drinksService.GetDrink(did));
            AnsiConsole.Markup($"\n[white]Drink details for: {name.ToUpper()}[/]\n");
            Table drinkTable = new Table();
            drinkTable.AddColumn(new TableColumn("[white]PART[/]").LeftAligned());
            drinkTable.AddColumn(new TableColumn("[white]DETAIL[/]").LeftAligned());
            drinkTable.Alignment(Justify.Center);
            if (drinkDetails != null && drinkDetails.Count > 0)
            {
                foreach (DrinkDetailKeyValue drinkPart in drinkDetails)
                {
                    drinkTable.AddRow($"[yellow]{drinkPart.Key}[/]", $"[honeydew2]{drinkPart.Value}[/]");
                }
                AnsiConsole.Write(drinkTable);
            }
            else
            {
                AnsiConsole.Markup($"[red]Error contacting remote API for drink details or no drink details returned. Please contact your beverage provider.[/]\n");
            }
            CommonUI.Pause("yellow");
        }

        private List<DrinkDetailKeyValue> ParseDrinkDetails(DrinkDetail drinkDetail)
        {
            string formattedName = string.Empty;
            List<DrinkDetailKeyValue> prepList = new();
            foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
            {
                if (prop.Name.Contains("str"))
                {
                    formattedName = prop.Name.Substring(3);
                }
                if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                {
                    prepList.Add(new DrinkDetailKeyValue
                    {
                        Key = formattedName,
                        Value = prop.GetValue(drinkDetail)
                    });
                }
            }
            return prepList;
        }
    }
}
