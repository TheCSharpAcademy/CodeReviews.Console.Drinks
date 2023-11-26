using DrinksInfo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksInfo
{
    internal class Validation
    {
        public static bool IsValidCategory(string userInput, CategoriesList categoriesList)
        {
            if (string.IsNullOrEmpty(userInput) || categoriesList == null || categoriesList.drinks == null)
            {
                return false;
            }

            foreach (var category in categoriesList.drinks)
            {
                if (category.strCategory.Equals(userInput, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
        public static bool IsValidId(string userInput, DrinkList drinkList)
        {
            if (string.IsNullOrEmpty(userInput) || drinkList == null || drinkList.drinks == null)
            {
                return false;
            }

            foreach (var drink in drinkList.drinks)
            {
                if ((drink.idDrink.ToString()).Equals(userInput, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
