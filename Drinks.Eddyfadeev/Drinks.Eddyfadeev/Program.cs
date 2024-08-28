using Drinks.Enums;
using Drinks.Exceptions;
using Drinks.Interfaces.Handlers;
using Drinks.Services;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace Drinks;

internal static class Program
{
    static void Main(string[] args)
    {
        var services = ServicesConfigurator.ServiceCollection;
        var serviceProvider = services.BuildServiceProvider();
        
        var menuEntriesHandler = serviceProvider.GetRequiredService<IMenuEntriesHandler<MainMenuEntries>>();
        
        while (true)
        {
            Console.Clear();
            try
            {
                menuEntriesHandler.HandleMenu();
            }
            catch (HttpRequestException ex)
            {
                AnsiConsole.MarkupLine(
                    "[red]Problem with the connection to the server. Please try again later.[/]");
                AnsiConsole.MarkupLine($"[red]{ ex.Message }[/]");
                HelpService.WaitForEnter();
            }
            catch (ReturnToPreviousMenuException)
            {
                // return to the previous menu
            }
            catch (ExitApplicationException ex)
            {
                AnsiConsole.MarkupLine($"[white]{ ex.Message }[/]");
                break;
            }
        }
    }
}
