using DrinksInfo;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IDrinksService, DrinksService>()
    .AddSingleton<UserInput>()
    .BuildServiceProvider();

var userInput = serviceProvider.GetRequiredService<UserInput>();

await userInput.GetCategoriesInput();