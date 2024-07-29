namespace Drinks.Models;

public class DrinkInfoList {
    public required List<DrinkInfo> Drinks { get; set; }
}
public class DrinkInfo {
    public required string StrDrink { get; set; }
    public required string StrCategory { get; set; }
    public required string StrAlcoholic { get; set; }
    public required string StrGlass { get; set; }
    public required string StrInstructions { get; set; }
}