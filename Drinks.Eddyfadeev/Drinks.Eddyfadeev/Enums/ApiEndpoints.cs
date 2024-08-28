namespace Drinks.Enums;

/// <summary>
/// The <see cref="ApiEndpoints"/> class defines constants for various API endpoints used in the application.
/// <seealso cref="Lists"/>
/// <seealso cref="Search"/>
/// <seealso cref="Filter"/>
/// <seealso cref="Random"/>
/// </summary>
internal static class ApiEndpoints
{
    /// <summary>
    /// Represents the available list options for querying the API.
    /// </summary>
    /// <remarks>
    /// This enum is defined in the <see cref="ApiEndpoints"/> class 
    /// and is used to list the results of API queries by category,
    /// ingredient, glass, or alcohol option.
    /// </remarks>
    public enum Lists
    {
        Categories = 1,
        Ingredients,
        Glasses,
        AlcoholicOptions
    }

    /// <summary>
    /// Represents the available search options for querying the API.
    /// </summary>
    /// <remarks>
    /// This enum is defined in the <see cref="ApiEndpoints"/> class
    /// and is used to search the results of API queries by cocktail name or ingredient name.
    /// </remarks>
    public enum Search
    {
        CocktailByName,
        ByIngredientName
    }

    /// <summary>
    /// Represents the available filter options for querying the API.
    /// </summary>
    /// <remarks>
    /// This enum is defined in the <see cref="ApiEndpoints"/> class
    /// and is used to filter the results of API queries by ingredient, alcoholic option, category, or glass.
    /// </remarks>
    public enum Filter
    {
        ByIngredient,
        ByAlcoholic,
        ByCategory,
        ByGlass
    }

    /// <summary>
    /// Represents the available random options for querying the API.
    /// </summary>
    /// <remarks>
    /// This enum is defined in the <see cref="ApiEndpoints"/> class
    /// and is used for retrieving random cocktail using the API query.
    /// </remarks>
    public enum Random
    {
        RandomCocktail
    }
}