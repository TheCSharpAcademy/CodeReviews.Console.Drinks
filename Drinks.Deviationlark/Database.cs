using System.Configuration;
using Microsoft.Data.SqlClient;

namespace DrinksInfo
{
    public class DatabaseManager
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        internal void CreateTable()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText =@"if not exists(select * from sysobjects where name = 'FavoriteDrinks' and xtype = 'U')
                                        CREATE TABLE FavoriteDrinks(
                                            Id varchar(64) NOT NULL,
                                            Category varchar(64) NOT NULL,
                                            Name varchar(64) NOT NULL
                                        )  ";
                tableCmd.ExecuteNonQuery();
            }
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = @"if not exists(select * from sysobjects where name = 'SearchedDrinks' and xtype = 'U')
                                        CREATE TABLE SearchedDrinks(
                                            Id varchar(64) NOT NULL,
                                            Category varchar(64) NOT NULL,
                                            Name varchar(64) NOT NULL
                                        )";
                tableCmd.ExecuteNonQuery();
            }
        }

        
    }
}