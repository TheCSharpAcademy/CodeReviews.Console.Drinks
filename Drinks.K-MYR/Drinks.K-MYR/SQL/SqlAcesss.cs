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
                                                                    saved BOOL
                                                                  )";                            
        command.ExecuteNonQuery(); 
    }    
    
    public IEnumerable<Drink> GetDrinksByLastSearched()
    {
        using SqliteConnection connection = new(_connectionString);
        var command = connection.CreateCommand();
        command.CommandText = @"SELECT TOP 10 * FROM (SELECT * FROM drink ORDER BY DESC last_searched)";

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
        command.CommandText = "SELECT *  FROM drink WHERE saved = true";

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
        command.CommandText = $"EXISTS(SELECT 1 FROM drink WHERE drink.api = {drinkId})";

        return(Convert.ToInt32(command.ExecuteScalar()) == 1 ? true : false);
    }    

    public void InsertDrinkIntoDb(int drinkId, string drinkName, DateTime searchDate)
    {
        using SqliteConnection connection = new(_connectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = $"INSERT INTO drink (api_id, name, last_search, saved) VALUES ({drinkId}, '{drinkName}', '{searchDate.ToString("yyyy/MM/dd hh\\:mm\\:ss")}', FALSE)";

        command.ExecuteNonQuery();
    }

    public void UpdateDrinkById(int drinkId, string args)
    {
        using SqliteConnection connection = new(_connectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = $"UPDATE drink SET {args} WHERE drink.id = {drinkId}";

        command.ExecuteNonQuery();
    }    
}
