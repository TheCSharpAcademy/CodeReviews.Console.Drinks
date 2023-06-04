namespace ClassLibrary
{
    public static class HelperMethods
    {
        public static string CenterConsoleString( string text )
        {
            return String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text);
        }

        public static string filterString( string text )
        {
            return text.Remove(0, 4);
        }

        public static List<List<T>> Split<T>( IList<T> source )
        {
            return source
                .Select(( x, i ) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / 9)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}