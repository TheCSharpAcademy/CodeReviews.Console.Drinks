using ConsoleTableExt;

namespace Drinks.w0lvesvvv
{
    public static class TableBuilder
    {
        public static void BuildTable<T>(List<T> table, ConsoleTableBuilderFormat format = ConsoleTableBuilderFormat.Alternative) where T : class
        {
            ConsoleTableBuilder.From(table)
                .WithFormat(format)
                .ExportAndWriteLine();
        }
    }
}
