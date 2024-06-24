using Newtonsoft.Json;

namespace drinks_info.Models
{
    public class Drinks
    {
        [JsonProperty("drinks")]
        public List<Drink> DrinksList { get; set; }
    }

    public class Drink
    {
        public string idDrink { get; set; }
        public string strDrink { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Drink otherDrink = (Drink)obj;
            return idDrink == otherDrink.idDrink && strDrink == otherDrink.strDrink;
        }

        public override int GetHashCode()
        {
            // Combine hash codes of individual properties
            return HashCode.Combine(idDrink, strDrink);
        }
    } 
}