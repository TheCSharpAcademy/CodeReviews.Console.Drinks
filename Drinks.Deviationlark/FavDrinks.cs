using System.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DrinksInfo
{
    public class FavoriteDrinks
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        internal List<DrinkDB> Get(int num = 0)
        {
            List<DrinkDB> favDrinks;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM FavoriteDrinks";

                favDrinks = connection.Query<DrinkDB>(query).ToList();

                if (num == 0) TableVisualisation.ShowFavoriteDrinks(favDrinks);
            }
            return favDrinks;
        }

        internal void Write(DrinkDB drinkDB)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"INSERT INTO FavoriteDrinks(id,category,name) VALUES ('{drinkDB.Id}','{drinkDB.Category}', '{drinkDB.Name}')";

                tableCmd.ExecuteNonQuery();
            }
        }

        internal void Delete(string id)
        {
            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = $"DELETE FROM FavoriteDrinks WHERE Id = '{id}'";

                tableCmd.ExecuteNonQuery();
            }
        }
        
    }
}