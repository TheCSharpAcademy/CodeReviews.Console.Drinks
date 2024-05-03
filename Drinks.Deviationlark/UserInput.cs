using System.ComponentModel.DataAnnotations;

namespace DrinksInfo
{
    public class UserInput
    {
        DrinkDB drinkDB = new();
        DrinkService drinkService = new();

        internal void GetCategoryInput()
        {
            List<Category> categories = drinkService.GetCategories();
            SearchedDrink();

            Console.WriteLine("Enter the id of the Category: ");
            string userInput = Console.ReadLine();

            while (!Validation.CategoryValidation(categories, userInput))
            {
                Console.Clear();
                drinkService.GetCategories();
                SearchedDrink();
                Console.WriteLine("Invalid Category.");
                Console.WriteLine("Enter the id of the Category: ");
                userInput = Console.ReadLine();
            }
            if (userInput == "11") GetDrinkInput("Favorite Drinks");

            else GetDrinkInput(categories[int.Parse(userInput)].strCategory);
        }

        internal void GetDrinkInput(string category)
        {
            FavoriteDrinks favoriteDrinks = new();
            List<DrinkDB> favDrinks = new();
            List<Drink> drinks2 = new();
            if (category == "Favorite Drinks")
            {
                favDrinks = favoriteDrinks.Get();
                if (favDrinks.Count == 0)
                {
                    Console.WriteLine("There is no favorited drinks.");
                    Console.WriteLine("Press enter to go back to main menu.");
                    Console.ReadLine();
                    GetCategoryInput();
                }
            }
            else drinks2 = drinkService.GetDrinks(category);
            SearchedDrinks searchedDrinks = new();

            Console.WriteLine("Enter the id of the drink: ");
            string userInput = Console.ReadLine();

            while (!Validation.DrinkValidation(favDrinks, category, drinks2, userInput))
            {
                Console.Clear();
                if (category == "Favorite Drinks") favoriteDrinks.Get();
                else drinkService.GetDrinks(category);
                Console.WriteLine("Invalid Drink");
                Console.WriteLine("Enter the id of the Drink: ");
                userInput = Console.ReadLine();
            }


            DrinkDetail drinkDetails = drinkService.GetDrinkDetail(userInput);
            drinkDB.Id = userInput;
            drinkDB.Name = drinkDetails.strDrink;
            drinkDB.Category = category;
            searchedDrinks.Write(drinkDB);
            FavoriteDrink(drinkDB);
        }

        private void FavoriteDrink(DrinkDB drinkDB, int num = 0)
        {
            FavoriteDrinks favoriteDrinks = new();
            List<DrinkDB> favDrinks = favoriteDrinks.Get(1);
            foreach (var drink in favDrinks)
            {
                if (drink.Name == drinkDB.Name) num = 1;
            }
            if (num == 0)
            {
                Console.WriteLine("0. Category Menu");
                Console.WriteLine("1. Add drink to favorites");
                Console.WriteLine("Choose an option: ");
                string userInput = Console.ReadLine();

                if (userInput == "0") GetCategoryInput();

                else if (userInput == "1")
                {
                    favoriteDrinks.Write(drinkDB);
                    GetCategoryInput();
                }

                else
                {
                    Console.WriteLine("Invalid option. Press enter to go back to Category Menu.");
                    Console.ReadLine();
                    GetCategoryInput();
                }
            }
            else
            {
                Console.WriteLine("0. Category Menu");
                Console.WriteLine("1. Delete drink from Favorite drinks");
                string userInput = Console.ReadLine();
                if (userInput == "0") GetCategoryInput();
                else if (userInput == "1")
                {
                    favoriteDrinks.Delete(drinkDB.Id);
                    GetCategoryInput();
                }
                else
                {
                    Console.WriteLine("Invalid Option");
                    Console.ReadLine();
                    GetCategoryInput();
                }
            }
        }

        internal void SearchedDrink()
        {
            SearchedDrinks searchedDrinks = new();
            List<DrinkDB> drinksList = searchedDrinks.Get();

            string mostSearchedDrink = "";
            string mostSearchedDrinkCategory = "";
            int mostSearchedDrinkCount = 0;
            for (int i = 0; i < drinksList.Count; i++)
            {
                string searchedDrink = "";
                string searchedDrinkCategory = "";
                int searchedDrinkCount = 0;
                foreach (var drink in drinksList)
                {
                    if (searchedDrink == "")
                    { 
                        searchedDrink = drink.Name;
                        searchedDrinkCategory = drink.Category;
                    }
                    if (searchedDrink == mostSearchedDrink) 
                    {
                        searchedDrink = "";
                        searchedDrinkCategory = "";
                        continue;
                    }
                    if (drink.Name == searchedDrink)
                        searchedDrinkCount++;
                }
                if (mostSearchedDrink == "")
                {
                    mostSearchedDrink = searchedDrink;
                    mostSearchedDrinkCount = searchedDrinkCount;
                    mostSearchedDrinkCategory = searchedDrinkCategory;
                }
                if (searchedDrinkCount > mostSearchedDrinkCount)
                {
                    mostSearchedDrink = searchedDrink;
                    mostSearchedDrinkCount = searchedDrinkCount;
                    mostSearchedDrinkCategory = searchedDrinkCategory;
                }
            }
            Console.WriteLine($"Most Searched Drink: {mostSearchedDrink} from the {mostSearchedDrinkCategory} category");
            Console.WriteLine($"Searched {mostSearchedDrinkCount} times");
        }
    }
}