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

        Console.WriteLine("Enter the ID of a category and press enter to list the drinks. Press only enter to exit.");

        Category? selectedCategory = null;
        bool exit = false;
        do
        {
            var input = Console.ReadLine() ?? "";
            if (String.IsNullOrEmpty(input))
            {
                exit = true;
            }
            else if (int.TryParse(input, out int selectedLine))
            {
                var idx = selectedLine - 1;
                if (idx >= 0 && idx < categories.Count)
                {
                    selectedCategory = categories[idx];
                }
            }
        } while (!exit && selectedCategory == null);

        if (selectedCategory != null)
        {
            controller.ShowDrinksOfCategory(selectedCategory);
        }
    }
}