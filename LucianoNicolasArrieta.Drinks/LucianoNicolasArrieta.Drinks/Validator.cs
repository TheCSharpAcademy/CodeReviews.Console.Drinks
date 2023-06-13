using LucianoNicolasArrieta.DrinksApp.Models;

namespace LucianoNicolasArrieta.DrinksApp
{
    public class Validator
    {
        public bool ValidateCategory(List<Category> categories, string user_input)
        {
            bool valid = user_input.Equals("0");

            if (valid == false)
            {
                valid = categories.Any(c => c.StrCategory.Equals(user_input, StringComparison.OrdinalIgnoreCase));
            }

            return valid;
        }

        public bool ValidateDrink(List<Drink> drinks, string user_input)
        {
            bool valid = user_input.Equals("0");

            if (valid == false)
            {
                valid = drinks.Any(c => c.IdDrink.Equals(user_input, StringComparison.OrdinalIgnoreCase));
            }

            return valid;
        }
    }
}
