using ConsoleTableExt;

namespace DrinksProgram;

public class TableUI
{
    public static void PrintTable(List<List<object>> tableToUI,string title, string[] columns)
    {
        ConsoleTableBuilder
        .From(tableToUI)
        .WithTitle(title)
        .WithColumn(columns)
        .WithCharMapDefinition(
                    CharMapDefinition.FramePipDefinition,
                    new Dictionary<HeaderCharMapPositions, char> {
                        {HeaderCharMapPositions.TopLeft, '╒' },
                        {HeaderCharMapPositions.TopCenter, '╤' },
                        {HeaderCharMapPositions.TopRight, '╕' },
                        {HeaderCharMapPositions.BottomLeft, '╞' },
                        {HeaderCharMapPositions.BottomCenter, '╪' },
                        {HeaderCharMapPositions.BottomRight, '╡' },
                        {HeaderCharMapPositions.BorderTop, '═' },
                        {HeaderCharMapPositions.BorderRight, '│' },
                        {HeaderCharMapPositions.BorderBottom, '═' },
                        {HeaderCharMapPositions.BorderLeft, '│' },
                        {HeaderCharMapPositions.Divider, '│' },
                    })
        .ExportAndWriteLine(TableAligntment.Center);
    
    Console.WriteLine();
    }
}