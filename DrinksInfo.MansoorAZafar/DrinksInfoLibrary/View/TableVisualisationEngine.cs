using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DrinksInfoLibrary.View;
internal static class TableVisualisationEngine
{
	public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class
	{
		System.Console.Clear();
		
		if(tableName == null) 
			tableName = "";
		
		System.Console.WriteLine("\n\n");

		ConsoleTableBuilder
			.From(tableData)
			.WithColumn(tableName)
			.ExportAndWriteLine();
		System.Console.WriteLine("\n\n");
	}
}
