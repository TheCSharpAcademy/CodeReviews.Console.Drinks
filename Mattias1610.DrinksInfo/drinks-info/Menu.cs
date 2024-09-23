namespace drinks_info
{
    public class Menu
    {
        public void ShowMenu(){
            Console.Clear();
            Console.WriteLine("TYPE 1 TO SEE THE DRINKS");
            Console.WriteLine("TYPE 2 TO ADD A DRINK TO FAVOURITES");

            string choice = Console.ReadLine();

            switch(choice){
                case "1":
                    UserInput userInput = new();
                    userInput.GetCategoriesInput();
                    break;
                
                case "2":
                    Favourite favourite = new();
                    favourite.ShowMenu();
                    break;
            }
        }
    }
}