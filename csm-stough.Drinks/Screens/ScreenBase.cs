using csm_stough.Drinks.Services;
using Terminal.Gui;

namespace csm_stough.Drinks.Screens
{
    internal class ScreenBase : IScreen
    {
        protected FrameView background;

        public virtual void Init(params object[]? p)
        {
            background = new FrameView()
            {
                ColorScheme = new ColorScheme()
                {
                    Normal = Terminal.Gui.Attribute.Make(Color.White, Color.Blue)
                },
                Border = new Border()
                {
                    BorderThickness = new Thickness(0)
                },
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };

            MenuItem[] items = new MenuItem[]
            {
                new MenuItem("Home", "", () => {ScreenService.SetScreen(new MainMenu()); })
            };

            MenuBarItem homeButton = new MenuBarItem("Navigation", items);

            MenuBar menu = new MenuBar(new MenuBarItem[] {homeButton});

            background.Add(menu);
        }
    }
}
