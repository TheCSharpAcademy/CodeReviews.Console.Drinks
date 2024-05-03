using System.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DrinksInfo
{
    public class SearchedDrinks
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        internal List<DrinkDB> Get()
        {
            List<DrinkDB> searchedDrinks = new();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM SearchedDrinks";

                searchedDrinks = connection.Query<DrinkDB>(query).ToList();
            }
            return searchedDrinks;
        }
        internal void Write(DrinkDB drink)
        {
            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"INSERT INTO SearchedDrinks(id,category,name) VALUES('{drink.Id}', '{drink.Category}', '{drink.Name}')";

                tableCmd.ExecuteNonQuery();
            }
        }   
    }
}

