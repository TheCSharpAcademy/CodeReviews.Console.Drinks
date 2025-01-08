using Spectre.Console;

namespace Drinks
{
    internal class View
    {
        internal View()
        {
            Controller controller = new();
            Categories categories = new();
            categories.CategoriesList = controller.GetCategories();
            Category category = new();
            Drinks drinks = new();
            Drink drink = new();
            DrinkDetail drinkDetail = new();
            
            do
            {
                AnsiConsole.Clear();
                try
                {
                    SelectionPrompt<Category> categoryPrompt = new();
                    categoryPrompt.WrapAround();
                    categoryPrompt.PageSize(12);
                    categoryPrompt.AddChoices(categories.CategoriesList);
                    categoryPrompt.AddChoice(new Category { strCategory = "Exit" });
                    categoryPrompt.UseConverter(x => x.strCategory);
                    category = AnsiConsole.Prompt(categoryPrompt);
                    if (category.strCategory == "Exit") break;
                    AnsiConsole.Clear();

                    SelectionPrompt<Drink> drinkPrompt = new();
                    drinks.DrinksList = controller.GetDrinks(category.strCategory);
                    drinkPrompt = new SelectionPrompt<Drink>();
                    drinkPrompt.WrapAround();
                    drinkPrompt.PageSize(12);
                    drinkPrompt.AddChoices(drinks.DrinksList);
                    drinkPrompt.AddChoice(new Drink { strDrink = "Return" });
                    drinkPrompt.UseConverter(x => x.strDrink);
                    drink = AnsiConsole.Prompt(drinkPrompt);
                    if (drink.strDrink != "Return")
                    {
                        AnsiConsole.Clear();
                        drinkDetail = controller.GetDrinkDetail(drink.idDrink);
                        List<DetailOutPut> formatedDrinkDetail = controller.FormatDrinkDetail(drinkDetail);
                        Table table = new();
                        table.DoubleEdgeBorder();
                        table.Title(drink.strDrink);
                        table.AddColumns("Property", "Detail/Instructions");
                        table.AddRow("", "");
                        table.ShowRowSeparators = true;
                        foreach (DetailOutPut detail in formatedDrinkDetail) { table.AddRow(detail.Name, detail.Value); }
                        AnsiConsole.Write(table);
                    }
                }
                catch (Exception ex) { AnsiConsole.WriteLine(ex.Message); }
                AnsiConsole.WriteLine("Press any key to go back to Category Menu.");
                Console.ReadKey();

            } while (category.strCategory != "Exit");
            AnsiConsole.Clear();
            AnsiConsole.WriteLine("Thank you for using Drinks app.");
        }
    }
}