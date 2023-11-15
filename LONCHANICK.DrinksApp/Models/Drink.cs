namespace LONCHANICK.DrinksApp.Models;
public class Drinks
{
	public List<Drink> drinks { get; set; }
	public override string ToString()
	{
		string content = string.Empty;
		foreach (var drink in drinks)
			content += " Name: " + drink.strDrink + "\n" + " Id: " + drink.idDrink + "\n\n";

		return content;
	}
}
public class Drink
{
	public string strDrink { get; set; }
	public string strDrinkThumb { get; set; }
	public string idDrink { get; set; }

}