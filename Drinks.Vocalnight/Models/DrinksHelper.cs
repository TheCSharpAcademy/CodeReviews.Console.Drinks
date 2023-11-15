namespace DrinksInfo.Models
{
    public static class DrinksHelper
    {
        public static List<T> EditList<T>( List<T> list ) where T : IDrinksJson
        {
            int enumeration = 0;

            list.ForEach(category =>
            {
                enumeration++;
                string newName = $"{enumeration} - " + category.GetName();
                category.ChangeName(newName);
            });

            return list;
        }
    }
}
