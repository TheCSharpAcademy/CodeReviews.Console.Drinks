using System.Data;
using Terminal.Gui;

namespace csm_stough.Drinks.Screens
{
    internal class DrinkScreen : ScreenBase
    {
        public override void Init(params object[]? p)
        {
            base.Init(p);

            Drink drink = p[0] as Drink;

            Label drinkNameLabel = new Label(drink.strDrink)
            {
                X = Pos.Center(),
                Y = Pos.At(1),
                Width = drink.strDrink.Length,
                Height = Dim.Sized(1),
            };

            background.Add(drinkNameLabel);
            
            if(drink.strIngredient1 != null)
            {
                background.Add(IngredientsSection(drink));
            }

            if(drink.strInstructions != null)
            {
                background.Add(InstructionsSection(drink));
            }

            Application.Top.Add(background);
        }

        public View IngredientsSection(Drink drink)
        {
            FrameView frameView = new FrameView("Ingredients")
            {
                X = 1,
                Y = Pos.At(2),
                Width = Dim.Fill(),
                Height = Dim.Percent(45)
            };

            DataTable ingredientsData = new DataTable();

            ingredientsData.Columns.Add("Ingredient");
            ingredientsData.Columns.Add("Measurement");
            
            for(int i = 1; i <= 15; i++)
            {
                string? ingredient = drink.GetType().GetProperty($"strIngredient{i}").GetValue(drink, null)?.ToString();
                string? measurement = drink.GetType().GetProperty($"strMeasure{i}").GetValue(drink, null)?.ToString();

                if(!string.IsNullOrEmpty(ingredient))
                {
                    ingredientsData.Rows.Add(ingredient, measurement);
                }
            }

            TableView tableView = new TableView(ingredientsData)
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };

            frameView.Add(tableView);

            return frameView;
        }

        public View InstructionsSection(Drink drink)
        {
            FrameView frameView = new FrameView("Instructions")
            {
                X = 1,
                Y = Pos.Percent(55),
                Width = Dim.Fill(),
                Height = Dim.Percent(45)
            };

            TextView instructionsView = new TextView()
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
                ReadOnly = true,
                Multiline = true,
                AllowsReturn = true,
                WordWrap = true,
            };

            instructionsView.Text = drink.strInstructions;

            frameView.Add(instructionsView);

            return frameView;
        }
    }
}
