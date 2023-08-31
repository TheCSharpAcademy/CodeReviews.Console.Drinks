namespace Drinks.w0lvesvvv
{
    public static class UserInput
    {
        public static string RequestString(string message)
        {
            Console.WriteLine();
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine() ?? string.Empty;
        }
    }
}
