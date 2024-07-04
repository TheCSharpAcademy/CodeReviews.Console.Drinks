using System.Net.Http.Headers;
using System.Text.Json;
using DrinksInfo.ukpagrace.Controller;
using DrinksInfo.ukpagrace.Service;
using Spectre.Console;



class Program
{
    
     public static async Task Main()
     {
        try
        {
            DrinksController controller = new DrinksController();
            DrinksService service = new DrinksService();
            var categories = await service.ProcessCategoriesAsync();
            controller.ShowMenu(categories);
            var id = AnsiConsole.Ask<int>("Enter an [green]id[/]?");
            var menu = await service.ProcessCategoryAsync(categories[id].Name);

            controller.ShowDrinks(menu);

            var drinkId = AnsiConsole.Ask<int>("Enter an [green]id[/]?");

            var details = await service.ProcessDrinkDetailsAsync(drinkId);

            controller.ShowDrinkDetails(details);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}



