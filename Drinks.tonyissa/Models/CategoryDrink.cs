namespace Drinks.tonyissa.Models;

public record class CategoryDrink(string strDrink, string idDrink);

public record class CategoryDrinkListResponse(List<CategoryDrink> drinks);