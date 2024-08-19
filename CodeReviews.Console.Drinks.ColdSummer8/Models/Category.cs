namespace Models;
public class Category
{
    public string? strCategory { get; set; }
}
public class CategoryResponse
{
    public List<Category>? drinks { get; set; }
}