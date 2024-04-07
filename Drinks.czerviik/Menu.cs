



namespace drinks_info;

public abstract class Menu
{
    protected MenuManager MenuManager { get; }
    protected DrinksService DrinksService { get; }
    protected DrinksDb DrinksDb { get; }

    protected Menu(MenuManager menuManager, DrinksService drinksService, DrinksDb drinksDb)
    {
        MenuManager = menuManager;
        DrinksService = drinksService;
        DrinksDb = drinksDb;
    }

    public abstract void Display();
}
public class MainMenu : Menu
{
    public MainMenu(MenuManager menuManager, DrinksService drinksService, DrinksDb drinksDb) : base(menuManager, drinksService, drinksDb) { }

    public override void Display()
    {
        UserInterface.MainMenu();
        HandleUserOptions();
    }

    private void HandleUserOptions()
    {
        switch (UserInterface.OptionChoice)
        {
            case "Pick a category":
                MenuManager.NewMenu(new CategoryMenu(MenuManager, DrinksService, DrinksDb));
                break;
            default:
                MenuManager.Close();
                break;
        }
    }
}

public class CategoryMenu : Menu
{
    private string[] _categoriesArray;
    public CategoryMenu(MenuManager menuManager, DrinksService drinksService, DrinksDb drinksDb) : base(menuManager, drinksService, drinksDb) { }

    public override void Display()
    {
        var categoriesList = DrinksService.GetCategories();

        _categoriesArray = Operations.ApiListToArray(categoriesList);

        UserInterface.CategoryMenu(_categoriesArray);
        HandleUserOptions();
    }

    private void HandleUserOptions()
    {
        switch (UserInterface.OptionChoice)
        {
            case "Go back":
                MenuManager.ReturnToMainMenu();
                break;
            default:
                MenuManager.NewMenu(new DrinksMenu(MenuManager, DrinksService, DrinksDb, UserInterface.OptionChoice));
                break;
        }
    }
}

internal class DrinksMenu : Menu
{
    private readonly MenuManager menuManager;
    private readonly string _userCategory;

    private List<Drink> drinksList;
    private string[] _drinksArray;

    public DrinksMenu(MenuManager menuManager, DrinksService drinksService, DrinksDb drinksDb, string optionChoice) : base(menuManager, drinksService, drinksDb)

    {
        _userCategory = optionChoice;
    }
    public override void Display()
    {
        drinksList = DrinksService.GetDrinks(_userCategory);

        _drinksArray = Operations.ApiListToArray(drinksList);

        UserInterface.DrinksMenu(_drinksArray);
        HandleUserOptions();
    }
    private void HandleUserOptions()
    {
        switch (UserInterface.OptionChoice)
        {
            case "Go back":
                MenuManager.ReturnToMainMenu();
                break;
            default:
                var userDrink = Operations.MatchOptionWithDrinkObject(UserInterface.OptionChoice, drinksList);
                DrinksDb.InsertSearch(userDrink);

                MenuManager.NewMenu(new DrinkDetailMenu(MenuManager, DrinksService, DrinksDb, userDrink));
                break;
        }
    }
}

internal class DrinkDetailMenu : Menu
{
    private Drink _userDrink;

    public DrinkDetailMenu(MenuManager menuManager, DrinksService drinksService, DrinksDb drinksDb, Drink userDrink) : base(menuManager, drinksService, drinksDb)
    {
        _userDrink = userDrink;
    }

    public override void Display()
    {
        var drinkDetail = DrinksService.GetDrinkDetail(_userDrink);
        
        UpdateIsFavorite(drinkDetail);
        UpdateSearchCount(drinkDetail);

        UserInterface.DrinkDetailMenu(drinkDetail);
        HandleUserOptions(drinkDetail);
    }

    private void UpdateSearchCount(DrinkDetail drinkDetail)
    {
        drinkDetail.SearchCount = DrinksDb.GetSearchCount(drinkDetail.Id);
    }

    private void UpdateIsFavorite(DrinkDetail drinkDetail)
    {
        if (DrinksDb.IsFavorite(drinkDetail.Id))
            drinkDetail.IsFavorite = true;
    }

    private void HandleUserOptions(DrinkDetail drinkDetail)
    {
        switch (UserInterface.OptionChoice)
        {
            case "Go back":
                MenuManager.GoBack();
                break;
            case "Return to Main menu":
                MenuManager.ReturnToMainMenu();
                break;
            case "Add to favorites":
                DrinksDb.AddToFavorites(drinkDetail.Id);
                UserInterface.DisplayMessage("Added to favorites!", "", true);
                MenuManager.DisplayCurrentMenu();
                break;
            case "Remove from favorites":
                DrinksDb.RemoveFromFavorites(drinkDetail.Id);
                UserInterface.DisplayMessage("Removed from favorites!", "", true);
                MenuManager.DisplayCurrentMenu();
                break;
        }
    }
}