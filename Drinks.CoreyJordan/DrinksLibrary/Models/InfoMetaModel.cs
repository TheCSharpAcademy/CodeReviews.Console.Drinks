namespace DrinksLibrary.Models;
public class InfoMetaModel
{
    public string Drink { get; set; }
    public object Alternate { get; set; }
    public string Category { get; set; }
    public object IBA { get; set; }
    public string Alcoholic { get; set; }
    public string Glass { get; set; }
    public string Instructions { get; set; }

    public InfoMetaModel(RawInfoModel drink)
    {
        Drink = drink.strDrink;
        Alternate = drink.strDrinkAlternate;
        Category = drink.strCategory;
        IBA = drink.strIBA;
        Alcoholic = drink.strAlcoholic;
        Glass = drink.strGlass;
        Instructions = drink.strInstructions;
    }
}
