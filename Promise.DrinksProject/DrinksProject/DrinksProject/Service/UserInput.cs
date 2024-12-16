using DrinksProject.Helpers;

namespace DrinksProject.Service
{
    public class UserInput
    {
        private readonly DrinksService _drinksService;

        public UserInput(DrinksService drinksService)
        {
            _drinksService = drinksService;
        }
        public async Task GetCategoriesInput()
        {
            var categories = await _drinksService.GetAllDrinksCategories();

            Console.Write("Select a category: ");

            string category = Console.ReadLine();

            while (!Validator.IsCategoryValid(category))
            {
                Console.WriteLine("\nInvalid category");
                category = Console.ReadLine();
            }
            if (!categories.Any(x => x.StrCategory == category))
            {
                Console.WriteLine("Category does not exist");
                GetCategoriesInput();
            }
            GetDrinks(category);
        }
        public async Task GetDrinks(string category)
        {
            var drinks = await _drinksService.GetDrinksByCategory(category);

            Console.Write("Choose a drink or type '0' to return to the category menu: ");

            string drink = Console.ReadLine();

            if (drink == "0")
                GetCategoriesInput();

            while (!Validator.IsIdValid(drink))
            {
                Console.WriteLine("\nInvalid drink");
                drink = Console.ReadLine();
            }
            if (!drinks.Any(x => x.IdDrink == drink))
            {
                Console.WriteLine("Invalid drink Id. Drink does not exist.");
                GetDrinks(category);
            }
            _drinksService.GetDrinkById(drink);

            Console.WriteLine("Press any key to go back to categories menu.");
            Console.ReadKey();
            if (!Console.KeyAvailable) GetCategoriesInput();
        }
    }
}
