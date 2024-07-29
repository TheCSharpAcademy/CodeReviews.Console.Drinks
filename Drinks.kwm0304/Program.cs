using Spectre.Console;

namespace Drinks.kwm0304;

public class Program
{
  static async Task Main(string[] args)
  {
    using HttpClient client = new();
    while (true)
    {
      SessionLoop loop = new(client);
      await loop.OnStart();
    }
  }
}