using ClassLibrary;
using DrinksInfo.API;
using DrinksInfo.Models;

namespace DrinksInfo.View
{
    public static class CategoriesView
    {
        internal static void SelectCategory()
        {
            List<Category> list = CategoriesAPI.GetDrinkCategories();

            Console.Write("Choose Category or type 0 to leave the program: ");

            var choice = Console.ReadLine();

            string drink = choice switch
            {
                "1" => HelperMethods.FilterString(list[0].GetName()),
                "2" => HelperMethods.FilterString(list[1].GetName()),
                "3" => HelperMethods.FilterString(list[2].GetName()),
                "4" => HelperMethods.FilterString(list[3].GetName()),
                "5" => HelperMethods.FilterString(list[4].GetName()),
                "6" => HelperMethods.FilterString(list[5].GetName()),
                "7" => HelperMethods.FilterString(list[6].GetName()),
                "8" => HelperMethods.FilterString(list[7].GetName()),
                "9" => HelperMethods.FilterString(list[8].GetName()),
                "10" => HelperMethods.FilterString(list[9].GetName()),
                "11" => HelperMethods.FilterString(list[10].GetName()),
                "0" => "0",
                _ => "This category dosn't exist, select a visible one"
            };

            if (drink == "0")
            {
                Console.Clear();
                Console.WriteLine("Bye");
                Environment.Exit(0);
                return;
            }
            else if (drink == "This category dosn't exist, select a visible one")
            {
                Console.WriteLine(drink);
            }
            else
            {
                DrinksListView.SelectDrink(drink.Trim());
            }
        }
    }
}
