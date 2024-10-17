namespace hasona23.Drinks
{
    using Spectre.Console;
    using System.Linq;
    internal class Program
    {
        static async Task Main()
        {
           
            while (true)
            {
                IEnumerable<string> categories =(await ResponseManager.GetCategories())
                    .Append(new DrinkCategory("Exit")).Select(c => c.Category);
                //Shows Categories and exit
                
                string categoryPrompt = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .AddChoices(categories)
                    .Title("[white]Choose Category:[/]")
                    .MoreChoicesText("[green]Move up and down to reveal more Categories.[/]\n[red](Exit at the end)[/]")
                    );
                
                DrinkCategory category = new DrinkCategory(categoryPrompt);
                if (category.Category == "Exit")
                {
                    break;
                }
                    Console.WriteLine(category.Category);
                IEnumerable<Drink> drinks = await ResponseManager.GetDrinks(category);
                
                Drink drink = AnsiConsole.Prompt(new SelectionPrompt<Drink>().AddChoices(drinks));
                drink = await ResponseManager.GetDrinkDetails(drink) ;
                string ingredients = string.Empty;
                foreach (string item in drink.GetIngredients()) 
                {
                    ingredients += $"-> {item}\n";
                }
                Panel panel = new Panel($"[white]{ingredients}[/]").Header($"[red]{drink.Name}[/]");
                panel.Border = BoxBorder.Double;
                panel.Padding = new Padding(2,1);
                
                panel.HeaderAlignment(Justify.Center);
                AnsiConsole.Write(panel);
                Console.WriteLine("press enter to continue...");
                Console.ReadLine();
                Console.Clear();
                
            }
        }

      
    }
}
