global using System.Configuration;
using System.Data.SQLite;
using Dapper;
using Spectre.Console;

namespace DrinksInfo
{
    internal class DrinksRepo
    {
        private string? connectionString = ConfigurationManager.AppSettings.Get("DrinksConnection");

        public void CreateTable()
        {
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();

            string query = @"
                    CREATE TABLE IF NOT EXISTS drinksInfo(
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        drinkCategory TEXT NOT NULL,
                        drinkName TEXT NOT NULL,
                        favDrink TEXT NOT NULL
                        )";

            connection.Execute(query);
            connection.Close();
        }

        public void Insert(string category, string drinkName, string favDrink)
        {
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();


            var sql = "INSERT INTO drinksInfo(drinkCategory, drinkName, favDrink) VALUES (@Category, @DrinkName, @FavDrink)";
            int r = connection.Execute(sql, new {Category = category, DrinkName = drinkName, FavDrink = favDrink});

            Console.WriteLine("Rows affected: " + r);
            connection.Close();
        }

        internal void ViewFavDrinks()
        {
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();

            string sql = "SELECT * FROM drinksInfo WHERE favDrink = 'Y'";
            var query = connection.Query(sql).ToList();

            Table table = new();
            table.AddColumn("[gold1]Category[/]");
            table.AddColumn("[gold1]Drink[/]");

            foreach (var row in query)
            {
                string category = $"[springgreen2]{row.drinkCategory}[/]";
                string name = $"[springgreen2]{row.drinkName}[/]";
                table.AddRow(category, name);
            }

            AnsiConsole.Write(table);
            connection.Close();
        }

        internal void ViewCount()
        {
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();

            string sql = "SELECT drinkName, COUNT(*) AS Times_Searched FROM drinksInfo GROUP BY drinkName ORDER BY Times_Searched DESC";
            var query = connection.Query(sql).ToList();

            Table table = new();
            table.AddColumn("[gold1]Drink[/]");
            table.AddColumn("[gold1]No. of times searched[/]");

            foreach (var row in query)
            {
                string drink = $"[springgreen2]{row.drinkName}[/]";
                long count = row.Times_Searched;
                table.AddRow(drink, $"[springgreen2]{count.ToString()}[/]");
            }

            AnsiConsole.Write(table);
            connection.Close();
        }
    }
}
