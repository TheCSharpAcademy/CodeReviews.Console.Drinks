namespace Drinks;

class DrinkListView : BaseView
{
    private MainController controller;
    private CategoryDto category;
    private IList<DrinkDto> drinks;
    private int pointer;

    public DrinkListView(MainController controller, CategoryDto category, IList<DrinkDto> drinks)
    {
        this.controller = controller;
        this.category = category;
        this.drinks = drinks;
    }

    public override void Body()
    {
        Console.WriteLine($"Category: '{category.Name}'");
        if (drinks != null && drinks.Count > 0)
        {
            Console.WriteLine($"{drinks.Count} drinks found:");

            int itemsAfterPointer = drinks.Count - 1 - pointer;
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
            if (first >= drinks.Count) first = drinks.Count - 1;
            if (last < 0) last = 0;
            if (last >= drinks.Count) last = drinks.Count - 1;

            for (int i = first; i <= last; i++)
            {
                var pointerSymbol = (i == pointer) ? "->" : "  ";
                Console.WriteLine($"{pointerSymbol} {drinks[i].Name}");
            }

            Console.WriteLine("---");
            Console.WriteLine("Press arrow-up/-down to scroll through the list of drinks.");
            Console.WriteLine("Press arrow-right to view the details of the drink marked with '->'.");
            Console.WriteLine("Press arrow-left to change the drink category.");
            Console.WriteLine("Press 'x' to exit.");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.DownArrow:
                    pointer++;
                    if (pointer > drinks.Count - 1)
                    {
                        pointer = drinks.Count - 1;
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
                    controller.ShowDrinkDetails(category, drinks[pointer].Id);
                    break;
                case ConsoleKey.LeftArrow:
                    controller.ShowDrinkCategories();
                    break;
                case ConsoleKey.X:
                    MainController.ShowExit();
                    break;
                default:
                    Show();
                    break;
            }
        }
        else
        {
            Console.WriteLine("No drinks found.");
            Console.WriteLine("Press enter to select a different category.");
            Console.ReadLine();
            controller.ShowDrinkCategories();
        }
    }
}