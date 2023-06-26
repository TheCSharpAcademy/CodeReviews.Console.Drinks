namespace DrinksLibrary.Models;
public class IngredientListModel
{
    public string Ingredient1 { get; set; }
    public string Ingredient2 { get; set; }
    public string Ingredient3 { get; set; }
    public string Ingredient4 { get; set; }
    public object Ingredient5 { get; set; }
    public object Ingredient6 { get; set; }
    public object Ingredient7 { get; set; }
    public object Ingredient8 { get; set; }
    public object Ingredient9 { get; set; }
    public object Ingredient10 { get; set; }
    public object Ingredient11 { get; set; }
    public object Ingredient12 { get; set; }
    public object Ingredient13 { get; set; }
    public object Ingredient14 { get; set; }
    public object Ingredient15 { get; set; }


    public IngredientListModel(RawInfoModel drink)
    {
        Ingredient1 = drink.strIngredient1;
        Ingredient2 = drink.strIngredient2;
        Ingredient3 = drink.strIngredient3;
        Ingredient4 = drink.strIngredient4;
        Ingredient5 = drink.strIngredient5;
        Ingredient6 = drink.strIngredient6;
        Ingredient7 = drink.strIngredient7;
        Ingredient8 = drink.strIngredient8;
        Ingredient9 = drink.strIngredient9;
        Ingredient10 = drink.strIngredient10;
        Ingredient11 = drink.strIngredient11;
        Ingredient12 = drink.strIngredient12;
        Ingredient13 = drink.strIngredient13;
        Ingredient14 = drink.strIngredient14;
        Ingredient15 = drink.strIngredient15;
    }
}