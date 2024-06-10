using Microsoft.Data.Sqlite;
using Dapper;
using Drinks.Models;

namespace Drinks.Database;
internal class DbManager
{
    private readonly string ConnectionString = "Data Source = drink.db";
    
    public DbManager()
    {
        CreateTables();
    }

    private void CreateTables()
    {
        var sql = @$"
            CREATE TABLE IF NOT EXISTS FavoriteDrinks(
                DrinkId INTEGER Primary Key,
                DrinkName TEXT NOT NULL
            );
            CREATE TABLE IF NOT EXISTS DrinkCounts(
                DrinkId INTEGER Primary Key,
                DrinkName TEXT NOT NULL,
                SearchCount INTEGER NOT NULL
            );
            ";
        using(var connection = GetConnection())
        {
            connection.Execute(sql);
        }
    }

    internal int AddFavriteDrink(Drink parameters)
    {
        var sql = @"
                    Insert into FavoriteDrinks (DrinkId, DrinkName)
                    Values(@DrinkId, @DrinkName)  
                  ";
        using(var connection = GetConnection())
        {
            return connection.Execute(sql, parameters);
        }
    }

    internal IEnumerable<Drink>? GetAllFavoriteDrinks()
    {
        var sql = @"Select * from FavoriteDrinks";
        using(var connection = GetConnection())
        {
            return connection.Query<Drink>(sql);
        }
    }

    internal int AddDrinkCount(DrinkCount parameters)
    {
        var sql = @"
                    Insert into DrinkCounts (DrinkId, DrinkName, SearchCount)
                    Values(@DrinkId, @DrinkName, @SearchCount)  
                  ";
        using(var connection = GetConnection())
        {
            return connection.Execute(sql, parameters);
        }
    }

    internal DrinkCount? GetDrinkCountById(int id)
    {
        var sql = @"Select * From DrinkCounts Where DrinkId = @DrinkId";
        using(var connection = GetConnection())
        {
            return connection.QueryFirstOrDefault<DrinkCount>(sql, new {DrinkId=id});
        }
    }

    internal int UpdateDrinkCount(DrinkCount parameters)
    {
        var sql = @"
                    Update DrinkCounts
                    Set
                        DrinkName = @DrinkName, 
                        SearchCount = @SearchCount
                    Where
                        DrinkId = @DrinkId
                  ";
        using(var connection = GetConnection())
        {
            return connection.Execute(sql, parameters);
        }
    }

    internal IEnumerable<DrinkCount>? GetTopTenSearchedDrinks()
    {
        var sql = @"Select * from DrinkCounts Order By SearchCount Desc Limit 10";
        using(var connection = GetConnection())
        {
            return connection.Query<DrinkCount>(sql);
        }
    } 

    private SqliteConnection GetConnection()
    {
        return new SqliteConnection(ConnectionString);
    }

    
}