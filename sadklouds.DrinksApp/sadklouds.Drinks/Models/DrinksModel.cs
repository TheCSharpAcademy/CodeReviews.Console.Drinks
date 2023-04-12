using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace sadklouds.Drinks.Models
{

    public class DrinksModel
    {
        [JsonPropertyName("drinks")]
        public List<DrinkModel> DrinksList { get; set; }
    }

}
