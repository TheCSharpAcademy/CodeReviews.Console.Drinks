using DrinksInfo;

namespace DrinksInfo;

public class Program
{
    public static void Main(string[] args)
    {
        Controller controller = new Controller();
        controller.ShowCategories();
    }
}
