namespace DrinksInfo;

public static class DrinkInfoController
{
    public static async Task<DrinkInfoResponse> GetDrinkInfo(string drinkId)
    {
        return await DrinksInfoApiClient.GetAsyncDataFromDrinksInfo<DrinkInfoResponse>($"/lookup.php?i={drinkId}");
    }
}