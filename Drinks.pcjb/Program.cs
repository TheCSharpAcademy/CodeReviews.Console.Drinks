namespace Drinks;

using Microsoft.VisualBasic;
using TheCocktailDb;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Drinks");

        var baseUri = new Uri("https://www.thecocktaildb.com/api/json/v1/1/");
        var apiClient = new ApiClient(baseUri);

        var categories = await apiClient.GetCategoriesAsync();

        int line;
        bool exit = false;
        do
        {
            Console.WriteLine("Categories:");
            line = 0;
            foreach (var category in categories)
            {
                line++;
                Console.WriteLine($"{line} - {category.Name}");
            }

            Console.WriteLine("Enter the ID of a category and press enter to list the drinks. Press only enter to exit.");
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
                    var selectedCategory = categories[idx];
                    var drinks = await apiClient.GetDrinksByCategoryAsync(selectedCategory.Name);
                    Console.WriteLine($"Drinks in category '{selectedCategory.Name}':");
                    foreach (var drink in drinks)
                    {
                        Console.WriteLine($"{drink.Id} - {drink.Name}");
                    }
                    Console.WriteLine("Enter the ID of a drink and press enter to see the details. Press enter alone to select a different category.");
                    input = Console.ReadLine() ?? "";
                    if (!String.IsNullOrEmpty(input) && int.TryParse(input, out int selectedDrinkId))
                    {
                        var drink = await apiClient.GetDrinkByIdAsync(selectedDrinkId);
                        if (drink != null)
                        {
                            Console.WriteLine("Drink Details");
                            Console.WriteLine($"{drink.Name}");
                            Console.WriteLine($"{drink.Instructions}");
                            Console.ReadLine();
                        }
                        else
                        {
                          Console.WriteLine("No Drink Details found for this ID.");  
                        }
                    }
                }
            }
        } while (!exit);

    }
}