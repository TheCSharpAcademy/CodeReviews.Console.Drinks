// C# Academy Drinks Info console application to learn use of APIs
// Check ReadMe at GitHub for more information

using DrinksInfo.HopelessCoding;
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            UserInput userInput = new();
            userInput.GetCategoriesInput();
        }
    }
}