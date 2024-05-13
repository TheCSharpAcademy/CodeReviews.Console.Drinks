using Drinks.ASV.RestaurantDrinkMenu;

namespace Drinks.ASV;

public class Program
{
    static async Task Main()
    {
        App app = new App();
        await app.InitializeClientAsync();
    }
}


