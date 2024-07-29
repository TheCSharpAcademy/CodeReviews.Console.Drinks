namespace Drinks.kwm0304.Models;

public class Drink
{
  public string? StrDrink { get; set; }
  public string? StrDrinkThumb { get; set; }
  public string? IdDrink { get; set; }
  public override string ToString()
  {
    return $"{StrDrink}";
  }
}