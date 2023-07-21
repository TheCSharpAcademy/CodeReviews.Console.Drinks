namespace Drinks.JsPeanut;
class Program
{
    public static bool exitApp = false;
    public static void Main(string[] args)
    {
        while (exitApp)
        {
            UserInput.GetCategoriesInput();
        }
    }
}