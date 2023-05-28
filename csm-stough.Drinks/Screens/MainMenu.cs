using csm_stough.Drinks.Services;
using Terminal.Gui;

namespace csm_stough.Drinks.Screens
{
    internal class MainMenu : ScreenBase
    {
        public override void Init(params object[]? p)
        {
            base.Init(p);

            Label titleLabel = new Label(
                "'||''|.          ||         '||              '||    ||'                       \n" +
                " ||   || ... .. ... .. ...   ||  ..  ....     |||  |||   .... .. ...  ... ... \n" +
                " ||    || ||' '' ||  ||  ||  || .'  ||. '     |'|..'|| .|...|| ||  ||  ||  || \n" +
                " ||    || ||     ||  ||  ||  ||'|.  . '|..    | '|' || ||      ||  ||  ||  || \n" +
                ".||...|' .||.   .||..||. ||..||. ||.|'..|'   .|. | .||. '|...'.||. ||. '|..'|."
            )
            {
                X = Pos.Center(),
                Y = 2,
                Width = 78,
            };

            Label martiniLabel = new Label(
                "            .   \r\n" +
                ".---------.'---.\r\n" +
                "'.       :    .'\r\n" +
                "  '.  .:::  .'  \r\n" +
                "    '.'::'.'    \r\n" +
                "      '||'      \r\n" +
                "       ||       \r\n" +
                "       ||       \r\n" +
                "       ||       \r\n" +
                "   ---====---"
                )
            {
                X = Pos.Percent(9),
                Y = Pos.Percent(40),
            };

            Label wineLabel = new Label(
                " ____________ \r\n" +
                "<____________>\r\n" +
                "|            |\r\n" +
                "|            |\r\n" +
                " \\          /\r\n" +
                "  \\________/ \r\n" +
                "      ||      \r\n" +
                "   ___||___   \r\n" +
                "  /   ||   \\ \r\n" +
                "  \\________/"
                )
            {
                X = Pos.Percent(74),
                Y = Pos.Percent(40),
            };

            Label categoriesLabel = new Label("Drink Categories")
            {
                X = Pos.Center(),
                Y = Pos.Percent(40),
                Width = 16,
                Height = 1,
            };

            FrameView listFrame = new FrameView()
            {
                X = Pos.Center(),
                Y = Pos.Bottom(categoriesLabel),
                Width = Dim.Percent(25),
                Height = Dim.Percent(50),
            };

            ListView listView = new ListView(DrinkService.GetDrinkCategories())
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };

            listView.OpenSelectedItem += (item) =>
            {
                ScreenService.SetScreen(new CategoryScreen(), item.Item, item.Value);
            };

            listFrame.Add(listView);

            background.Add(titleLabel, martiniLabel, wineLabel, categoriesLabel, listFrame);

            Application.Top.Add(background);
        }
    }
}
