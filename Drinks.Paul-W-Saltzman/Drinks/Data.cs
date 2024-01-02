using drinks_info.Models;
using Microsoft.Data.Sqlite;
using System.Configuration;

namespace drinks_info
{
    internal class Data
    {
        internal static string ConnectionString()
        {
            string dbName = ConfigurationManager.AppSettings.Get("db");
            string dbPath = ConfigurationManager.AppSettings.Get("path");
            string projectPath = Directory.GetCurrentDirectory();
            string directoryPath = Path.Combine(projectPath + dbPath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(projectPath);
                Console.WriteLine(projectPath + dbPath);
                Console.WriteLine("The directory has been created.");
                Console.ReadKey();

            }

            string connectionString = $@"Data Source={Path.Combine(directoryPath + dbName)}";

            return connectionString;
        }

        internal static void Init()
        {
            string connectionString = ConnectionString();
            using (var connection = new SqliteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    Console.ReadKey();
                }
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS Favorites (
                FavoriteID INTEGER PRIMARY KEY AUTOINCREMENT,
                DrinkID INTEGER,
                DrinkStr TEXT)";
                try
                {
                    int rowsAffected = tableCmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error at Create Settings Table tableCmd1");
                    Console.WriteLine(exception);
                    Console.ReadKey();
                }

                var tableCmd1 = connection.CreateCommand();

                tableCmd1.CommandText =
                @"CREATE TABLE IF NOT EXISTS Settings (
                SettingsId INTEGER PRIMARY KEY AUTOINCREMENT,
                Version INTEGER,
                Language TEXT
                )";

                try
                {
                    int rowsAffected = tableCmd1.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error at Create Settings Table tableCmd1");
                    Console.WriteLine(exception);
                    Console.ReadKey();
                }

                var tableCmd2 = connection.CreateCommand();

                tableCmd2.CommandText =
                @"CREATE TABLE IF NOT EXISTS Inventory (
                IngredientsId INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT
                )";

                try
                {
                    int rowsAffected = tableCmd2.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error at Create Ingrediants Table tableCmd2");
                    Console.WriteLine(exception);
                    Console.ReadKey();
                }
                finally
                { connection.Close(); }
            }
        }

        internal static Settings GetSettings()
        {
            Settings settings = new Settings();
            string connectionString = ConnectionString();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                bool loaded = false;
                while (!loaded)
                {
                    var tableCmd = connection.CreateCommand();
                    tableCmd.CommandText =
                        $"SELECT * FROM settings where settingsID = 1";

                    SqliteDataReader reader = tableCmd.ExecuteReader();

                    if (reader.Read())
                    {
                        settings.SettingsId = reader.GetInt32(0);
                        settings.Version = reader.GetInt32(1);
                        string languageCode = reader.GetString(2);
                        if (Enum.TryParse<Settings.LanguageEnum>(languageCode, out var language))
                        {
                            settings.Language = language;
                        }
                        else
                        {
                            settings.Language = Settings.LanguageEnum.EN;
                        }
                        loaded = true;
                    }
                    else
                    {
                        tableCmd = connection.CreateCommand();
                        tableCmd.CommandText =
                        "INSERT INTO settings (settingsId,Version,Language) VALUES (1,1,'EN')";
                        tableCmd.ExecuteNonQuery();
                    }
                }
                connection.Close();
                return settings;
            }
        }
        private static void ExecuteCommand(SqliteConnection connection, string commandText)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = commandText;
                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error at Execute Command");
                    Console.WriteLine("Error executing query: " + ex.Message);
                }
            }
        }


        internal static void EnterFavorite(DrinkDetail favoritedDrink)
        {
            string connectionString = ConnectionString();
            int intDrinkID;
            if (int.TryParse(favoritedDrink.idDrink.Trim(), out intDrinkID))
            {
                // Parsing was successful.

            }
            else
            {
                // Parsing failed, handle the error as needed
                Console.WriteLine("Failed to parse DrinkID");
            }
            using (var connection = new SqliteConnection(connectionString))
            {

                connection.Open();
                var tableCmd = connection.CreateCommand();

                try
                {
                    ExecuteCommand(connection, $@"INSERT INTO Favorites (DrinkID,DrinkStr) Values('{intDrinkID}','{favoritedDrink.strDrink}')");
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error at Enter Favorite.");
                    Console.WriteLine(exception);
                }
                finally
                { connection.Close(); }
            }
        }

        internal static void toggleIngredientInInventory(Ingredient ingredient)
        {
            List<Inventory> inventory = GetInventory();

            if(inventory.Any(item => item.InventoryName == ingredient.strIngredient1))
            {
                string connectionString = ConnectionString();
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    var tableCmd = connection.CreateCommand();

                    try
                    {
                        ExecuteCommand(connection, $@"DELETE FROM Inventory WHERE Name = '{ingredient.strIngredient1}'");
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("Error at Toggle remove Inventory.");
                        Console.WriteLine(exception);
                        Console.ReadKey();
                    }
                    finally
                    { connection.Close(); }
                }
            }
            else
            {
                string connectionString = ConnectionString();
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    var tableCmd = connection.CreateCommand();

                    try
                    {
                        ExecuteCommand(connection, $@"INSERT INTO Inventory (Name) Values('{ingredient.strIngredient1}')");
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("Error at Toggle add to Inventory.");
                        Console.WriteLine(exception);
                        Console.ReadKey();
                    }
                    finally
                    { connection.Close(); }
                }
            }
        }

        internal static void RemoveFavorite(DrinkDetail toUnFavoriteDrink)
        {
            string connectionString = ConnectionString();
            int intDrinkID;
            if (int.TryParse(toUnFavoriteDrink.idDrink.Trim(), out intDrinkID))
            {
                // Parsing was successful.

            }
            else
            {
                // Parsing failed, handle the error as needed
                Console.WriteLine("Failed to parse DrinkID");
            }
            using (var connection = new SqliteConnection(connectionString))
            {

                connection.Open();
                var tableCmd = connection.CreateCommand();

                try
                {
                    ExecuteCommand(connection, $@"DELETE FROM Favorites WHERE DrinkID = {intDrinkID}");
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error at Remove Favorite.");
                    Console.WriteLine(exception);
                }
                finally
                { connection.Close(); }
            }
        }

        internal static List<Favorite> GetFavorites()
        {
            List<Favorite> favorites = new List<Favorite>();
            string connectionString = ConnectionString();
            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    var tableCmd = connection.CreateCommand();
                    tableCmd.CommandText =
                        $@"SELECT * FROM Favorites";

                    using (SqliteDataReader reader = tableCmd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                favorites.Add(
                                new Favorite
                                {
                                    FavoritesID = reader.GetInt32(0),
                                    DrinkID = reader.GetInt32(1),
                                    DrinkStr = reader.GetString(2),

                                });
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetFavorites: " + ex.Message);
                // Handle the exception as needed, log, throw, etc.
            }
            return favorites;
        }

        internal static List<Inventory> GetInventory()
        {
            List<Inventory> inventory = new List<Inventory>();
            string connectionString = ConnectionString();
            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    var tableCmd = connection.CreateCommand();
                    tableCmd.CommandText =
                        $@"SELECT * FROM Inventory";

                    using (SqliteDataReader reader = tableCmd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                inventory.Add(
                                new Inventory
                                {
                                    InventoryId = reader.GetInt32(0),
                                    InventoryName = reader.GetString(1)

                                });
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetFavorites: " + ex.Message);
                // Handle the exception as needed, log, throw, etc.
            }
            return inventory;
        }

        internal static void UpdateSettings(Settings settings)
        {
            string connectionString = ConnectionString();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var updateCommand = connection.CreateCommand();
                updateCommand.CommandText = @"UPDATE Settings SET Version = @Version, Language = @Language WHERE SettingsId = @SettingsId";

                // Add parameters to the command
                updateCommand.Parameters.AddWithValue("@Version", settings.Version);
                updateCommand.Parameters.AddWithValue("@Language", settings.Language.ToString());
                updateCommand.Parameters.AddWithValue("@SettingsId", settings.SettingsId);
                try
                {
                    int rowsAffected = updateCommand.ExecuteNonQuery();
                } 
                catch (Exception ex) 
                {
                    Console.WriteLine("Error in UpdateSettings: " + ex.Message);
                }
                finally 
                { 
                    connection.Close(); 
                }
            }
        }
    }
}

