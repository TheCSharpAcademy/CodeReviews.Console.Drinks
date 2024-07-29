namespace Drinks.Models;

public class Categories {
    public required List<Category> Drinks { get; set; }
}

public class Category {
    public required string StrCategory { get; set; }
}