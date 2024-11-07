
namespace Dtos;

public class DrinkDetailsResponse
{
    public List<DrinkDetails> Drinks { get; set; }
}
public class NonNullDrinkDetails
{
    public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
}

