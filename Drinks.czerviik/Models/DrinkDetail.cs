using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace drinks_info;

public class DrinkDetail : IModelEntity
{
    [JsonProperty("strDrink")] public string Name { get; set; }
    [JsonProperty("idDrink")] public string Id { get; set; }
    public object strDrinkAlternate { get; set; }
    public object strTags { get; set; }
    public object strVideo { get; set; }
    public string strCategory { get; set; }
    public object strIBA { get; set; }
    public string strAlcoholic { get; set; }
    public string strGlass { get; set; }
    public string strInstructions { get; set; }
    public object strInstructionsES { get; set; }
    public string strInstructionsDE { get; set; }
    public object strInstructionsFR { get; set; }
    public string strInstructionsIT { get; set; }
    public object strInstructionsZHHANS { get; set; }
    public object strInstructionsZHHANT { get; set; }
    public string strDrinkThumb { get; set; }
    public string strIngredient1 { get; set; }
    public string strIngredient2 { get; set; }
    public string strIngredient3 { get; set; }
    public string strIngredient4 { get; set; }
    public object strIngredient5 { get; set; }
    public object strIngredient6 { get; set; }
    public object strIngredient7 { get; set; }
    public object strIngredient8 { get; set; }
    public object strIngredient9 { get; set; }
    public object strIngredient10 { get; set; }
    public object strIngredient11 { get; set; }
    public object strIngredient12 { get; set; }
    public object strIngredient13 { get; set; }
    public object strIngredient14 { get; set; }
    public object strIngredient15 { get; set; }
    public string strMeasure1 { get; set; }
    public string strMeasure2 { get; set; }
    public string strMeasure3 { get; set; }
    public string strMeasure4 { get; set; }
    public object strMeasure5 { get; set; }
    public object strMeasure6 { get; set; }
    public object strMeasure7 { get; set; }
    public object strMeasure8 { get; set; }
    public object strMeasure9 { get; set; }
    public object strMeasure10 { get; set; }
    public object strMeasure11 { get; set; }
    public object strMeasure12 { get; set; }
    public object strMeasure13 { get; set; }
    public object strMeasure14 { get; set; }
    public object strMeasure15 { get; set; }
    public object strImageSource { get; set; }
    public object strImageAttribution { get; set; }
    [JsonProperty("strCreativeCommonsConfirmed")]public string CCConfirmed { get; set; }
    public string dateModified { get; set; }
}

public class DrinkDetailResponse
{
    [JsonProperty("drinks")] public List<DrinkDetail> DrinkDetails{get; set;}
}


