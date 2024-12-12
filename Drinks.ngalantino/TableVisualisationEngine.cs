
using System.Diagnostics.CodeAnalysis;
using ConsoleTableExt;

public class TableVisualisationEngine {

    public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class {
        Console.Clear();
       
        if (tableName == null)
            tableName = "";

        Console.WriteLine("\n\n");

        ConsoleTableBuilder
            .From(tableData)
            .WithColumn(tableName)
            //.WithFormat(ConsoleTableBuilderFormat.Alternative)
            .WithCharMapDefinition(new Dictionary<CharMapPositions, char> {
                {CharMapPositions.BottomLeft, '=' },
                {CharMapPositions.BottomCenter, '=' },
                {CharMapPositions.BottomRight, '=' },
                {CharMapPositions.BorderTop, '=' },
                {CharMapPositions.BorderBottom, '=' },
                {CharMapPositions.BorderLeft, '|' },
                {CharMapPositions.BorderRight, '|' },
                {CharMapPositions.DividerY, '|' },
            })
            .WithHeaderCharMapDefinition(new Dictionary<HeaderCharMapPositions, char> {
                {HeaderCharMapPositions.TopLeft, '=' },
                {HeaderCharMapPositions.TopCenter, '=' },
                {HeaderCharMapPositions.TopRight, '=' },
                {HeaderCharMapPositions.BottomLeft, '|' },
                {HeaderCharMapPositions.BottomCenter, '-' },
                {HeaderCharMapPositions.BottomRight, '|' },
                {HeaderCharMapPositions.Divider, '|' },
                {HeaderCharMapPositions.BorderTop, '=' },
                {HeaderCharMapPositions.BorderBottom, '-' },
                {HeaderCharMapPositions.BorderLeft, '|' },
                {HeaderCharMapPositions.BorderRight, '|' },
            })
            .ExportAndWriteLine(TableAligntment.Center);

        Console.WriteLine("\n\n");
    }
}