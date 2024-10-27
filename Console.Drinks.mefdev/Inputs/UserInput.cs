using Spectre.Console;
using Services;

namespace Inputs;

    public class UserInput
    {
        private readonly ManageDrinks _manageDrinks;
        public UserInput(ManageDrinks manageDrinks){
            _manageDrinks = manageDrinks;
        }
        public async Task<string> GetCategoryName()
        {
            var currentCategories = await GetCategories();
            return AnsiConsole
            .Prompt(new SelectionPrompt<string>()
            .Title("Select a [blue]Category[/]?")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more choices)[/]")
            .AddChoices(currentCategories));
        }

        public async Task<string[]> GetCategories(){

            List<string> categoryArrList = new List<string>();
            var categories = await _manageDrinks.ProcessCategories();
            if(categories == null){
                AnsiConsole.MarkupLine("Nothing to show the data is empty");
                return null;
            }
            foreach (var drink in categories.drinks)
            {
                categoryArrList.Add(drink.strCategory);
            }
            return categoryArrList.ToArray();
        }

        public string GetDrinkId()
        {
            return AnsiConsole
           .Prompt(new TextPrompt<string>("Enter a drink ID:")
           .Validate(input =>
           {
               return string.IsNullOrWhiteSpace(input)
                   ? ValidationResult.Error("Drink ID cannot be empty.")
                   : ValidationResult.Success();
           }));
    }
}
