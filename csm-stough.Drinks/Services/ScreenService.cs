using Terminal.Gui;

namespace csm_stough.Drinks.Services
{
    internal class ScreenService
    {
        public static void SetScreen(IScreen screen, params object[]? p)
        {
            Application.Top.RemoveAll();
            screen.Init(p);
            Application.Run();
        }
    }
}
