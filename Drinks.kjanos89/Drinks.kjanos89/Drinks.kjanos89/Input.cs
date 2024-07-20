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
            Console.WriteLine("Choose a drink from the list below or press '0' to go back to the Categories menu:");
            string drinkChoice = Console.ReadLine();
            if(drinkChoice=="0")
            {
                GetCategories();
            }
            while (!validation.IsValidId(drinkChoice))
            {
                Console.WriteLine("Try again..");
                choice = Console.ReadLine();
            }
            controller.GetIngredients(drinkChoice);
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
            GetCategories();
        }
    }
}
