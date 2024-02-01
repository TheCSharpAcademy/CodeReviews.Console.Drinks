namespace Drinks.frockett;

internal class Program
{
    static void Main(string[] args)
    {
        var drinksService =  new DrinksService();
        var visualization = new Visualization();
        var validator = new Validator();
        var userInput = new UserInput(drinksService, visualization, validator);

        userInput.GetCategoriesInput();
    }
}
