using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_Info.Models
{
	internal class Category
	{
        public string strCategory { get; set; }
    }

	internal class Categories
	{
        [JsonProperty("drinks")]
        public List<Category> CategoriesList { get; set; }
    }
}
