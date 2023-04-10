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
                        Console.WriteLine($"{item.id} - {item.name}");
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

                        Console.WriteLine($"Beer Name: {item.name}");
                        Console.WriteLine($"Beer Tagline: {item.tagline}");
                        Console.WriteLine($"Beer Description: {item.description}");
                        Console.WriteLine($"\t Yeast \n\t\t -> {item.ingredients?.yeast}");
                        Console.WriteLine("\t Malts");
                        for (int i = 0; i < item.ingredients.malt.Length; i++)
                        {
                            
                            Console.WriteLine($"\t\t -> {item.ingredients.malt[i].name} - {item.ingredients.malt[i].amount} ");
                        }
                        Console.WriteLine("\t Hops");
                        for (int i = 0; i < item.ingredients.hops.Length; i++)
                        {
                            Console.WriteLine($"\t\t -> {item.ingredients.hops[i].name} - {item.ingredients.hops[i].amount?.value} {item.ingredients.hops[i].amount?.unit} ");
                        }
                    }

                }
            }
        }
    }
}


