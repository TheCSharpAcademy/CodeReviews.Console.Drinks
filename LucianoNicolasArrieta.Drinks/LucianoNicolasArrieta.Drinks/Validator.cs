using LucianoNicolasArrieta.Drinks.Models;

namespace LucianoNicolasArrieta.Drinks
{
    public class Validator
    {
        public bool ValidateCategory(List<Category> categories, string user_input)
        {
            bool valid = user_input.Equals("0");

            if (valid == false)
            {
                valid = categories.Any(c => c.strCategory.Equals(user_input, StringComparison.OrdinalIgnoreCase));
            }

            return valid;
        }
    }
}
