namespace Drinks.ASV.Helper;

internal class Validation
{
    internal static bool IsGivenInputInteger(string input)
    {
        if (int.TryParse(input, out _))
            return true;
        else
            return false;
    }
}