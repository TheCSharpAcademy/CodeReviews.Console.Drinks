public class App
{
    private readonly IDrinksService _drinksService;
    private readonly DrinksController _drinksController;
    private readonly string _baseUrl;

    public App(string baseUrl)
    {
        _baseUrl = baseUrl;
        _drinksService = new DrinksService(_baseUrl);
        _drinksController = new DrinksController(_drinksService);
    }

    public async Task RunAsync()
    {
        var categories = await _drinksController.GetCategories();
        var drinksResponse = await _drinksController.GetDrinksByCategory(categories.Categories);
        


        Console.ReadKey();
    }
}

