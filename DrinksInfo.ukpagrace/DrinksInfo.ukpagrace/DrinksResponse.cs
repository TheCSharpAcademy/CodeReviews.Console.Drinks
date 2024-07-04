using System.Text.Json.Serialization;

class CategoriesResponse
{
    [property: JsonPropertyName("drinks")] public List<CategoriesRepository>? Drinks { get; set; }
}


class CategoryResponse
{
    [property: JsonPropertyName("drinks")] public List<CategoryRepository>? Drinks { get; set; }
}

class DetailsResponse
{
    [property: JsonPropertyName("drinks")] public List<DetailsRepository>? Drinks { get; set; }
}





