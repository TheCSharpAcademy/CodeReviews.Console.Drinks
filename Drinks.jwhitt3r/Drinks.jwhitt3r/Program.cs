namespace Drinks.jwhitt3r {
    class Program {

        public static void Main() {
            RetrieveData myData = new("https://api.punkapi.com/v2/beers"); // Creates a new RetrieveData object that fetches the data from the API
            while (true)
            {
                char val = Menu.GenerateMenu();
                if (val == 'a')
                {
                    myData.GetDataAsync().Wait();

                    foreach (var item in myData.items.Property1)
                    {
                        Console.WriteLine(item?.id);

                        Console.WriteLine();
                    }
                }

                if (val == 'b')
                {
                    Console.WriteLine("Please enter an ID number you would like to query");
                    string userInput = Console.ReadLine();
                    myData.SearchByID(userInput).Wait();
                    foreach (var item in myData.items.Property1)
                    {

                        Console.WriteLine(item?.id);
                        Console.WriteLine();
                    }
                }

            }
        }
    }
}


