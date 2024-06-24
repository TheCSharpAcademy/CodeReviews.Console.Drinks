namespace DrinksApi.Drinks;

public record class DrinkDto(
    string? Id,
    string? Name,
    string? Type,
    string? Glass,
    List<string> Ingredients,
    List<string> Measurements
)
{ }