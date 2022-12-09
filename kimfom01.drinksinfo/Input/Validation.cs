using drinks_info_console.Models;

namespace drinks_info_console.Input;

public class Validation
{
    public bool IsValidId(string id)
    {
        int _;
        return int.TryParse(id, out _) && _ > 0;
    }

    public bool IsValidString(string text)
    {
        return !String.IsNullOrEmpty(text);
    }

    public bool IsValidAns(string ans)
    {
        return ans == "y" || ans == "n";
    }

    public bool IsValidCategory(List<Category> categoryList, string category)
    {
        return categoryList.Any(x => x.CategoryName.ToLower() == category.ToLower());
    }

    public bool IsValidDrinkId(List<Drink> drinkList, string id)
    {
        return drinkList.Any(x => x.Id == id);
    }
}
