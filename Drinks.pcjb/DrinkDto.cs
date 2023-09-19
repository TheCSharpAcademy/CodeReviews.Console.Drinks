namespace Drinks;

class DrinkDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Instructions { get; set; }
    public List<IngredientDto> Ingredients { get; set; }

    public DrinkDto(int id, string name)
    {
        Id = id;
        Name = name;
        Ingredients = new List<IngredientDto>();
    }

    public void AddIngredient(string? measure, string? name)
    {
        if (String.IsNullOrEmpty(measure) || String.IsNullOrEmpty(name))
        {
            return;
        }
        Ingredients.Add(new IngredientDto(measure, name));
    }
}