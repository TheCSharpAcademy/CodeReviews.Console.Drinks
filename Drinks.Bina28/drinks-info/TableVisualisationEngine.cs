
using ConsoleTableExt;


namespace Drinks.Bina28.drinks_info;

public class TableVisualisationEngine
{
	public static void ShowTable<T>(List<T> tableData, string? tableName = null) where T : class
	{

		Console.Clear();
		Console.WriteLine("\x1b[3J");

		Console.WriteLine("\n");

		if (!string.IsNullOrEmpty(tableName))
		{
			// Get console width
			int consoleWidth = Console.WindowWidth;

			// Create the styled and colored table name
			string styledName = $"\x1b[1;36m=== {tableName.ToUpper()} ===\x1b[0m"; 

			// Calculate padding to center the styled name
			int padding = (consoleWidth - RemoveAnsiCodes(styledName).Length) / 2;

			// Print the styled table name
			Console.WriteLine(new string(' ', Math.Max(0, padding)) + styledName);
			Console.WriteLine(); // Add a blank line after the title
		}

		if (tableData.Count == 0)
		{
			Console.WriteLine("\x1b[31mNo data available.\x1b[0m\n"); // Red text for "No data"
			return;
		}

		// Build and display the table
		ConsoleTableBuilder
			.From(tableData)
			.WithFormat(ConsoleTableBuilderFormat.Alternative)
			.ExportAndWriteLine(TableAligntment.Center);

		Console.WriteLine("\n");
	}

	// Helper to calculate string length without ANSI codes
	private static string RemoveAnsiCodes(string input)
	{
		return System.Text.RegularExpressions.Regex.Replace(input, @"\x1b\[[0-9;]*m", "");
	}


}