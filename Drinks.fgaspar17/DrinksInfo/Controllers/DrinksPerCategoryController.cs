namespace DrinksInfo;

public static class DrinksPerCategoryController
{
    public static async Task<DrinksPerCategoryResponse> GetDrinksPerCategory(string categoryName)
    {
        return await DrinksInfoApiClient.GetAsyncDataFromDrinksInfo<DrinksPerCategoryResponse>($"/filter.php?c={categoryName}");
    }
}