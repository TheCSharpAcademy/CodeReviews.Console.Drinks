namespace Drinks.jwhitt3r
{
    class Program
    {

        public static void Main()
        {
            RetrieveData myData = new("https://api.punkapi.com/v2/beers/"); // Creates a new RetrieveData object that fetches the data from the API
            while (true)
            {
                char val = Menu.GenerateMenu();
                if (val == 'a')
                {
                    try
                    {
                        myData.GetDataAsync().Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    foreach (var item in myData.items)
                    {
                        Console.WriteLine($"{item.Id} - {item.Name}");
                    }
                }

                if (val == 'b')
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter an ID number you would like to query");
                    string userInput = Console.ReadLine();
                    myData.SearchByID(userInput).Wait();
                    foreach (var item in myData.items)
                    {

                        Console.WriteLine($"Beer Name: {item.Name}");
                        Console.WriteLine($"Beer Tagline: {item.Tagline}");
                        Console.WriteLine($"Beer Description: {item.Description}");
                        Console.WriteLine($"\t Yeast \n\t\t -> {item.Ingredients?.Yeast}");
                        Console.WriteLine("\t Malts");
                        for (int i = 0; i < item.Ingredients?.Malt?.Length; i++)
                        {
                            
                            Console.WriteLine($"\t\t -> {item.Ingredients.Malt[i].Name} - {item.Ingredients.Malt[i].Amount} ");
                        }
                        Console.WriteLine("\t Hops");
                        for (int i = 0; i < item.Ingredients?.Hops?.Length; i++)
                        {
                            Console.WriteLine($"\t\t -> {item.Ingredients.Hops[i].Name} - {item.Ingredients.Hops[i].Amount?.Value} {item.Ingredients.Hops[i].Amount?.Unit} ");
                        }
                    }

                }
            }
        }
    }
}


