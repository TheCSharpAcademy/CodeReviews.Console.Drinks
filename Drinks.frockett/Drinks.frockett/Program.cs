using Drinks.frockett;

HttpClient client = new HttpClient()
{
    BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/")
};

var drinksService = new DrinksService(client);
var visualization = new Visualization();
var validator = new Validator();
var userInput = new UserInput(drinksService, visualization, validator);

await userInput.MenuHandler();
