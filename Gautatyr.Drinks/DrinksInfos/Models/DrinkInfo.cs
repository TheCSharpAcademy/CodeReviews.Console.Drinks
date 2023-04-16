using System.Text.Json.Serialization;

public record class DrinkInfoRoot(
    [property: JsonPropertyName("drinks")] DrinkInfo[] Infos);

public record class DrinkInfo(
    [property: JsonPropertyName("strDrink")] string DrinkName,
    [property: JsonPropertyName("strDrinkAlternate")] string DrinkAlternate,
    [property: JsonPropertyName("strTags")] string Tags,
    [property: JsonPropertyName("strCategory")] string Category,
    [property: JsonPropertyName("strIBA")] string IBA,
    [property: JsonPropertyName("strAlcoholic")] string Alcoholic,
    [property: JsonPropertyName("strGlass")] string Glass,
    [property: JsonPropertyName("strInstructions")] string Instructions,
    [property: JsonPropertyName("strIngredient1")] string Ingredient1,
    [property: JsonPropertyName("strIngredient2")] string Ingredient2,
    [property: JsonPropertyName("strIngredient3")] string Ingredient3,
    [property: JsonPropertyName("strIngredient4")] string Ingredient4,
    [property: JsonPropertyName("strIngredient5")] string Ingredient5,
    [property: JsonPropertyName("strIngredient6")] string Ingredient6,
    [property: JsonPropertyName("strIngredient7")] string Ingredient7,
    [property: JsonPropertyName("strIngredient8")] string Ingredient8,
    [property: JsonPropertyName("strIngredient9")] string Ingredient9,
    [property: JsonPropertyName("strIngredient10")] string Ingredient10,
    [property: JsonPropertyName("strIngredient11")] string Ingredient11,
    [property: JsonPropertyName("strIngredient12")] string Ingredient12,
    [property: JsonPropertyName("strIngredient13")] string Ingredient13,
    [property: JsonPropertyName("strIngredient14")] string Ingredient14,
    [property: JsonPropertyName("strIngredient15")] string Ingredient15,
    [property: JsonPropertyName("strMeasure1")] string Measure1,
    [property: JsonPropertyName("strMeasure2")] string Measure2,
    [property: JsonPropertyName("strMeasure3")] string Measure3,
    [property: JsonPropertyName("strMeasure4")] string Measure4,
    [property: JsonPropertyName("strMeasure5")] string Measure5,
    [property: JsonPropertyName("strMeasure6")] string Measure6,
    [property: JsonPropertyName("strMeasure7")] string Measure7,
    [property: JsonPropertyName("strMeasure8")] string Measure8,
    [property: JsonPropertyName("strMeasure9")] string Measure9,
    [property: JsonPropertyName("strMeasure10")] string Measure10,
    [property: JsonPropertyName("strMeasure11")] string Measure11,
    [property: JsonPropertyName("strMeasure12")] string Measure12,
    [property: JsonPropertyName("strMeasure13")] string Measure13,
    [property: JsonPropertyName("strMeasure14")] string Measure14,
    [property: JsonPropertyName("strMeasure15")] string Measure15)
{
    public List<string> MainInfos()
    {
        List<string> infos = new List<string>();
        if (!string.IsNullOrEmpty(DrinkName)) infos.Add($"Name: {DrinkName}");
        if (!string.IsNullOrEmpty(DrinkAlternate)) infos.Add($"Alternate: {DrinkAlternate}");
        if (!string.IsNullOrEmpty(Tags)) infos.Add($"Tags: {Tags}");
        if (!string.IsNullOrEmpty(Category)) infos.Add($"Category: {Category}");
        if (!string.IsNullOrEmpty(IBA)) infos.Add($"IBA: {IBA}");
        if (!string.IsNullOrEmpty(Alcoholic)) infos.Add($"Alcoholic: {Alcoholic}");
        if (!string.IsNullOrEmpty(Glass)) infos.Add($"Glass: {Glass}");
        return infos;
    }

    public string GetInstructions()
    {
        return Instructions;
    }

    public List<string> GetIngredients()
    {
        List<string> infos = new List<string>();
        if (!string.IsNullOrEmpty(Ingredient1)) infos.Add($"{Ingredient1}: {Measure1}");
        if (!string.IsNullOrEmpty(Ingredient2)) infos.Add($"{Ingredient2}: {Measure2}");
        if (!string.IsNullOrEmpty(Ingredient3)) infos.Add($"{Ingredient3}: {Measure3}");
        if (!string.IsNullOrEmpty(Ingredient4)) infos.Add($"{Ingredient4}: {Measure4}");
        if (!string.IsNullOrEmpty(Ingredient5)) infos.Add($"{Ingredient5}: {Measure5}");
        if (!string.IsNullOrEmpty(Ingredient6)) infos.Add($"{Ingredient6}: {Measure6}");
        if (!string.IsNullOrEmpty(Ingredient7)) infos.Add($"{Ingredient7}: {Measure7}");
        if (!string.IsNullOrEmpty(Ingredient8)) infos.Add($"{Ingredient8}: {Measure8}");
        if (!string.IsNullOrEmpty(Ingredient9)) infos.Add($"{Ingredient9}: {Measure9}");
        if (!string.IsNullOrEmpty(Ingredient10)) infos.Add($"{Ingredient10}: {Measure10}");
        if (!string.IsNullOrEmpty(Ingredient11)) infos.Add($"{Ingredient11}: {Measure11}");
        if (!string.IsNullOrEmpty(Ingredient12)) infos.Add($"{Ingredient12}: {Measure12}");
        if (!string.IsNullOrEmpty(Ingredient13)) infos.Add($"{Ingredient13}: {Measure13}");
        if (!string.IsNullOrEmpty(Ingredient14)) infos.Add($"{Ingredient14}: {Measure14}");
        if (!string.IsNullOrEmpty(Ingredient15)) infos.Add($"{Ingredient15}: {Measure15}");
        return infos;
    }
}

