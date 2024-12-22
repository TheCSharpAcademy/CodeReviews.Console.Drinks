namespace Drinks.yemiOdetola;

public class Helper
{

  public bool IsStringValid(string input)
  {
    if (string.IsNullOrEmpty(input))
    {
      return false;
    };

    foreach (char character in input)
    {
      if (!Char.IsLetter(character) && character != '/' && character != ' ')
      {
        return false;
      }
    }

    return true;
  }

  public bool IsIdValid(string drink)
  {
    if (string.IsNullOrEmpty(drink))
    {
      return false;
    }

    foreach (char character in drink)
    {
      if (!Char.IsDigit(character))
      {
        return false;
      }
    }
    return true;
  }
}
