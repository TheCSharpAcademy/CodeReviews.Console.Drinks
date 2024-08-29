namespace Drinks.tonyissa.Models;

internal record class CategoryDrink(string strDrink, string idDrink);

internal record class CategoryDrinkListResponse(List<CategoryDrink> drinks);