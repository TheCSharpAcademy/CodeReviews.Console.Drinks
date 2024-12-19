namespace DrinksInfo.DreamFXX;

public class UserInput
{
    DrinksService drinksService = new();

    internal void GetCategoriesInput()
    {
        drinksService.GetCategories();
        
    }
}