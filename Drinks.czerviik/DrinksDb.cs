using System.Data.SQLite;
using Dapper;

namespace drinks_info;

public class DrinksDb
{
    protected string _connectionString;
    public DrinksDb(string connectionString)
    {
        _connectionString = connectionString;
        InitializeDatabase();
    }
    private void InitializeDatabase()
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            string commandText = @"
                CREATE TABLE IF NOT EXISTS drinks_db(
                    id TEXT PRIMARY KEY, 
                    name TEXT,
                    favorite TEXT,
                    search_count INTEGER)";

            SQLiteCommand command = new(commandText, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private void ExecuteCommand(string commandText)
    {
        try
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                SQLiteCommand command = new(commandText, connection);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        catch (SQLiteException ex)
        {
            UserInterface.DisplayMessage($"SQLite error: {ex.Message}");
        }
    }

    private int GetScalarCommand(string command, object parameters = null)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            return connection.QuerySingleOrDefault<int>(command, parameters);
        }
    }

    public void InsertSearch(Drink userDrink)
    {
        var command = @$"
        INSERT INTO drinks_db (id, name, favorite, search_count)
        VALUES ('{userDrink.Id}', '{userDrink.Name}', 'False', 1)
        ON CONFLICT(id) DO UPDATE SET search_count = search_count + 1";

        ExecuteCommand(command);
    }

    public void AddToFavorites(string drinkId)
    {
        var command = @$"
        UPDATE drinks_db
        SET favorite = 'True'
        WHERE id = {drinkId}";

        ExecuteCommand(command);
    }

    public void RemoveFromFavorites(string drinkId)
    {
        var command = @$"
        UPDATE drinks_db
        SET favorite = 'False'
        WHERE id = {drinkId}";

        ExecuteCommand(command);
    }

    public bool IsFavorite(string drinkId)
    {
        var command = @$"
        SELECT EXISTS(SELECT 1 FROM drinks_db 
        WHERE id = @id AND favorite = 'True')";
        return GetScalarCommand(command, new { id = drinkId }) == 1;
    }

    public int GetSearchCount(string drinkId)
    {
        var command = @$"
        SELECT search_count FROM drinks_db
        WHERE id = @id";

        return GetScalarCommand(command, new { id = drinkId });

    }
}