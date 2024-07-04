using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksInfo.ukpagrace.DTO
{
    class MenuDto
    {
        public int Id { get; set; } 
        public string Name { get; set; } = String.Empty;
    }

    class DrinksDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Category { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public string Glass { get; set; } = String.Empty;
        public string Instructions { get; set; } = String.Empty;
        public List<string> Ingredients { get; set; } = new List<string>();
        public List<string> Measurements { get; set; } = new List<string>();
    }
}
