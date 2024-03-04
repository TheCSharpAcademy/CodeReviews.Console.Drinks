using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks.samggannon
{
    
    public class UserInput
    {
        DrinkService drinkService = new();

        internal void GetCategoriesINput()
        {
            drinkService.GetCategories();

        }
    }
}
