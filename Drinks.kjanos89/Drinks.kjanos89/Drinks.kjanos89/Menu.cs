using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks.kjanos89
{
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
}
