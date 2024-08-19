namespace Models;
public class Drinks
{
    public string? strDrink {  get; set; }
    public string? strDrinkThumb { get; set; }
    public string? idDrink {  get; set; }
}
public class DrinksResponse
{
    public List<Drinks>? drinks { get; set; }
}