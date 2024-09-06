namespace DrinksInfo
{
    public static class DrinksCategoriesController
    {
        public static async Task<DrinksCategoriesResponse> GetDrinkCategories()
        {
            return await DrinksInfoApiClient.GetAsyncDataFromDrinksInfo<DrinksCategoriesResponse>("/list.php?c=list");
        }
    }
}