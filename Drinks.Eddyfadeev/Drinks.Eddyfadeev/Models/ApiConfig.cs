namespace Drinks.Models;

internal class ApiConfig
{
    public string? BaseUrl { get; init; }
    public string? RandomCocktail { get; init; }
    public Dictionary<string, string> Lists { get; init; } = new();
    public Dictionary<string, string> Search { get; init; } = new();
    public Dictionary<string, string> Filter { get; init; } = new();
}