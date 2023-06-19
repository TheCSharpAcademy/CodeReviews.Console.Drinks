using System.Text.Json.Serialization;
namespace LONCHANICK.DrinksApp.Models;

public class ListOfDrinkCategories
{
    [property: JsonPropertyName("drinks")]
    public List<DrinkCategory> DrinksCategories { get; set; }
    //public List<DrinkCategory> drinks 
    
    public override string ToString()
    {
        string content = string.Empty;
        int i = 0;
        foreach (var drink in DrinksCategories)
            content += " "+(++i).ToString()+")"+drink.strCategory+"\n";

        return content;
    }
}


public class DrinkCategory
{
    public string strCategory { get; set; }
}
