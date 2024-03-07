namespace DrinksInfo.Models;

public class DrinksModel
{
    public List<drinks> drinks { get; set; }
}

//mudar essa porcaria de nomes
public class drinks
{
    public int idDrink { get; set; }
    public string strDrink { get; set; }
    public string strCategory { get; set; }
    public string strInstructions { get; set; }
    public string strIngredient1 { get; set; }
    public string strIngredient2 { get; set; }
    public string strIngredient3 { get; set; }
    public string strIngredient4 { get; set; }
    public string strIngredient5 { get; set; }
    public string strIngredient6 { get; set; }

    public override string ToString()
    {
        return strDrink;
    }
}
