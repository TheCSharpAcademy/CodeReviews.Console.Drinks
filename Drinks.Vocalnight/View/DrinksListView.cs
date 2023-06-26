using ClassLibrary;
using DrinksInfo.API;
using DrinksInfo.Models;

namespace DrinksInfo.View
{
    public static class DrinksListView
    {
        internal static void SelectDrink( string category )
        {
            int index = 0;

            List<Drink> drinksList = DrinkListAPI.GetDrinksList(category);
            List<List<Drink>> separatedDrinks = HelperMethods.Split(drinksList);

            //Give each chunk of drinks a separated enumeration from 1 to 9 so the user can select with the numpad no matter the page he is viewing.
            foreach (List<Drink> drinks in separatedDrinks)
            {
                DrinksHelper.EditList(drinks);
            }

            while (true)
            {

                CreateTableEngine.ShowTable(separatedDrinks[index], category);
                Console.WriteLine($"Page {index + 1} of {separatedDrinks.Count()}");

                Console.WriteLine("Choose a drink with the numpad, press left and right to change pages or press ESC to return.");

                ConsoleKey drinkChoice = Console.ReadKey().Key;
                Console.Clear();

                // Separate the commands from the actual selection so the switch is cleaner
                // and we can retrieve the string with the name of the drink to use in the search.
                if (drinkChoice == ConsoleKey.LeftArrow && index > 0)
                {
                    index--;
                }
                else if (drinkChoice == ConsoleKey.RightArrow && index < separatedDrinks.Count() - 1)
                {
                    index++;
                }
                else if (drinkChoice == ConsoleKey.Escape)
                {
                    Console.Clear();
                    CategoriesView.SelectCategory();
                }
                
                if (drinkChoice != ConsoleKey.Escape 
                    && drinkChoice != ConsoleKey.RightArrow && drinkChoice != ConsoleKey.LeftArrow) {

                    string choosenDrink = drinkChoice switch
                    {
                        ConsoleKey.NumPad1 => separatedDrinks[index][0].GetName(),
                        ConsoleKey.NumPad2 => separatedDrinks[index][1].GetName(),
                        ConsoleKey.NumPad3 => separatedDrinks[index][2].GetName(),
                        ConsoleKey.NumPad4 => separatedDrinks[index][3].GetName(),
                        ConsoleKey.NumPad5 => separatedDrinks[index][4].GetName(),
                        ConsoleKey.NumPad6 => separatedDrinks[index][5].GetName(),
                        ConsoleKey.NumPad7 => separatedDrinks[index][6].GetName(),
                        ConsoleKey.NumPad8 => separatedDrinks[index][7].GetName(),
                        ConsoleKey.NumPad9 => separatedDrinks[index][8].GetName(),
                    };

                    DrinkView.GetDrink(HelperMethods.FilterString(choosenDrink), category);
                }
            }
        }
    }
}
