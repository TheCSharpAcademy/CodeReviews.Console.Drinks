namespace Drinks.JsPeanut;
class Program
{
    public static bool exit = false;
    public static void Main(string[] args)
    {
        while (exit)
        {
            UserInput.GetCategoriesInput();
        }
    }
}