namespace ConsoleDrinks.Doc415
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInterface userInterface = new();
            userInterface.MainMenu().Wait();
        }
    }
}
