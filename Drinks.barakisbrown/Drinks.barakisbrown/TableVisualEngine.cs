using System;
using System.Diagnostics.CodeAnalysis;
using ConsoleTableExt;

namespace Drinks.barakisbrown
{
	public class TableVisualEngine
	{
		public TableVisualEngine()
		{
		}

		public static void ShowTable<T>(List<T> tableData, [AllowNull]string tableName) where T : class
		{
			if (tableName == null)
				tableName = string.Empty;

			ConsoleTableBuilder
				.From(tableData)
				.WithColumn(tableName)
				.ExportAndWriteLine();
		}
	}
}

