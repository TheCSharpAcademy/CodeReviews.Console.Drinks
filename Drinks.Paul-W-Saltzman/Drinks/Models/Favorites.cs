
namespace drinks_info.Models
{
    internal class Favorite
    {
        internal int FavoritesID { get; set; }
        internal int DrinkID { get; set; }
        internal string DrinkStr { get; set; }


        internal static bool InFavorites(string strDrinkID)
        {
            bool inFavorites = false;

            List<Favorite> favorites = Data.GetFavorites();

            if (int.TryParse(strDrinkID, out int parsedDrinkID))
            {
                // Check if the parsed drink id is in the favorites list
                inFavorites = favorites.Any(favorite => favorite.DrinkID == parsedDrinkID);
            }
            else
            {
                // Handle the case where parsing fails (drink id is not a valid int)
                Console.WriteLine("Error: Unable to parse Drink ID to an integer.");
                Console.ReadKey();
            }
            return inFavorites;
        }
    }
}