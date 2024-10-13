using Spectre.Console;

namespace DrinksInfo
{
  public static class Helper
  {
    public static void ContinueMessage()
    {
      Console.WriteLine("Press any key to continue");
      Console.ReadKey();
      Console.Clear();
    }

    public static void HandleException(Exception ex)
    {
      AnsiConsole.WriteException(ex);
      ContinueMessage();
    }
  }
}
