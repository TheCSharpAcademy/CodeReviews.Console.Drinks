namespace Drinks;

using TheCocktailDb;

class DrinkDetailView : BaseView
{
    private readonly MainController controller;
    private readonly Category category;
    private readonly DrinkDetail? drink;

    public DrinkDetailView(MainController controller, Category category, DrinkDetail? drink)
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