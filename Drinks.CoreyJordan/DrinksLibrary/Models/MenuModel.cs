namespace DrinksLibrary.Models;
public class MenuModel
{
    public int Number { get; set; }
    public string Drink { get; set; }

    public MenuModel(int number, DrinkModel drink)
    {
        Number = number;
        Drink = drink.strDrink!;
    }

    public MenuModel(int number, string name)
    {
        Number = number;
        Drink = name;
    }
}
