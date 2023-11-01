namespace Drinks.K_MYR;

internal interface ISqlAcess
{
    public void CreateDbAndTables();
    
    public IEnumerable<DrinkDetailDto> GetDrinksBySearchDate();

    public IEnumerable<DrinkDetailDto> GetFavouriteDrinks();

    public bool DrinkRecordExists(int drinkId);

    public void InsertDrinkIntoDb(DrinkDetail drink, DateTime searchDate);

    public int DeleteDrinkFromDb(int drinkId);

    public void UpdateDrinkById(int drinkId, string args);
}
