using DrinksInfo.BBualdo;

AppEngine app = new();

while (app.IsRunning)
{
  await app.CategoriesMenu();
}