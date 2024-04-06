using Microsoft.VisualBasic;
using Spectre.Console;

namespace drinks_info;

public abstract class Menu
{
    protected MenuManager MenuManager { get; }
    protected DrinksService DrinksService { get; }

    protected Menu(MenuManager menuManager, DrinksService drinksService)
    {
        MenuManager = menuManager;
        DrinksService = drinksService;
    }

    public abstract void Display();
}
public class MainMenu : Menu
{
    public MainMenu(MenuManager menuManager, DrinksService drinksService) : base(menuManager, drinksService) { }

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
                MenuManager.NewMenu(new CategoryMenu(MenuManager, DrinksService));
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
    public CategoryMenu(MenuManager menuManager, DrinksService drinksService) : base(menuManager, drinksService) { }

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
                MenuManager.NewMenu(new DrinksMenu(MenuManager, DrinksService, UserInterface.OptionChoice));
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

    public DrinksMenu(MenuManager menuManager, DrinksService drinksService, string optionChoice) : base(menuManager, drinksService)

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
                MenuManager.NewMenu(new DrinkDetailMenu(MenuManager, DrinksService, userDrink));
                break;
        }
    }
}

internal class DrinkDetailMenu : Menu
{
    private Drink _userDrink;

    public DrinkDetailMenu(MenuManager menuManager, DrinksService drinksService, Drink userDrink) : base(menuManager, drinksService)
    {
        _userDrink = userDrink;
    }

    public override void Display()
    {
        var drinkDetail = DrinksService.GetDrinkDetail(_userDrink);

        UserInterface.DrinkDetailMenu(drinkDetail);
    }
}