using Newtonsoft.Json;

namespace DrinksInfo.Models;

public class MeasureList
{
    [JsonProperty("drinks")] public List<Measure> AllMeasures { get; set; }
}

public class Measure
{
    [JsonProperty("strMeasure1")] public string? Measure1 { get; set; }
    [JsonProperty("strMeasure2")] public string? Measure2 { get; set; }
    [JsonProperty("strMeasure3")] public string? Measure3 { get; set; }
    [JsonProperty("strMeasure4")] public string? Measure4 { get; set; }
    [JsonProperty("strMeasure5")] public string? Measure5 { get; set; }
    [JsonProperty("strMeasure6")] public string? Measure6 { get; set; }
    [JsonProperty("strMeasure7")] public string? Measure7 { get; set; }
    [JsonProperty("strMeasure8")] public string? Measure8 { get; set; }
    [JsonProperty("strMeasure9")] public string? Measure9 { get; set; }
    [JsonProperty("strMeasure10")] public string? Measure10 { get; set; }
    [JsonProperty("strMeasure11")] public string? Measure11 { get; set; }
    [JsonProperty("strMeasure12")] public string? Measure12 { get; set; }
    [JsonProperty("strMeasure13")] public string? Measure13 { get; set; }
    [JsonProperty("strMeasure14")] public string? Measure14 { get; set; }
    [JsonProperty("strMeasure15")] public string? Measure15 { get; set; }
}