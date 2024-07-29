namespace Drinks.kwm0304.Models;

public class DrinkCategory
{
  public string? StrCategory { get; set; }
  public override string ToString()
  {
    return StrCategory?.Replace(" ", "_") ?? "null";
  }
}