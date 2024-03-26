using Drinks.JaegerByte.DataModels;
using Drinks.JaegerByte.Services;
using Spectre.Console;

namespace Drinks.JaegerByte
{
    internal class Program
    {
        static APIService Service { get; set; } = new APIService();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Categories categories = Service.GetCategories();
                SelectionPrompt<Category> categorySelectionPrompt = new SelectionPrompt<Category>();
                categorySelectionPrompt.Title = "select category";
                categorySelectionPrompt.PageSize = 20;
                foreach (Category category in categories.CategoryList)
                {
                    categorySelectionPrompt.AddChoice(category);
                }
                Category categorySelection = AnsiConsole.Prompt(categorySelectionPrompt);

                Console.Clear();
                DataModels.Drinks drinks = Service.GetDrinks(categorySelection.Name);
                SelectionPrompt<DataModels.Drink> drinkSelectionPrompt1 = new SelectionPrompt<DataModels.Drink>();
                drinkSelectionPrompt1.Title = "select drink";
                drinkSelectionPrompt1.PageSize = 20;
                foreach (DataModels.Drink drink in drinks.DrinkList)
                {
                    drinkSelectionPrompt1.AddChoice(drink);
                }
                DataModels.Drink drinkSelection = AnsiConsole.Prompt(drinkSelectionPrompt1);
                Details details = Service.GetDetails(drinkSelection.ID);

                Console.Clear();
                PrintDetails(details);
                Console.ReadKey();
            }
        }
        static void PrintDetails(Details details)
        {
            Table detailsTable = new Table();
            detailsTable.AddColumn("Property");
            detailsTable.AddColumn("Value");
            detailsTable.ShowRowSeparators = true;
            foreach (var property in details.DetailList[0].GetType().GetProperties())
            {
                var value = property.GetValue(details.DetailList[0]);
                if (value != null)
                {
                    detailsTable.AddRow($"{property.Name}", value.ToString());
                }
            }
            AnsiConsole.Render(detailsTable);
        }
    }
}
