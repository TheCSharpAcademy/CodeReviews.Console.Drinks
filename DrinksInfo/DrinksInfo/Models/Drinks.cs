using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksInfo.Models
{
    internal class Drinks
    {
        [JsonProperty("drinks")]

        public List<Drink> DrinkList { get; set; }
    }
}
