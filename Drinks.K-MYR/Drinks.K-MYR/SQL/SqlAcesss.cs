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
    
    public IEnumerable<Drink> GetDrinksByLastSearched()
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
                drinks.Add(new Drink (reader.GetInt32(1), reader.GetString(2)));
            }
        }

        return drinks;
    }
   
    public IEnumerable<Drink> GetDrinksByFavourite()
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
                drinks.Add(new Drink (reader.GetInt32(1), reader.GetString(2)));
            }
        }

        return drinks;
    }

    public bool DrinkRecordExists(int drinkId)
    {
        using SqliteConnection connection = new(_connectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = $"SELECT EXISTS (SELECT 1 FROM drink WHERE api_id = {drinkId})";

        return Convert.ToInt32(command.ExecuteScalar()) == 1;
    }    

    public bool DrinkIsFavourite(int drinkId)
    {
        using SqliteConnection connection = new(_connectionString);
        connection.Open();
        var command = connection.CreateCommand();

        command.CommandText = $"SELECT EXISTS (SELECT * FROM drink WHERE drink.api_id = {drinkId} AND saved = 1 LIMIT 1)";

        return Convert.ToInt32(command.ExecuteScalar()) == 1;
    }

    public void InsertDrinkIntoDb(int drinkId, string drinkName, DateTime searchDate)
    {
        using SqliteConnection connection = new(_connectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = $"INSERT INTO drink (api_id, name, last_searched, saved) VALUES ({drinkId}, '{drinkName}', '{searchDate:yyyy/MM/dd hh\\:mm\\:ss}', 0)";

        command.ExecuteNonQuery();
    }

    public void UpdateDrinkById(int drinkId, string args)
    {
        using SqliteConnection connection = new(_connectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = $"UPDATE drink SET {args} WHERE drink.api_id = {drinkId}";

        command.ExecuteNonQuery();
    }    
}
