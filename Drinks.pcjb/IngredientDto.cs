namespace Drinks;

class IngredientDto
{
    public string Measure { get; set; }
    public string Name { get; set; }

    public IngredientDto(string measure, string name)
    {
        Measure = measure;
        Name = name;
    }
}