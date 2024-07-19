using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks.kjanos89
{
    public class Input
    {
        ApiController controller=new ApiController();
        Validation validation=new Validation();
        public void GetCategories()
        {
            controller.GetCategories();
            Console.WriteLine("Choose a category from the list below:");
            string choice=Console.ReadLine();
            while(!validation.IsValidString(choice))
            {
                Console.WriteLine("Try again..");
                choice = Console.ReadLine();
            }
            GetDrinks(choice);
        }

        public void GetDrinks(string choice)
        {
            controller.GetDrinks(choice);
        }
    }
}
