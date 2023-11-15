using System.Configuration;
using Drinks.wkktoria;
using Drinks.wkktoria.Services;
using Drinks.wkktoria.UserInterface;

var databaseName = ConfigurationManager.AppSettings.Get("DatabaseName");
var databasePassword = ConfigurationManager.AppSettings.Get("DatabasePassword");
var connectionString = $"Server=localhost,1433;User Id=sa;Password={databasePassword};TrustServerCertificate=true;";

var databaseManager = new DatabaseManager(connectionString, databaseName!);
databaseManager.Initialize();

var favoritesService = new FavoritesService(connectionString, databaseName!);
var searchedService = new SearchedService(connectionString, databaseName!);

var userInput = new UserInput(favoritesService, searchedService);
userInput.Run();