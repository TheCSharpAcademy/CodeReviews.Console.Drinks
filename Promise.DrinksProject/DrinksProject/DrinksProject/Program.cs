using DrinksProject.Service;

HttpClient httpClient = new HttpClient();
DrinksService _drinksService = new(httpClient);

UserInput userInput = new(_drinksService);
userInput.GetCategoriesInput();