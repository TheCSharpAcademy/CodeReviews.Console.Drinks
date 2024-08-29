namespace Drinks.tonyissa.Models;

internal record class Category(string strCategory);

internal record class CategoryListResponse(List<Category> drinks);