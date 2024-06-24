namespace Drinks.barakisbrown;

using ConsoleTableExt;
using System.Diagnostics.CodeAnalysis;

public static class TableVisualEngine
{
    public static void ShowDrinkInfo<T>(List<T> detail, [AllowNull] string drinkName) where T : class
    {
        Console.Clear();

        drinkName ??= string.Empty;

        Console.WriteLine("\n\n");

        ConsoleTableBuilder
            .From(detail)
            .WithColumn(drinkName)
            .WithFormat(ConsoleTableBuilderFormat.Minimal)
            .ExportAndWriteLine(TableAligntment.Center);

        Console.WriteLine("Press any key to return to chose another drink.");
        Console.ReadKey(true);
    }
}