namespace Drinks.Mateusz_Platek;

public static class Program
{
    public static async Task Main()
    {
        DatabaseHelper.CreateDatabase();
        DatabaseHelper.CreateTables();
        await Menu.Run();
    }
}