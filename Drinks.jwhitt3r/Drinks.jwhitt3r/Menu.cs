namespace Drinks.jwhitt3r
{
    static class Menu
    {
        /// <summary>
        /// Presents the user with the main menu and then calls the GetUserInput function.
        /// </summary>
        /// <returns></returns>
        public static char GenerateMenu()
        {
            Console.WriteLine(@" BrewDog Beer Menu
                A) Get all beers
                B) Search a beer by ID
                P) Print menu
                Q) Exit
            ");
            return GetUserInput();
        }
      
        /// <summary>
        /// Runs through the userinput logic to determine which menu item they have picked.
        /// </summary>
        /// <returns>Returns a character</returns>
        public static char GetUserInput()
        {
            char userInput = Console.ReadKey().KeyChar;
            Console.WriteLine($"\nYou entered: {userInput}");
            switch (char.ToLower(userInput))
            {
                case 'a':
                    return 'a';
                case 'b':
                    return 'b';
                case 'p':
                    GenerateMenu();
                    break;
                case 'q':
                    Console.WriteLine("Q - Quit Menu");
                    Console.WriteLine("Thank you for viewing the latest brewdog beers...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("No character input placed, printing menu...");
                    return 'p';
            }
            return 'p';
        }
    }
}

