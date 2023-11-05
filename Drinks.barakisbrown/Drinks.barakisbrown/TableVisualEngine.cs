using Drinks.barakisbrown.Models;
using Spectre.Console;

namespace Drinks.barakisbrown;

public static class TableVisualEngine
{
	public static void ShowDrinkInfo(List<DrinkDetail> detail, string drinkName)
	{
		AnsiConsole.Clear();
		AnsiConsole.MarkupLineInterpolated($"[white blink]Currently there are {detail.Count} of Drink {drinkName}[/]");

		AnsiConsole.WriteLine("Press any key");
		Console.ReadKey(true);

	}
}

