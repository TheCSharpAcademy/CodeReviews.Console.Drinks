namespace DrinksInfo
{
    internal static class Validation
    {
        
        public static bool CheckCategory(string category)
        {
            if (category == "") throw new Exception("Input is empty");
            DrinkService drinksService = new();
            var categories = drinksService.GetCategories();

            if (categories.Any(x => x.StrCategory == category)) return true;
            else throw new Exception($"There is no category such a {category}");
        }

        public static bool CheckDrink(string category, int id)
        {
            if (category == "") throw new Exception("Input is empty.");
            DrinkService drinksService = new();
            var drinksdetail = drinksService.GetDrinksByCategory(category);

            if (drinksdetail.Any(x => x.IdDrink == id.ToString())) return true;
            else throw new Exception($"There is no such a drink.");
        }
    }
}
