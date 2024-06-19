using Drinks_Info.Services;

var apiService = new ApiService();

var result = await apiService.GetCategoriesAsync();

foreach (var category in result)
{
    Console.WriteLine("Category: " + category.StrCategory);
    Console.WriteLine("\n\n");
}