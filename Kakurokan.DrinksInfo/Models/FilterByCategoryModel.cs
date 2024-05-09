namespace Kakurokan.DrinksInfo.Models
{

    public class RootobjectFilterByCategory
    {
        public Filter[] drinks { get; set; }
    }

    public class Filter
    {
        public string strDrink { get; set; }
        public string strDrinkThumb { get; set; }
        public string idDrink { get; set; }
    }

}
