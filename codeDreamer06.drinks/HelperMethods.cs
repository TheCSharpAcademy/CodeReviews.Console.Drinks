using Newtonsoft.Json.Linq;

namespace Drinks
{
    public class HelperMethods
    { 
        public static string helpMessage = @"
Welcome to our homey cocktail restaurant!
What kind of cocktail do you want?
1 Show me all the categories
2 Show me different glasses
3 Show me all the ingredients
4 Show me by alcoholic content
        ";
        public static void DisplayDataAsTable(JToken[] data)
        {

            int longestStringLength = data.Max(item => item.ToString().Length) + 6;
            for (int i = 0; i < data.Count(); i++)
            {
                Console.WriteLine(new string('-', longestStringLength));
                Console.WriteLine($"| {i + 1} {data[i]}".PadRight(longestStringLength - 1) + "|");
            }

            Console.WriteLine(new string('-', longestStringLength));
        }
    }
}
