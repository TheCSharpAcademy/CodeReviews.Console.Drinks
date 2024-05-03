namespace DrinksInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager databaseManager= new DatabaseManager();
            databaseManager.CreateTable();
            UserInput userInput= new UserInput();
            userInput.GetCategoryInput();
        }
    }
}
