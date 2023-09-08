using System.Threading.Tasks;

namespace Drinks.maccer989
{
    class Program
    {
        static async Task Main(string[] args)
        {
            UserInput userInput = new();
            userInput.GetCategoriesInput();
        }
    }
}

