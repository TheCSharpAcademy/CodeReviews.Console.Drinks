namespace Drinks;

using TheCocktailDb;

class DrinkCategoriesView : BaseView
{
    private MainController controller;
    private IList<CategoryDto> categories;

    public DrinkCategoriesView(MainController controller, IList<CategoryDto> categories)
    {
        this.controller = controller;
        this.categories = categories;
    }

    public override void Body()
    {
        Console.WriteLine("Categories:");
        foreach (var category in categories)
        {
            Console.WriteLine($"{category.Id} - {category.Name}");
        }

        Console.WriteLine("---");
        Console.WriteLine("Enter the ID of a category and press enter to list the drinks.");
        Console.WriteLine("Press only enter to exit.");
        var input = Console.ReadLine() ?? "";
        if (String.IsNullOrEmpty(input))
        {
            controller.ShowExit();
        }
        else if (int.TryParse(input, out int selectedId))
        {
            CategoryDto? selectedCategory = null;
            foreach (var category in categories)
            {
                if (category.Id == selectedId)
                {
                    selectedCategory = category;
                    break;
                }
            }

            if (selectedCategory != null)
            {
                controller.ShowDrinksOfCategory(selectedCategory);
            }
        }
        else
        {
            controller.ShowDrinkCategories();
        }
    }
}