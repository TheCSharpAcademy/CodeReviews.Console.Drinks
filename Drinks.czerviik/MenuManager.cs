namespace drinks_info;

public class MenuManager
{
    private readonly Stack<Menu> _menuStack = new Stack<Menu>();

    public MenuManager(DrinksService drinksService)
    {
        _menuStack.Push(new MainMenu(this,drinksService));
    }

    public void DisplayCurrentMenu()
    {
        if (_menuStack.Count > 0)
        {
            Menu currentMenu = _menuStack.Peek();
            currentMenu.Display();
        }
    }

    public void NewMenu(Menu menu)
    {
        _menuStack.Push(menu);
        DisplayCurrentMenu();
    }

    public void GoBack()
    {
        if (_menuStack.Count > 1)
            _menuStack.Pop();
        DisplayCurrentMenu();
    }

    public void ReturnToMainMenu()
    {
        while (_menuStack.Count > 1)
            _menuStack.Pop();
        DisplayCurrentMenu();
    }

    public void Close()
    {
        Environment.Exit(0);
    }
}
