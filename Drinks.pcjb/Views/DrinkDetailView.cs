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
            WriteLineIfNotEmpty("Name", drink.Name);
            WriteLineIfNotEmpty("Category", drink.Category);
            WriteLineIfNotEmpty("IBA", drink.Iba);
            WriteLineIfNotEmpty("Alternate", drink.Alternate);
            WriteLineIfNotEmpty("Alcoholic", drink.Alcoholic);
            WriteLineIfNotEmpty("Glass", drink.Glass);
            if (drink.Ingredients != null && drink.Ingredients.Count > 0)
            {
                Console.WriteLine("--- Ingredients ---");
                foreach (IngredientDto ingredient in drink.Ingredients)
                {
                    Console.WriteLine($"{ingredient.Measure} {ingredient.Name}");
                }
            }

            if (!String.IsNullOrEmpty(drink.Instructions))
            {
                Console.WriteLine("--- Instructions ---");
                Console.WriteLine($"{drink.Instructions}");
            }
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

    private void WriteLineIfNotEmpty(string label, string? text)
    {
        if (!String.IsNullOrEmpty(text))
        {
            Console.WriteLine($"{label}: {text}");
        }
    }
}