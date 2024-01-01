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
        var categories = categoriesTask.Result;
 
        do
        {
            Helpers.ClearConsole();
            TableUI.PrintTable(categories?.Categories,"Categories");
            UI.MainMenu(errorMessage);
            input = Console.ReadLine() ?? "";
            errorMessage = InputValidation.ValidateCategoryName(categories, input);

            if(input.Equals("0"))
            {
                RunDrinksProgram = false;
            }
            else if(errorMessage == null) //input validation
            {
                RunDrinksCategory = true;
                DrinkCategoryController(input.Replace(" ","_"));
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
        var drinks = drinksTask.Result;
        int rangeStart = 0;
        int rangeCount;
        if(drinks.Drinks.Count>=10)
            rangeCount = 10;
        else
            rangeCount = drinks.Drinks.Count;

        do
        {
            Helpers.ClearConsole();
            TableUI.PrintTable(drinks?.Drinks.GetRange(rangeStart, rangeCount), category);
            UI.DrinksByCategory(errorMessage);
            input = Console.ReadLine() ?? "";
            errorMessage = InputValidation.ValidateDrinkID(drinks, input);
            
            switch(input)
            {
                case("0"):
                    RunDrinksCategory = false;    
                    break;
                case("N"):
                    // if(rangeCount+rang )
                    // rangeStart += rangeCount;

                    break;
                case("P"):
                
                    break;
            }

            if(errorMessage == null) //input validation
            {
                RunDrinkDetail = true;
                DrinkDetailController(input);
            }
        }
        while(RunDrinksCategory);
    
    }

    public void DrinkDetailController(string idDrink)
    {
        string input;
        var drinkTask = RequestService.ProcessDrinksByIDAsync(idDrink);
        var drink = drinkTask.Result;
        var drinkUI = RemoveNullValues(drink?.Drinks[0]);
        do
        {
            Helpers.ClearConsole();
            TableUI.PrintTable(drinkUI, "Drink Detail");
            input = Console.ReadLine() ?? "";
            if(input.Equals("0"))
            {
                RunDrinkDetail = false;
            }
        }
        while(RunDrinkDetail);
    }

    public static List<object> RemoveNullValues<T>(T? list) where T : class //remove
    {
        List<object> listNotNullValues = [];
        
        if(list != null)
        {
                foreach(PropertyInfo property in list.GetType().GetProperties())
                {
                    if(property.GetValue(list) != null)
                    {
                        listNotNullValues.Add(new 
                        {
                            property.Name, 
                            Value = property.GetValue(list) ?? ""
                        });
                    }
                }
            
        }
        return listNotNullValues;
    }
}