using Spectre.Console;
using DrinksApi.Drinks;
using DrinksApi.Categories;

namespace Program;

public class CategoriesController
{
    public static CategoryDto? SelectCategory(List<CategoryDto> categories)
    {
        var backButton = new CategoryDto(Utils.ConsoleUtil.MenuBackButtonText);

        var selectedCategory = AnsiConsole.Prompt(
            new SelectionPrompt<CategoryDto>()
                .Title("\nCATEGORIES")
                .AddChoices([
                    backButton,
                    ..categories
                ])
                .EnableSearch()
        );

        if (
            selectedCategory == null ||
            selectedCategory.Equals(backButton)
        )
        {
            return null;
        }

        return selectedCategory;
    }

    public static DrinkFilterListItemDto? SelectDrinkFromCategory(CategoryDto category, List<DrinkFilterListItemDto> drinksInCategory)
    {
        var selectedDrink = AnsiConsole.Prompt(
            new SelectionPrompt<DrinkFilterListItemDto>()
                .Title($"\n{category.StrCategory}   -   DRINKS\n")
                .AddChoices([
                    new DrinkFilterListItemDto("", Utils.ConsoleUtil.MenuBackButtonText, ""),
                    ..drinksInCategory
                ])
                .EnableSearch()
        );

        if (selectedDrink == null || selectedDrink.IdDrink.Equals(""))
        {
            return null;
        }

        return selectedDrink;
    }
}