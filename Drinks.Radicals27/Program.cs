/*
This app allows you to create cocktails quickly and easily via API calls
*/
using System.Reflection;
using Newtonsoft.Json;

namespace cocktails
{
    /// <summary>
    /// Responsible for the main app flow
    /// </summary>
    class Program
    {
        private static string baseUrl = "https://www.thecocktaildb.com/api/json/v1/1/";

        static async Task Main(string[] args)
        {
            while (true)
            {
                await ShowMainMenu();
            }
        }

        static async Task ShowMainMenu()
        {
            Console.Clear();

            List<Category> categories = await GetCategories();

            View.DisplayCategoriesMenu(categories);

            int input = await UserInput.GetNumberInput("Enter your choice, or press 0 to exit. ");

            if (input >= 1 && input <= categories.Count)
            {
                Console.Clear();
                Console.WriteLine("Please wait, retrieving drinks...");
                List<Drink> categoryDrinks = await GetDrinksByCategory(categories[input].strCategory);
                View.DisplayDrinksTable(categoryDrinks);

                int drinkInput = await UserInput.GetNumberInput("Enter a drink ID...");
                await GetDrinkFromInput(drinkInput);
            }
            else if (input == 0)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid choice. Press Enter to try again, or 0 to exit.");
                Console.ReadKey();
            }
        }

        internal static async Task<List<Category>> GetCategories()
        {
            List<Category> categories = new();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                try
                {
                    HttpResponseMessage response = await client.GetAsync("list.php?c=list");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        var serializedCategories = JsonConvert.DeserializeObject<Categories>(responseData);
                        return serializedCategories.CategoriesList;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                        Console.WriteLine($"Message: {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred:");
                    Console.WriteLine(ex.Message);
                }
            }

            return categories;
        }

        internal static async Task<List<Drink>> GetDrinksByCategory(string category)
        {
            string endpoint = $"filter.php?c={System.Web.HttpUtility.UrlEncode(category)}";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(endpoint);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        var serializedDrinks = JsonConvert.DeserializeObject<Drinks>(responseData);
                        return serializedDrinks.DrinkList;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                        Console.WriteLine($"Message: {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred:");
                    Console.WriteLine(ex.Message);
                }
            }

            return null;
        }

        internal static async Task GetDrinkFromInput(int drinkID)
        {
            string endpoint = $"lookup.php?i={drinkID}";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(endpoint);

                    if (response.IsSuccessStatusCode)
                    {
                        string rawResponse = await response.Content.ReadAsStringAsync();
                        var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);
                        List<DrinkDetail> returnedList = serialize.DrinkDetailList;
                        DrinkDetail drinkDetail = returnedList[0];
                        List<object> prepList = new();
                        string formattedName = "";

                        foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
                        {

                            if (prop.Name.Contains("str"))
                            {
                                formattedName = prop.Name.Substring(3);
                            }

                            if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                            {
                                prepList.Add(new
                                {
                                    Key = formattedName,
                                    Value = prop.GetValue(drinkDetail)
                                });
                            }
                        }

                        Console.Clear();
                        View.DisplayDrinkTable(prepList, drinkID);
                        Console.WriteLine("Press any key to return to main menu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                        Console.WriteLine($"Message: {response.ReasonPhrase}");
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred:");
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
        }
    }
}