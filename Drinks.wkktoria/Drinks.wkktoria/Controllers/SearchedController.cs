using Drinks.wkktoria.Services;
using Drinks.wkktoria.UserInterface;

namespace Drinks.wkktoria.Controllers;

internal class SearchedController
{
    private readonly SearchedService _searchedService;

    internal SearchedController(SearchedService searchedService)
    {
        _searchedService = searchedService;
    }

    internal void ShowTop()
    {
        Console.Clear();

        var allSearched = _searchedService.GetAll();

        if (allSearched.Any())
        {
            var topSearched = allSearched.OrderByDescending(searched => searched.Count).ToList();
            var topFew = topSearched.Count < 10 ? topSearched.Take(3).ToList() : topSearched.Take(10).ToList();

            TableVisualisationEngine.ShowTable(topFew, "Most searched drinks");
        }
        else
        {
            Console.WriteLine("No searched drinks.");
        }


        Helpers.PressAnyKeyToContinue();
    }
}