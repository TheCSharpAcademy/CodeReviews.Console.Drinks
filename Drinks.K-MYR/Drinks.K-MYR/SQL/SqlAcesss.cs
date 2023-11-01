using Microsoft.Data.Sqlite;
using System.Configuration;

namespace Drinks.K_MYR;

internal class SqlAcess
{
    private readonly string _connectionString;

    public SqlAcess()
    {
        _connectionString = $"DataSource={ConfigurationManager.AppSettings.Get("dbName")};";
        CreateDbAndTables();
    }

    public void CreateDbAndTables()
    {
        try
        {
            using SqliteConnection connection = new(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"CREATE TABLE IF NOT EXISTS drink (
                                                                    id INTEGER PRIMARY KEY AUTOINCREMENT,   
                                                                    api_id INTEGER UNIQUE,                                                        
                                                                    name TEXT ,                                                                                                                                    
                                                                    last_searched TEXT,
                                                                    saved INTEGER
                                                                  )";
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            AnsiConsole.Write(new Panel($"An Error Occured Initializing The Database: {ex.Message} | Press Any Key To Continue Regardless"));
            Console.ReadKey();
        }
    }

    public IEnumerable<Drink> GetDrinksByLastSearched()
    {
        try
        {
            using SqliteConnection connection = new(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM (SELECT * FROM drink ORDER BY drink.last_searched DESC) LIMIT 20";

            var reader = command.ExecuteReader();

            List<Drink> drinks = new();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    drinks.Add(new Drink(reader.GetInt32(1), reader.GetString(2)));
                }
            }
            return drinks;
        }
        catch (Exception ex)
        {
            throw new Exception($"An Error Occured Calling The Database: {ex.Message}");
        }
    }

    public IEnumerable<Drink> GetDrinksByFavourite()
    {
        try
        {
            using SqliteConnection connection = new(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT *  FROM drink WHERE saved = 1";

            var reader = command.ExecuteReader();

            List<Drink> drinks = new();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    drinks.Add(new Drink(reader.GetInt32(1), reader.GetString(2)));
                }
            }
            return drinks;
        }
        catch (Exception ex)
        {
            throw new Exception($"An Error Occured Calling The Database: {ex.Message}");
        }

    }

    public bool DrinkRecordExists(int drinkId)
    {
        try
        {
            using SqliteConnection connection = new(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT EXISTS (SELECT 1 FROM drink WHERE api_id = @id)";
            command.Parameters.AddWithValue("@id", drinkId);

            return Convert.ToInt32(command.ExecuteScalar()) == 1;
        }
        catch (Exception ex)
        {
            throw new Exception($"An Error Occured Calling The Database: {ex.Message}");
        }
    }

    public bool DrinkIsFavourite(int drinkId)
    {
        try
        {
            using SqliteConnection connection = new(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();

            command.CommandText = $"SELECT EXISTS (SELECT * FROM drink WHERE drink.api_id = @id AND saved = 1 LIMIT 1)";
            command.Parameters.AddWithValue("@id", drinkId);

            return Convert.ToInt32(command.ExecuteScalar()) == 1;
        }
        catch (Exception ex)
        {
            throw new Exception($"An Error Occured Calling The Database: {ex.Message}");
        }
    }

    public void InsertDrinkIntoDb(int drinkId, string drinkName, DateTime searchDate)
    {
        try
        {
            using SqliteConnection connection = new(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO drink (api_id, name, last_searched, saved) VALUES (@id, @name, @date, 0)";
            command.Parameters.AddWithValue("@id", drinkId);
            command.Parameters.AddWithValue("@name", drinkName);
            command.Parameters.AddWithValue("@date", searchDate.ToString("yyyy / MM / dd hh\\:mm\\:ss"));
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception($"An Error Occured Calling The Database: {ex.Message}");
        }
    }

    public void UpdateDrinkById(int drinkId, string args)
    {
        try
        {
            using SqliteConnection connection = new(_connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"UPDATE drink SET {args} WHERE drink.api_id = @id";            
            command.Parameters.AddWithValue("@id", drinkId);

            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception($"An Error Occured Calling The Database: {ex.Message}");
        }
    }
}
