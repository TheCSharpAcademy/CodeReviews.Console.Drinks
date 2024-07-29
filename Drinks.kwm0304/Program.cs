namespace Drinks.kwm0304;

public class Program
{
  static async Task Main()
  {
    using HttpClient client = new();
    while (true)
    {
      SessionLoop loop = new(client);
      await loop.OnStart();
    }
  }
}