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
                idDrink INTEGER Primary Key,
                strDrink TEXT NOT NULL
            );
            CREATE TABLE IF NOT EXISTS DrinkCounts(
                idDrink INTEGER Primary Key,
                strDrink TEXT NOT NULL,
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
                    Insert into FavoriteDrinks (idDrink, strDrink)
                    Values(@idDrink, @strDrink)  
                  ";
        using(var connection = GetConnection())
        {
            return connection.Execute(sql, parameters);
        }
    }

    internal Drink? GetFavoriteDrinkById(int id)
    {
        var sql = @"Select * From FavoriteDrinks Where idDrink = @idDrink";
        using(var connection = GetConnection())
        {
            return connection.QueryFirstOrDefault<Drink>(sql, new {idDrink=id});
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
                    Insert into DrinkCounts (idDrink, strDrink, SearchCount)
                    Values(@idDrink, @strDrink, @SearchCount)  
                  ";
        using(var connection = GetConnection())
        {
            return connection.Execute(sql, parameters);
        }
    }

    internal DrinkCount? GetDrinkCountById(int id)
    {
        var sql = @"Select * From DrinkCounts Where idDrink = @idDrink";
        using(var connection = GetConnection())
        {
            return connection.QueryFirstOrDefault<DrinkCount>(sql, new {idDrink=id});
        }
    }

    internal int UpdateDrinkCount(DrinkCount parameters)
    {
        var sql = @"
                    Update DrinkCounts
                    Set
                        strDrink = @strDrink, 
                        SearchCount = @SearchCount
                    Where
                        idDrink = @idDrink
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