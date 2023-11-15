using Newtonsoft.Json;
using System.Collections.Generic;

namespace Drinks.maccer989
{
    public class Category
    {
        public string strCategory { get; set; }
    }

    public class Categories
    {
        [JsonProperty("drinks")]
        public List<Category> CategoriesList { get; set; }
    }
}
