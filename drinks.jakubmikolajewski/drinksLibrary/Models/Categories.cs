using System.Text.Json.Serialization;

namespace drinksLibrary.Models;

public record class Categories(
    [property: JsonPropertyName("drinks")] List<Category> CategoriesList);

public record class Category(
    [property: JsonPropertyName("strCategory")] string Cat);


