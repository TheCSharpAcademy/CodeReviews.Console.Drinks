using Drinks.yemiOdetola;

HttpClient client = new HttpClient()
{
  BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/")
};

var drinkService = new DrinkService(client);
var visualization = new Visualization();
var helper = new Helper();
var userInput = new UserInput(drinkService, visualization, helper);

await userInput.MenuHandler();
