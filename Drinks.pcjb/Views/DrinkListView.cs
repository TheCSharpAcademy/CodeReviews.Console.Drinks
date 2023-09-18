namespace Drinks;

using TheCocktailDb;

class DrinkListView : BaseView
{
    private MainController controller;
    private Category category;
    private IList<Drink> drinks;

    public DrinkListView(MainController controller, Category category, IList<Drink> drinks)
    {
        this.controller = controller;
        this.category = category;
        this.drinks = drinks;
    }

    public override void Body()
    {
        Console.WriteLine($"Drinks in category '{category.Name}'");
        if (drinks != null && drinks.Count > 0)
        {
            Console.WriteLine($"{drinks.Count} drinks found:");
            foreach (var drink in drinks)
            {
                Console.WriteLine($"{drink.Id} - {drink.Name}");
            }
            Console.WriteLine("Enter the ID of a drink and press enter to see the details.");
            Console.WriteLine("Press enter alone to select a different category.");
            var input = Console.ReadLine() ?? "";
            if (!String.IsNullOrEmpty(input) && int.TryParse(input, out int selectedDrinkId))
            {
                controller.ShowDrinkDetails(category, selectedDrinkId);
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