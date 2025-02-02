using System.ComponentModel.DataAnnotations;

namespace Drinks.FunRunRushFlush.Data.Model;

public class DrinksApiSettings
{
    [Required]
    public string ApiBasePath { get; set; }

}
