using csm_stough.Drinks.Services;
using Terminal.Gui;

namespace csm_stough.Drinks.Screens
{
    internal class CategoryScreen : ScreenBase
    {
        public override void Init(params object[]? p)
        {
            base.Init(p);

            TextField searchField = new TextField()
            {
                Text = "Search for a drink...",
                X = 1,
                Y = 2,
                Width = Dim.Percent(50),
                Height = 2
            };

            ComboBox categoryComboBox = new ComboBox(DrinkService.GetDrinkCategories())
            {
                X = Pos.Right(searchField) + 1,
                Y = searchField.Y,
                Width = Dim.Percent(25),
                Height = Dim.Fill(),
                SelectedItem = (int)p[0]
            };

            Button searchButton = new Button("Search")
            {
                X = Pos.Right(categoryComboBox) + 1,
                Y = searchField.Y,
                Width = Dim.Percent(25),
                Height = 1
            };

            ListView searchResultsList = new ListView(DrinkService.GetDrinksByCategory(p[1].ToString()))
            {
                X = 0,
                Y = Pos.Bottom(searchField),
                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };

            searchResultsList.OpenSelectedItem += (args) =>
            {
                ScreenService.SetScreen(new DrinkScreen(), args.Value);
            };

            searchButton.Clicked += () =>
            {
                if(string.IsNullOrEmpty(searchField.Text.ToString()))
                {
                    searchResultsList.SetSource(DrinkService.GetDrinksByCategory(categoryComboBox.Text.ToString()));
                }
                else
                {
                    searchResultsList.SetSource(DrinkService.SearchDrinks(searchField.Text.ToString(), categoryComboBox.Text.ToString()));
                }
            };

            background.Add(searchField, categoryComboBox, searchButton, searchResultsList);

            Application.Top.Add(background);
        }
    }
}
