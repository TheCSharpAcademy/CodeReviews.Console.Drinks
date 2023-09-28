namespace DrinksInfo
{
    internal class Manager
    {
        public UI Ui { get; set; }
        public DrinkService DrinkServiceInstance { get; set; }
        private string Category { get; set; } = "";

        public Manager()
        {
            Ui = new UI();
            DrinkServiceInstance = new DrinkService();
            BeginService();
        }

        private void BeginService()
        {
            DrinkServiceInstance.GetCategories();
            ChooseCategory();
            ChooseDrink();
        }

        private void ChooseDrink()
        {
            try
            {
                int id = Ui.GetInput("Select ID of drink to see info.").val;
                if (Validation.CheckDrink(Category, id))
                {
                    DrinkServiceInstance.GetDrinksDetail(id);
                }
            }
            catch (Exception e)
            {
                UI.Write(e.Message);
            }
            UI.WaitForInput("Press any key..");
            BeginService();
        }

        private void ChooseCategory()
        {
            try
            {
                Category = Ui.GetInput("Select").str;
                if (Validation.CheckCategory(Category))
                {
                    DrinkServiceInstance.GetDrinksByCategory(Category);
                }
            }
            catch(Exception e)
            {
                UI.Write(e.Message);
                UI.WaitForInput();
                BeginService();
            }

        }
    }
}
