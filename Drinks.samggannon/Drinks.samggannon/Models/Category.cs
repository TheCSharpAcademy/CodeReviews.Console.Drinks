using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks.samggannon.Models;

public class Category
{
    [JsonProperty("strCategory")]
    public string strCategory { get; set; } = string.Empty;
}

public class Categories
{
    [JsonProperty("drinks")]
    public List<Category> CategoriesList { get; set; }
}
