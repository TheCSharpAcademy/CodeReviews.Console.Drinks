namespace Drinks.Models;

public class DrinkInformationsList
{
    public List<DrinksInformation>? drinks { get; set; }
}

public class DrinksInformation
{
    public string strDrink { get; set; }
    public string strDrinkThumb { get; set; }
    public string idDrink { get; set; }
}