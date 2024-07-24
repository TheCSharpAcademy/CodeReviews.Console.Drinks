namespace DrinksInfo.Contracts.V1;

/// <summary>
/// The supported API routes in this application.
/// </summary>
public static class ApiRoutes
{
    #region Constants - Private

    private const string Root = "https://www.thecocktaildb.com/api/json";

    private const string Version = "v1";

    private const string Key = "1";

    private const string Base = @$"{Root}\{Version}\{Key}";

    #endregion
    #region Constants - Public 

    public const string GetCategories = $"{Base}/list.php?c=list";

    public const string GetDrink = $"{Base}/lookup.php?i={{drinkId}}";

    public const string GetDrinksByCategory = $"{Base}/filter.php?c={{category}}";

    public const string GetRandomDrink = $"{Base}/random.php";

    #endregion
}
