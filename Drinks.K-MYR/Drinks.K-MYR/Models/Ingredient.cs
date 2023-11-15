namespace Drinks.K_MYR.Models
{
    internal class Ingredient
    {
        public string Name { get; set; }

        public string Measure { get; set; }

        public Ingredient(string name, string measure)
        {
            Name = name;
            Measure = measure;
        }
    }
}
