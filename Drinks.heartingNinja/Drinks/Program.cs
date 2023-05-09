namespace drinks_info;

class Program
{
    static void Main(string[] args)
    {
        UserInput userInput = new UserInput();
        userInput.GetCategoriesInput();
        Console.Read();
    }
}