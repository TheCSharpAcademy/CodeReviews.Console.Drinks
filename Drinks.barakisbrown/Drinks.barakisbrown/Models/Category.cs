namespace Drinks.barakisbrown.Models;

using Newtonsoft.Json;

public class Category
{
    public Category()
    {
    }


#pragma warning disable IDE1006 // Naming Styles

    public string? strCategory { get; set; }

#pragma warning restore IDE1006 // Naming Styles


    public override string ToString()
    {
        return $"{strCategory}";
    }
}

public class Categories
{
    [JsonProperty("drinks")]
    public List<Category>? CategoriesList { get; set; }
}

