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

    public static void ErrorMessage(string errorMessge)
    {
      Console.Clear();
      Console.WriteLine(errorMessge);
    }
  }
}
