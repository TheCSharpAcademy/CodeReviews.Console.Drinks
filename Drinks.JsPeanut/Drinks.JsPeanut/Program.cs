namespace Drinks.JsPeanut;
class Program
{
    public static bool exitApp;
    public static void Main(string[] args)
    {
        while (exitApp)
        {
            UserInput.GetCategoriesInput();
        }
    }
}