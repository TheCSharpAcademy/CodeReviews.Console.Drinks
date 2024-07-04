using DrinksInfo.ukpagrace.DTO;
using System.Text.Json;


namespace DrinksInfo.ukpagrace.Service
{
    class DrinksService
    {
        public async Task<List<MenuDto>> ProcessCategoriesAsync()
        {
            using HttpClient client = new();
            int count = 0;
            List<MenuDto> menuDto = new();
            await using Stream stream =
                await client.GetStreamAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
            var categories = await JsonSerializer.DeserializeAsync<CategoriesResponse>(stream);
            foreach (var category in categories.Drinks ?? new())
            {
                menuDto.Add(new MenuDto() { Id = count++, Name = category.strCategory });
            }
            Console.WriteLine($"{menuDto.Count()}");
            return menuDto;
        }

        public async Task<List<MenuDto>> ProcessCategoryAsync(string category)
        {
            using HttpClient client = new();
            List<MenuDto> menuDto = new();
            await using Stream stream =
                await client.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={category}");
            var categories = await JsonSerializer.DeserializeAsync<CategoryResponse>(stream);
            foreach (var element in categories.Drinks ?? new())
            {
                menuDto.Add(new MenuDto() { Id = Convert.ToInt32(element.IdDrink), Name = element.Name});
            }
            return menuDto;

        }

        public async Task<DrinksDetailsDto> ProcessDrinkDetailsAsync(int id)
        {
            using HttpClient client = new();
            await using Stream stream =
                await client.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}");
            var elements = await JsonSerializer.DeserializeAsync<DetailsResponse>(stream);
            if (elements?.Drinks == null || elements.Drinks.Count == 0)
            {
                throw new ArgumentException($"No drink found with id {id}");
            }
            var details = elements.Drinks[0];

            Type type = details.GetType();
            DrinksDetailsDto dto = new DrinksDetailsDto()
            {
                Id = Convert.ToInt32(details.IdDrink),
                Name = details.Name,
                Category = details.Category,
                Type = details.Type,
                Glass = details.Glass,
                Instructions = details.Instruction
            };

            foreach (var prop in type.GetProperties())
            {
                if(prop.Name.Contains("Ingredient") && prop.GetValue(details) != null)
                {
                    dto.Ingredients.Add(prop.GetValue(details).ToString());
                    
                }else if (prop.Name.Contains("Measure") && prop.GetValue(details) != null)
                {
                    dto.Measurements.Add(prop.GetValue(details).ToString());
                }
            }
            return dto;
        }
    }
}

