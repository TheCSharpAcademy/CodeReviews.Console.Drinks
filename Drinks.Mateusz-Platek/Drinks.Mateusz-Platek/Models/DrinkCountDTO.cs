namespace Drinks.Mateusz_Platek.Models;

public class DrinkCountDTO
{
    public int count { get; }
    public string name { get; }

    public DrinkCountDTO(int count, string name)
    {
        this.count = count;
        this.name = name;
    }
}