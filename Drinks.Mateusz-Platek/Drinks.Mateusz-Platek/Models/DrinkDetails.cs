using Newtonsoft.Json;

namespace Drinks.Mateusz_Platek.Models;

public class DrinkDetails
{
    [JsonProperty("idDrink")]
    public int id { get; set; }
    [JsonProperty("strDrink")]
    public string name { get; set; }
    [JsonProperty("strDrinkAlternate")]
    public string altName { get; set; }
    [JsonProperty("strCategory")]
    public string category { get; set; }
    [JsonProperty("strAlcoholic")]
    public string alcoholic { get; set; }
    [JsonProperty("strGlass")]
    public string glass { get; set; }
    [JsonProperty("strInstructions")]
    public string instructions { get; set; }
    [JsonProperty("strIngredient1")]
    public string ingredient1 { get; set; }
    [JsonProperty("strIngredient2")]
    public string ingredient2 { get; set; }
    [JsonProperty("strIngredient3")]
    public string ingredient3 { get; set; }
    [JsonProperty("strIngredient4")]
    public string ingredient4 { get; set; }
    [JsonProperty("strIngredient5")]
    public string ingredient5 { get; set; }
    [JsonProperty("strIngredient6")]
    public string ingredient6 { get; set; }
    [JsonProperty("strIngredient7")]
    public string ingredient7 { get; set; }
    [JsonProperty("strIngredient8")]
    public string ingredient8 { get; set; }
    [JsonProperty("strIngredient9")]
    public string ingredient9 { get; set; }
    [JsonProperty("strIngredient10")]
    public string ingredient10 { get; set; }
    [JsonProperty("strIngredient11")]
    public string ingredient11 { get; set; }
    [JsonProperty("strIngredient12")]
    public string ingredient12 { get; set; }
    [JsonProperty("strIngredient13")]
    public string ingredient13 { get; set; }
    [JsonProperty("strIngredient14")]
    public string ingredient14 { get; set; }
    [JsonProperty("strIngredient15")]
    public string ingredient15 { get; set; }
    [JsonProperty("strMeasure1")]
    public string measure1 { get; set; }
    [JsonProperty("strMeasure2")]
    public string measure2 { get; set; }
    [JsonProperty("strMeasure3")]
    public string measure3 { get; set; }
    [JsonProperty("strMeasure4")]
    public string measure4 { get; set; }
    [JsonProperty("strMeasure5")]
    public string measure5 { get; set; }
    [JsonProperty("strMeasure6")]
    public string measure6 { get; set; }
    [JsonProperty("strMeasure7")]
    public string measure7 { get; set; }
    [JsonProperty("strMeasure8")]
    public string measure8 { get; set; }
    [JsonProperty("strMeasure9")]
    public string measure9 { get; set; }
    [JsonProperty("strMeasure10")]
    public string measure10 { get; set; }
    [JsonProperty("strMeasure11")]
    public string measure11 { get; set; }
    [JsonProperty("strMeasure12")]
    public string measure12 { get; set; }
    [JsonProperty("strMeasure13")]
    public string measure13 { get; set; }
    [JsonProperty("strMeasure14")]
    public string measure14 { get; set; }
    [JsonProperty("strMeasure15")]
    public string measure15 { get; set; }

    public DrinkDetails(int id, string name, string altName, string category, string alcoholic, string glass, string instructions, string ingredient1, string ingredient2, string ingredient3, string ingredient4, string ingredient5, string ingredient6, string ingredient7, string ingredient8, string ingredient9, string ingredient10, string ingredient11, string ingredient12, string ingredient13, string ingredient14, string ingredient15, string measure1, string measure2, string measure3, string measure4, string measure5, string measure6, string measure7, string measure8, string measure9, string measure10, string measure11, string measure12, string measure13, string measure14, string measure15)
    {
        this.id = id;
        this.name = name;
        this.altName = altName;
        this.category = category;
        this.alcoholic = alcoholic;
        this.glass = glass;
        this.instructions = instructions;
        this.ingredient1 = ingredient1;
        this.ingredient2 = ingredient2;
        this.ingredient3 = ingredient3;
        this.ingredient4 = ingredient4;
        this.ingredient5 = ingredient5;
        this.ingredient6 = ingredient6;
        this.ingredient7 = ingredient7;
        this.ingredient8 = ingredient8;
        this.ingredient9 = ingredient9;
        this.ingredient10 = ingredient10;
        this.ingredient11 = ingredient11;
        this.ingredient12 = ingredient12;
        this.ingredient13 = ingredient13;
        this.ingredient14 = ingredient14;
        this.ingredient15 = ingredient15;
        this.measure1 = measure1;
        this.measure2 = measure2;
        this.measure3 = measure3;
        this.measure4 = measure4;
        this.measure5 = measure5;
        this.measure6 = measure6;
        this.measure7 = measure7;
        this.measure8 = measure8;
        this.measure9 = measure9;
        this.measure10 = measure10;
        this.measure11 = measure11;
        this.measure12 = measure12;
        this.measure13 = measure13;
        this.measure14 = measure14;
        this.measure15 = measure15;
    }
}