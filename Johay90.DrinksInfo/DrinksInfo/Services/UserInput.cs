using Spectre.Console;

public class UserInput
{
    public void Header()
    {
        AnsiConsole.Clear();

        AnsiConsole.Write(new FigletText("Drinks Info")
        .Centered()
        .Color(Color.DarkCyan));
    }

    public DrinksCategory PickCategory(List<DrinksCategory> drinksCategories)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<DrinksCategory>()
                .Title("Pick a [blue]drinks category[/]?")
                .PageSize(10)
                .AddChoices(drinksCategories));
    }

    public Drink PickDrinkType(List<Drink> drinkTypes)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<Drink>()
                .Title("Pick a [blue]drinks type[/]?")
                .PageSize(10)
                .AddChoices(drinkTypes));
    }

    public DrinkDetail PickDrink(List<DrinkDetail> drinks)
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<DrinkDetail>()
                .Title("Pick a [blue]drink[/]?")
                .PageSize(10)
                .AddChoices(drinks));
    }

    public void ViewDrink(DrinkDetail drink)
{
    var type = drink.GetType();
    var props = type.GetProperties();

    var table = new Table()
        .Border(TableBorder.Rounded)
        .BorderColor(Color.Green1)
        .AddColumn(new TableColumn("[bold lime]Property[/]").Centered())
        .AddColumn(new TableColumn("[bold lime]Value[/]").Centered());

    bool firstRow = true;

    foreach (var item in props)
    {
        var value = item.GetValue(drink);
        if (value is not null && value.ToString().Length > 0)
        {
            if (!firstRow)
            {
                table.AddEmptyRow();
            }
            table.AddRow($"[bold yellow]{item.Name}[/]", $"[aqua]{value}[/]");
            firstRow = false;
        }
    }

    AnsiConsole.Write(
        new Panel(table)
            .BorderColor(Color.Orange1)
            .Header("[bold red]Drink Details[/]", Justify.Center)
    );

    AnsiConsole.MarkupLine("[bold red]Press any key to return to the main menu[/]");
    Console.ReadKey(true);
}
}

