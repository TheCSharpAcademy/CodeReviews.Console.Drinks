using ConsoleTableExt;
using System.Diagnostics.CodeAnalysis;

namespace Drinks.kjanos89;

public class Menu
{
    public static void ShowData<T>(List<T> data, [AllowNull] string name) where T : class
    {
        Console.Clear();
        if(name== null)
        {
            name = "";
        }
        Console.WriteLine();
        ConsoleTableBuilder.From(data).WithColumn(name).ExportAndWriteLine();
        Console.WriteLine();
    }
}