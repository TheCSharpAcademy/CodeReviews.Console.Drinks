using Newtonsoft.Json;
namespace Drinks.JaegerByte.DataModels
{
    public class Drinks
    {
        [JsonProperty("drinks")]
        public List<DataModels.Drink> DrinkList { get; set; }
    }
    public class Drink
    {
        [JsonProperty("idDrink")]
        public string ID { get; set; }
        [JsonProperty("strDrink")]
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
