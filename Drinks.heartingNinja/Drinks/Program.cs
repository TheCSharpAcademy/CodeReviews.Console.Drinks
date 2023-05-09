using System;
namespace drinks_info;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello World");
        UserInput userInput = new UserInput();
        userInput.GetCategoriesInput();
        Console.Read();
    }
}