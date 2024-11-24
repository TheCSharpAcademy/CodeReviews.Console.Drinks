using DrinksInfo.UserInterface;
using Spectre.Console;

while(true)
{
    var mainSelection = AnsiConsole.Prompt(
        new SelectionPrompt<Main>()
        .AddChoices(Enum.GetValues<Main>()));

    if (mainSelection == Main.Exit)
        break;

    MainMenu mainMenu = new();
    mainMenu.ShowMenu();

    Console.Clear();
}

AnsiConsole.MarkupLine("[cyan]Thanks for using the application\nGoodbye![/]");

enum Main
{
    Categories,
    Exit
}