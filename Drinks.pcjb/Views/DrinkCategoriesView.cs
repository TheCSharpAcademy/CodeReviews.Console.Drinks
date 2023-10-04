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

        int itemsAfterPointer = categories.Count - 1 - pointer;
        int maxVisibleItemsBeforeAfter = 3;
        int first = pointer - Math.Min(maxVisibleItemsBeforeAfter, pointer);
        int last = pointer + Math.Min(maxVisibleItemsBeforeAfter, itemsAfterPointer);
        if (pointer - first < maxVisibleItemsBeforeAfter)
        {
            last += Math.Min(maxVisibleItemsBeforeAfter - (pointer - first), itemsAfterPointer);
        }
        if (last - pointer < maxVisibleItemsBeforeAfter)
        {
            first -= Math.Min(maxVisibleItemsBeforeAfter - (last - pointer), pointer);
        }
        if (first < 0) first = 0;
        if (first >= categories.Count) first = categories.Count - 1;
        if (last < 0) last = 0;
        if (last >= categories.Count) last = categories.Count - 1;

        for (int i = first; i <= last; i++)
        {
            var pointerSymbol = (i == pointer) ? "->" : "  ";
            Console.WriteLine($"{pointerSymbol} {categories[i].Name}");
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