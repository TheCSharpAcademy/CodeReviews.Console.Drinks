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

            if (pointer == drinks.Count - 1)
            {
                Console.WriteLine($"   {drinks[pointer - 2].Name}");
            }
            if (pointer > 0)
            {
                Console.WriteLine($"   {drinks[pointer - 1].Name}");
            }
            Console.WriteLine($"-> {drinks[pointer].Name}");
            if (pointer < drinks.Count - 1)
            {
                Console.WriteLine($"   {drinks[pointer + 1].Name}");
            }
            if (pointer == 0)
            {
                Console.WriteLine($"   {drinks[pointer + 2].Name}");
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