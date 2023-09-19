namespace Drinks;

class DrinkDetailView : BaseView
{
    private readonly MainController controller;
    private readonly CategoryDto category;
    private readonly DrinkDto? drink;

    public DrinkDetailView(MainController controller, CategoryDto category, DrinkDto? drink)
    {
        this.controller = controller;
        this.category = category;
        this.drink = drink;
    }

    public override void Body()
    {
        if (drink != null)
        {
            Console.WriteLine($"Drink Details for '{drink.Name}'");
            Console.WriteLine("Instructions:");
            Console.WriteLine($"{drink.Instructions}");
        }
        else
        {
            Console.WriteLine("No Drink Details found for this ID.");
        }
        
        Console.WriteLine("---");
        Console.WriteLine("Press enter to select a different drink.");
        Console.ReadLine();
        controller.ShowDrinksOfCategory(category);
    }
}