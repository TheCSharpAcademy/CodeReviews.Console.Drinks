namespace Drinks.tonyissa.Models;

internal record class Category(string strCategory);

internal record class CategoryResponse(List<Category> drinks);