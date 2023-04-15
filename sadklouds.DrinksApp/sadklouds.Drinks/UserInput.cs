namespace sadklouds.Drinks
{
    internal class UserInput
    {
        private DrinksService service = new();
        public void GetCategoryInput()
        {
            var categories = service.GetCategories();

            Console.Write("Please Select a catergory to view drinks: ");

            string categoryName = Console.ReadLine();
            while (Validator.IsStringValid(categoryName) == false)
            {
                Console.WriteLine("\nInavlid Category");
                categoryName = Console.ReadLine();
            }
            if (!categories.Any(x => x.strCategory == categoryName))
            {
                Console.WriteLine("Category doesn't exist.");
                GetCategoryInput();
            }

            GetDrinkInput(categoryName);
        }

        public void GetDrinkInput(string categoryName)
        {
            var drinks = service.GetDrinksByCategory(categoryName);

            Console.Write("Please select a drink or enter 0 to return: ");

            string id = Console.ReadLine();

            if (id == "0")
                GetCategoryInput();

            while (Validator.isIdValid(id) == false)
            {
                Console.WriteLine("\nInavlid Category");
                id = Console.ReadLine();
            }
            if (!drinks.Any(x => x.idDrink == id))
            {
                Console.WriteLine("\n\n Invalid Id");
                GetDrinkInput(categoryName);
            }

            service.GetDrink(id);

            Console.WriteLine("Press any key to go back to categories menu");
            Console.ReadKey();
            if (!Console.KeyAvailable) GetCategoryInput();
        }
    }

}
