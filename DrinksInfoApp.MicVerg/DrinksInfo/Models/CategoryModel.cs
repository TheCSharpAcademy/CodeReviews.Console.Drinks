using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksInfo.Models
{
    internal class CategoryModel
    {
        public string strCategory { get; set; }
    }
    internal class CategoriesList
    {
        public List<CategoryModel> drinks { get; set; }
    }
}
