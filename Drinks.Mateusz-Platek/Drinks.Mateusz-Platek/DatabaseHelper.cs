using System.Data.SqlClient;

namespace Drinks.Mateusz_Platek;

public static class DatabaseHelper
{
    public static void CreateDatabase()
    {
        using SqlConnection sqlConnection = new SqlConnection(@"Server=(localdb)\DrinksInfo;Database=master;Trusted_Connection=True;");
        sqlConnection.Open();
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = @"
                IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'drinksInfo')
                    CREATE DATABASE drinksInfo";
        sqlCommand.ExecuteNonQuery();
    }
    
    public static void CreateTables()
    {
        using SqlConnection sqlConnection = new SqlConnection(@"Server=(localdb)\DrinksInfo;Database=drinksInfo;Trusted_Connection=True;");
        sqlConnection.Open();
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = @"
            IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='drinksSearchCount' AND xtype='U')
                CREATE TABLE drinksSearchCount
                (
                    drinkSearchCountID int identity
                        constraint drinksSearchCount_pk
                            primary key,
                    apiID              int           not null
                        constraint drinksSearchCount_pk_2
                            unique,
                    count              int default 1 not null,
                    name               varchar(255)  not null
                )
            
            IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='favoriteDrinks' AND xtype='U')
                CREATE TABLE favoriteDrinks
                (
                    favoriteDrinkID int identity
                        constraint favoriteDrinks_pk
                            primary key,
                    apiID           int          not null
                        constraint favoriteDrinks_pk_2
                            unique,
                    name            varchar(255) not null
                )";
        sqlCommand.ExecuteNonQuery();
    }
}