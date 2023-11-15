using ConsoleTableExt;
using System.Diagnostics.CodeAnalysis;

namespace Drinks_Info
{
	internal class TableVisualization
	{
		public static void ShowTable<T>(List<T> tableDate, [AllowNull] string tableName) where T: class
		{
			Console.Clear();
			if (tableName == null)
				tableName = "";
            Console.WriteLine("\n\n");
			ConsoleTableBuilder
				.From(tableDate)
				.WithColumn(tableName)
				.WithFormat(ConsoleTableBuilderFormat.Alternative)
				.ExportAndWriteLine(TableAligntment.Center);
			Console.WriteLine("\n\n");
		}
	}
}
