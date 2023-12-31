using System.Reflection;

namespace DrinksProgram;

public class DataController
{
    public bool RunDrinksProgram;
    public bool RunDrinksCategory;
    public bool RunDrinkDetail;
    public DrinksRequestService RequestService;

    public DataController()
    {
        RunDrinksProgram = true;
        RunDrinksCategory = false;
        RunDrinkDetail = false;
        RequestService = new();
    }

    public void MainMenuController()
    {
        string input;
        string? errorMessage = null;
        var categoriesTask = RequestService.ProcessCategoriesAsync();
        
        UI.WelcomeMessage();
        CategoriesJSON? categories = categoriesTask.Result;
 
        List<List<object>> categoriesUI = RemoveNullValues(categories?.Categories);       
        do
        {
            TableUI.PrintTable(categoriesUI,"Categories",["Category ID", "Category Name"]);
            UI.MainMenu(errorMessage);
            input = Console.ReadLine() ?? "";

            if(input.Equals("0"))
            {
                RunDrinksProgram = false;
            }
            else if(errorMessage == null) //input validation
            {
                RunDrinksCategory = true;
                DrinkCategoryController(input);
            }
        }
        while(RunDrinksProgram);

        UI.ExitMessage();
    }

    public void DrinkCategoryController(string category)
    {
        string input;
        string? errorMessage = null;
        var drinksTask = RequestService.ProcessDrinksByCategoryAsync(category);
        DrinksJSON? drinks = drinksTask.Result;
        List<List<object>> drinksUI = RemoveNullValues(drinks?.Drinks);
        do
        {
            TableUI.PrintTable(drinksUI, "Drinks", ["test", "test"]);
            input = Console.ReadLine() ?? "";
            
            if(input.Equals("0"))
            {
                RunDrinksCategory = false;
            }
            else if(errorMessage == null) //input validation
            {
                RunDrinkDetail = true;
            }
        }
        while(RunDrinksCategory);
    
    }



    public static List<List<object>> RemoveNullValues<T>(List<T>? list) where T : class
    {
        List<List<object>> listNotNullValues = [];
        
        if(list != null)
        {
            for(int i = 0; i< list.Count; i++)
            {
                foreach(PropertyInfo property in list[i].GetType().GetProperties())
                {
                    if(property.GetValue(list[i]) != null)
                    {
                        listNotNullValues.Add([property.Name, property.GetValue(list[i]) ?? ""]);
                    }
                }
            }
        }
        return listNotNullValues;
    }

    public static List<List<object>> RemoveNullValuesTest<T>(T? list) where T : class //remove
    {
        List<List<object>> listNotNullValues = [];
        
        if(list != null)
        {
                foreach(PropertyInfo property in list.GetType().GetProperties())
                {
                    if(property.GetValue(list) != null)
                    {
                        listNotNullValues.Add([property.Name, property.GetValue(list) ?? ""]);
                    }
                }
            
        }
        return listNotNullValues;
    }
}