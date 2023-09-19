namespace Drinks;

using TheCocktailDb;

class DrinkCategoriesView : BaseView
{
    private MainController controller;
    private IList<Category> categories;

    public DrinkCategoriesView(MainController controller, IList<Category> categories)
    {
        this.controller = controller;
        this.categories = categories;
    }

    public override void Body()
    {
        Console.WriteLine("Categories:");
        int line = 0;
        foreach (var category in categories)
        {
            line++;
            Console.WriteLine($"{line} - {category.Name}");
        }

        Console.WriteLine("---");
        Console.WriteLine("Enter the ID of a category and press enter to list the drinks.");
        Console.WriteLine("Press only enter to exit.");
        var input = Console.ReadLine() ?? "";
        if (String.IsNullOrEmpty(input))
        {
            controller.ShowExit();
        }
        else if (int.TryParse(input, out int selectedLine))
        {
            var idx = selectedLine - 1;
            if (idx >= 0 && idx < categories.Count)
            {
                controller.ShowDrinksOfCategory(categories[idx]);
            }
            else
            {
                controller.ShowDrinkCategories();
            }
        }
    }
}