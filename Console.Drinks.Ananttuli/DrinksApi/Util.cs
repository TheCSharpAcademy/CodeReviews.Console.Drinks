namespace DrinksApi;

public class Util
{
    public static T AssertNonNull<T>(T? item)
    {
        if (item == null)
        {
            throw new Exception("Missing value");
        }

        return item;
    }
}