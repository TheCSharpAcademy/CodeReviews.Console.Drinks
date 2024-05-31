namespace Drinks.Models;

public class DrinkInformationsList
{
    public List<DrinksInformation>? Drinks { get; set; }
}

public class DrinksInformation
{
    public string StrDrink { get; set; }
    public string StrDrinkThumb { get; set; }
    public string IdDrink { get; set; }
}