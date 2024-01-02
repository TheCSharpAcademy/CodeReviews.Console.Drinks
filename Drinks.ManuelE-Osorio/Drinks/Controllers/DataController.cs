using System.Reflection;

namespace DrinksProgram;

public class DataController
{
    public bool RunDrinksProgram;
    public bool RunDrinksCategory;
    public readonly int PageSize = 10;
    public DrinksRequestService RequestService;

    public DataController()
    {
        RunDrinksProgram = true;
        RunDrinksCategory = false;
        RequestService = new();
    }

    public void MainMenuController()
    {
        ConsoleKey key;
        string? errorMessage = null;
        var categoriesTask = RequestService.ProcessCategoriesAsync();
        int selectionOffset = 0;
        CategoriesJSON categories = new();
        UI.WelcomeMessage();

        try
        {
            categories = categoriesTask.Result ?? new CategoriesJSON();
            categories.Categories[selectionOffset].Selected = ">";
        }
        catch
        {
            errorMessage = "Connection problem. Please check your internet connection.";
            RunDrinksProgram = false;
        }
 
        while(RunDrinksProgram)
        {
            Helpers.ClearConsole();
            TableUI.PrintTable(categories.Categories,"Categories");
            UI.MainMenu();
            key = Console.ReadKey(true).Key;
            
            switch(key)
            {
                case(ConsoleKey.UpArrow):
                    categories.Categories[selectionOffset].Selected = "";
                    selectionOffset--;
                    if(selectionOffset<0)
                        selectionOffset++;
                    categories.Categories[selectionOffset].Selected = ">";
                    break;

                case(ConsoleKey.DownArrow):
                    categories.Categories[selectionOffset].Selected = "";
                    selectionOffset++;
                    if(selectionOffset>categories.Categories.Count)
                        selectionOffset--;
                    categories.Categories[selectionOffset].Selected = ">";
                    break;


                case(ConsoleKey.Escape):
                case(ConsoleKey.Backspace):
                    RunDrinksProgram = false;
                    break;

                case(ConsoleKey.Enter):
                    RunDrinksCategory = true;
                    DrinkCategoryController(categories.Categories[selectionOffset].Category
                    .Replace(" ","_"));
                    break;
            }
        }

        UI.ExitMessage(errorMessage);
    }

    public void DrinkCategoryController(string category)
    {
        ConsoleKey inputKey;
        int rangeStart = 0;
        int rangeCount = 0;
        int selectionOffset = 0;

        var drinksTask = RequestService.ProcessDrinksByCategoryAsync(category);
        Console.WriteLine("Loading...");
        DrinksByCategoryJSON drinksNotNull = new();
        try
        {    
            drinksNotNull = drinksTask.Result ?? new DrinksByCategoryJSON();
            if(drinksNotNull.Drinks.Count>=10)
                rangeCount = 10;
            else
                rangeCount = drinksNotNull.Drinks.Count;
            drinksNotNull.Drinks[selectionOffset+rangeStart].Selection = ">";
        }
        catch
        {
            Console.WriteLine("Connection problem. Please check your internet connection.");
            Thread.Sleep(1000);
            RunDrinksCategory = false;
        }

        while(RunDrinksCategory)
        {
            Helpers.ClearConsole();
            TableUI.PrintTable(drinksNotNull.Drinks.GetRange(rangeStart, rangeCount), category);
            UI.DrinksByCategory();
            inputKey = Console.ReadKey(true).Key;

            
            switch(inputKey)
            {
                case(ConsoleKey.Escape):
                case(ConsoleKey.Backspace):
                    RunDrinksCategory = false;    
                    break;

                case(ConsoleKey.RightArrow):
                    drinksNotNull.Drinks[selectionOffset+rangeStart].Selection = "";   

                    rangeStart = NextPageStart(rangeStart, rangeCount, drinksNotNull.Drinks.Count);
                    rangeCount = NextPageCount(rangeStart, rangeCount, drinksNotNull.Drinks.Count);
                    if(selectionOffset >= rangeCount)
                        selectionOffset = rangeCount -1;

                    drinksNotNull.Drinks[selectionOffset+rangeStart].Selection = ">";   
                    break;

                case(ConsoleKey.LeftArrow):
                    drinksNotNull.Drinks[selectionOffset+rangeStart].Selection = "";   
                    rangeStart = PreviousPageStart(rangeStart);
                    rangeCount = PreviousPageCount(rangeStart, rangeCount, drinksNotNull.Drinks.Count);
                    drinksNotNull.Drinks[selectionOffset+rangeStart].Selection = ">";   
                    
                    break;

                case(ConsoleKey.DownArrow):
                    drinksNotNull.Drinks[selectionOffset+rangeStart].Selection = "";
                    selectionOffset++;
                    if(selectionOffset >= rangeCount)
                        selectionOffset = rangeCount - 1;

                    drinksNotNull.Drinks[selectionOffset+rangeStart].Selection = ">";                    
                    break;

                case(ConsoleKey.UpArrow):
                    drinksNotNull.Drinks[selectionOffset+rangeStart].Selection = "";
                    selectionOffset--;
                    if(selectionOffset<0)
                        selectionOffset = 0;

                    drinksNotNull.Drinks[selectionOffset+rangeStart].Selection = ">";
                    break;
                
                case(ConsoleKey.Enter):
                    DrinkDetailController(drinksNotNull.Drinks[selectionOffset+rangeStart].ID);
                    break;
            }
        }

    
    }

    public void DrinkDetailController(string idDrink)
    {
        Console.WriteLine("Loading...");
        var drinkTask = RequestService.ProcessDrinksByIDAsync(idDrink);
        List<object>? drinkUI = [];
        try
        {
            var drink = drinkTask.Result;
            drinkUI = RemoveNullValues(drink?.Drinks[0]);
        }
        catch
        {
            Console.WriteLine("Connection problem. Please check your internet connection.");
            Thread.Sleep(1000);
        }
        Helpers.ClearConsole();
        TableUI.PrintTable(drinkUI, "Drink Detail");
        UI.DrinkDetail();
        Console.ReadKey();
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

    public int NextPageStart(int rangeStart, int rangeCount, int length)
    {
        if(rangeStart+PageSize < length)
            rangeStart+=PageSize;
        return rangeStart;
    }

    public static int NextPageCount(int rangeStart, int rangeCount, int length)
    {
        if(rangeStart + rangeCount >= length)
            rangeCount = length - rangeStart;
        return rangeCount;
    }

    public int PreviousPageStart(int rangeStart)
    {
        if(rangeStart >= PageSize)
            rangeStart -= PageSize;
        return rangeStart;
    }

    public int PreviousPageCount(int rangeStart, int rangeCount, int length)
    {
        if(rangeStart + PageSize <= length)
            rangeCount = PageSize;
        return rangeCount;
    }
}