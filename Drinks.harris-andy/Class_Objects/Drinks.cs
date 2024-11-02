using Newtonsoft.Json;

namespace DrinksInfo.Class_Objects;

public class DrinkResponse
{
    [JsonProperty("drinks")]
    public List<Drink> Drinks { get; set; } = new List<Drink>();
}

[JsonConverter(typeof(DrinkConverter))]
public class Drink
{
    public int ID { get; set; }

    [JsonProperty("strDrink")]
    public string StrDrink { get; set; } = null!;

    [JsonProperty("idDrink")]
    public int DrinkID { get; set; }

    [JsonProperty("strGlass")]
    public string Glass { get; set; } = null!;

    [JsonProperty("strInstructions")]
    public string Instructions { get; set; } = null!;

    public List<string?> Ingredients { get; set; } = new List<string?>();

    public List<string?> Measures { get; set; } = new List<string?>();

    public List<string> CombinedIngMsrList { get; set; } = new List<string>();

    public void CombineIngredientsMeasures()
    {
        for (int i = 0; i < Ingredients.Count(); i++)
        {
            if (i < Measures.Count() && !string.IsNullOrEmpty(Measures[i]))
            {
                string combo = $"{Ingredients[i]}: {Measures[i]}";
                CombinedIngMsrList.Add(combo);
            }
            else
            {
                CombinedIngMsrList.Add($"{Ingredients[i]}");
            }
        }
    }
}
