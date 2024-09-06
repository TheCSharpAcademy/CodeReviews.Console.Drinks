namespace DrinksInfo;

public class UserInterface
{
    public async Task Run()
    {
        while (true)
        {
            string category = await CategoryService.GetCategoryFromUser();
            string userId = await DrinksPerCategoryService.GetDrikIdFromUser(category);
            if (userId == "0") continue;
            await DrinkInfoService.ShowDrinkInfo(userId);
        }
    }
}