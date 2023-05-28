using csm_stough.Drinks.Screens;
using csm_stough.Drinks.Services;
using Terminal.Gui;

DrinkService.Init();
Application.Init();

ScreenService.SetScreen(new MainMenu());
