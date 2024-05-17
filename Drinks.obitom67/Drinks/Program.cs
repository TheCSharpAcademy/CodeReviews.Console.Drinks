global using Drinks;
global using RestSharp;
global using Spectre.Console;

while (true)
{
    DrinkInfo drink = new();
    Categories categories = new();
    DrinksType drinks = new();
    string userCategory = categories.GetCategories();
    string userDrink = drinks.GetDrinks(userCategory);
    drink.GetDrinkInfo(userDrink);
}


