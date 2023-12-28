using drinks_info;

internal class Program
{
    private static void Main(string[] args)
    {
        string connectionString = Data.ConnectionString();
        Helpers.SetEnvironmentVariables();
        Data.Init();
        Menu.MainMenu();
    }
}