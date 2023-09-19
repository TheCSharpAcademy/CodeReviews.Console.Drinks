namespace Drinks;

class DrinkCategoriesView : BaseView
{
    private MainController controller;
    private IList<CategoryDto> categories;
    private int pointer;

    public DrinkCategoriesView(MainController controller, IList<CategoryDto> categories)
    {
        this.controller = controller;
        this.categories = categories;
    }

    public override void Body()
    {
        Console.WriteLine("Drink Categories");
        Console.WriteLine($"{categories.Count} categories found:");

        if (pointer == categories.Count - 1)
        {
            Console.WriteLine($"   {categories[pointer-2].Name}");
        }
        if (pointer > 0)
        {
            Console.WriteLine($"   {categories[pointer-1].Name}");
        }
        Console.WriteLine($"-> {categories[pointer].Name}");
        if (pointer < categories.Count - 1)
        {
            Console.WriteLine($"   {categories[pointer+1].Name}");
        }
        if (pointer == 0)
        {
            Console.WriteLine($"   {categories[pointer+2].Name}");
        }

        Console.WriteLine("---");
        Console.WriteLine("Press arrow-up/-down to scroll through the list of drink categories.");
        Console.WriteLine("Press arrow-right to view drinks of the category marked with '->'.");
        Console.WriteLine("Press 'x' to exit.");

        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.DownArrow:
                pointer++;
                if (pointer > categories.Count - 1)
                {
                    pointer = categories.Count - 1;
                }
                Show();
                break;
            case ConsoleKey.UpArrow:
                pointer--;
                if (pointer < 0)
                {
                    pointer = 0;
                }
                Show();
                break;
            case ConsoleKey.RightArrow:
                controller.ShowDrinksOfCategory(categories[pointer]);
                break;
            case ConsoleKey.X:
                MainController.ShowExit();
                break;
            default:
                Show();
                break;
        }
    }
}