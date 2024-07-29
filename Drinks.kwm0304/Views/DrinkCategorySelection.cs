using Drinks.kwm0304.Models;

namespace Drinks.kwm0304.Views;

public class DrinkCategorySelection
{
  public static DrinkCategory SelectDrinkCategory(List<DrinkCategory> categories)
  {
    var menu = new PromptContainer<DrinkCategory>("\n\n\n[bold chartreuse2_1]Select a category to get started:[/]", categories);
    return menu.Show()!;
  }

  public static string SelectDrinkFromCategory(List<Drink> drinks)
  {
    var menu = new PromptContainer<Drink>("\n\n\n[bold chartreuse2_1]Select a drink to view it's ingredients:[/]", drinks);
    Drink drink = menu.Show()!;
    return drink.IdDrink!;
  }
}