using Newtonsoft.Json;
using ConsoleDrinks.AnaClos.Models;

namespace ConsoleDrinks.AnaClos.Controllers;

public class CategoriesController
{
    ServiceController serviceController;

    public CategoriesController(ServiceController serviceController) 
    { 
        this.serviceController = serviceController;
    }

    public List<Category> GetCategories()
    {
        var rawResponse = serviceController.GetResponse("list.php?c=list");
        List<Category> listCategories;

        if (rawResponse != string.Empty)
        {
            var categories = JsonConvert.DeserializeObject<Categories>(rawResponse);
            listCategories = categories.CategoriesList;
        }
        else 
        { 
            listCategories = null;
        }
        return listCategories;
    }

    public List<string> GetCategoriesNames(List<Category> listCategories)
    {
        return listCategories.Select(x=>x.strCategory).ToList();
    }
}