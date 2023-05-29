namespace DrinksLibrary.Models;
public class DrinkMenuModel
{
    public int Number { get; set; }
    public string Drink { get; set; }

    public DrinkMenuModel(int number, DrinkModel drink)
    {
        Number = number;
        Drink = drink.strDrink;
    }

    public DrinkMenuModel(int number, string name)
    {
        Number = number;
        Drink = name;
    }
}
