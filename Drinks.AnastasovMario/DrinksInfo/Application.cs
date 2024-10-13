using DrinksInfo.Models;
using Newtonsoft.Json;
using Spectre.Console;
using System.Net.Http;

namespace DrinksInfo
{
  public class Application
  {
    private readonly DrinksService _drinksService;

    public Application()
    {
      _drinksService = new DrinksService();
    }
    public async Task GetCategories()
    {
      await _drinksService.GetCategories();
    }
  }
}
