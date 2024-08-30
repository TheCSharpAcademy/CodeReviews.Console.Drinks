namespace Drinks.tonyissa.Models;

public record class Category(string strCategory);

public record class CategoryListResponse(List<Category> drinks);