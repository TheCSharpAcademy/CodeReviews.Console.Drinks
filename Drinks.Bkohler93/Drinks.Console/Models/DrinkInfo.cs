namespace Drinks.Models;

public class DrinkInfoList {
    public List<DrinkInfo> Drinks { get; set; }
}
public class DrinkInfo {
    public string StrDrink { get; set; }
    public string StrCategory { get; set; }
    public string StrAlcoholic { get; set; }
    public string StrGlass { get; set; }
    public string StrInstructions { get; set; }
}