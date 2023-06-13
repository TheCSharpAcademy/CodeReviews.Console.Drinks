using LucianoNicolasArrieta.DrinksApp;

namespace drinks_info
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Drinks App!");
            
            Menu menu = new Menu();
            menu.RunCategoriesMenu();
        }
    }
}