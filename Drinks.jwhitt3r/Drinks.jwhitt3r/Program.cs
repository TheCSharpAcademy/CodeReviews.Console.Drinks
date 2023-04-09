// See https://aka.ms/new-console-template for more information

using Drinks.jwhitt3r;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Drinks.jwhitt3r {
    class Program {

        public record DataRecord(
            [property: JsonPropertyName("id")] int DataOne,
            [property: JsonPropertyName("name")] string DataTwo,
            [property: JsonPropertyName("tagline")] string DataThree,
            [property: JsonPropertyName("ingredients")] Dictionary<string, JsonNode> DataFour
            );
        public static void Main() {
            Console.WriteLine("\nBrewDog Beer Menu");
            RetrieveData myData = new("https://api.punkapi.com/v2/beers");
            myData.GetDataAsync().Wait();
            foreach (var item in myData.items)
            {
                Console.WriteLine($"ID: {item.DataOne}");
                Console.WriteLine($"Name: {item.DataTwo}");
                Console.WriteLine($"Tagline: {item.DataThree}");
                var dat = item.DataFour.ToList();

                Console.WriteLine();
            }

            Console.WriteLine("Please enter an ID number you would like to query");
            string userInput = Console.ReadLine();
            myData.SearchByID(userInput).Wait();
            foreach (var item in myData.items)
            {
                Console.WriteLine($"ID: {item.DataOne}");
                Console.WriteLine($"Name: {item.DataTwo}");
                var dat = item.DataFour.ToList();
                foreach (var d in dat)
                {
                    Console.WriteLine($"{d.Key}");
                    if (d.Value.GetType() == typeof(JsonArray))
                    {
                        foreach (var e in d.Value.AsArray())
                        {
                            Console.Write($"\t{e["name"]} - {e["amount"]["value"]} in {e["amount"]["unit"]}\n");
                        }

                    }
                    else
                    {
                        Console.Write($"\t{d.Value}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}


