using drinks_info.Models;
using Microsoft.Data.Sqlite;
using Dapper;

namespace drinks_info
{
    public class Favourite
    {
        string connectionString ="Data source = favourites.db";
        DrinksService drinksService = new();
        internal string GetCategoriesInput(){
            var categories = drinksService.GetCategories();

            Console.WriteLine("Choose category:");

            string category = Console.ReadLine();

            while (!Validator.IsStringValid(category))
            {
                Console.WriteLine("\nInvalid category");
                category = Console.ReadLine();
            }

            if(!categories.Any(x => x.strCategory == category)) 
            {
                Console.WriteLine("Category doesn't exist.");
                GetCategoriesInput();
            }
            
            GetDrinksInput(category);
            return category;

        }

        internal string GetDrinksInput(string category)
        {
            var drinks = drinksService.GetDrinksByCategory(category);

            Console.WriteLine("Choose a drink or go back to category menu by typing 0:");

            string drink = Console.ReadLine();

            if (drink == "0") GetCategoriesInput();

            while (!Validator.IsIdValid(drink))
            {
                Console.WriteLine("\nInvalid drink");
                drink = Console.ReadLine();
            }

            if(!drinks.Any(x => x.idDrink == drink)) 
            {
                Console.WriteLine("Drink doesn't exist.");
                GetDrinksInput(category);
            }


            return drink;

        }


        public void ShowMenu(){
            Console.WriteLine("TYPE 1 TO ADD A DRINK TO FAVOURITES");
            Console.WriteLine("TYPE 2 TO SEE YOUR FAVOURITE DRINKS");
            Console.WriteLine("TYPE 0 TO EXIT");

            string choice = Console.ReadLine();
            switch(choice){
                case "1":
                    InserInTable();
                    break;
                case "2":
                    ShowTable();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
            }
        }
        public void CreateTable(){
            using(var connnection = new SqliteConnection(connectionString)){
                connnection.Open();

                var tableCmd = connnection.CreateCommand();
                tableCmd.CommandText = @"CREATE TABLE IF NOT EXISTS favourites(
                CATEGORY VARCHAR(250),
                DRINK VARCHAR(250) UNIQUE)";
                tableCmd.ExecuteNonQuery();
                
            }
        }

        public void InserInTable(){
            using(var connnection = new SqliteConnection(connectionString)){
                connnection.Open();
                CreateTable();
                string Category = GetCategoriesInput();
                string Drink = GetDrinksInput(Category);

                var tableCmd = connnection.CreateCommand();
                tableCmd.CommandText = $@"INSERT INTO favourites(CATEGORY, DRINK) VALUES('{Category}', '{Drink}')";
                tableCmd.ExecuteNonQuery();
                ShowTable();
            }
        }

        public void ShowTable(){
            try{
                using(var connection = new SqliteConnection(connectionString)){
                    connection.Open();
                    var table = connection.Query("SELECT * FROM favourites");

                    foreach (var dw in table){
                        Console.WriteLine($"\t CATEGORY: {dw.CATEGORY} \t DRINK: {dw.DRINK}");
                    }
                }
            }

            catch(Exception e){
                Console.WriteLine(e.Message);
            }
        }
    }
}