using System.Data.SqlClient;
using Drinks.Mateusz_Platek.Models;

namespace Drinks.Mateusz_Platek;

public static class DrinkRepository
{
    public static List<Drink> GetFavoriteDrinks()
    {
        List<Drink> drinks = new List<Drink>();
        
        using SqlConnection sqlConnection = new SqlConnection(@"Server=(localdb)\DrinksInfo;Database=drinksInfo;Trusted_Connection=True;");
        sqlConnection.Open();
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = "SELECT * FROM favoriteDrinks";
        
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        if (sqlDataReader.HasRows)
        {
            while (sqlDataReader.Read())
            {
                Drink drink = new Drink(
                    sqlDataReader.GetInt32(1), 
                    sqlDataReader.GetString(2)
                );
                
                drinks.Add(drink);
            }
        }

        return drinks;
    }
    
    public static void AddFavoriteDrink(Drink drink)
    {
        using SqlConnection sqlConnection = new SqlConnection(@"Server=(localdb)\DrinksInfo;Database=drinksInfo;Trusted_Connection=True;");
        sqlConnection.Open();
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"INSERT INTO favoriteDrinks (apiID, name) VALUES ({drink.id}, '{drink.name}')";
        sqlCommand.ExecuteNonQuery();
    }

    public static void RemoveFavoriteDrink(Drink drink)
    {
        using SqlConnection sqlConnection = new SqlConnection(@"Server=(localdb)\DrinksInfo;Database=drinksInfo;Trusted_Connection=True;");
        sqlConnection.Open();
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = $"DELETE FROM favoriteDrinks WHERE apiID = {drink.id}";
        sqlCommand.ExecuteNonQuery();
    }

    public static List<DrinkCountDTO> GetDrinksSearchCount()
    {
        List<DrinkCountDTO> drinkCountDTOs = new List<DrinkCountDTO>();

        using SqlConnection sqlConnection = new SqlConnection(@"Server=(localdb)\DrinksInfo;Database=drinksInfo;Trusted_Connection=True;");
        sqlConnection.Open();
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = "SELECT * FROM drinksSearchCount";
        
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        if (sqlDataReader.HasRows)
        {
            while (sqlDataReader.Read())
            {
                DrinkCountDTO drinkCountDTO = new DrinkCountDTO(
                    sqlDataReader.GetInt32(2), 
                    sqlDataReader.GetString(3)
                );

                drinkCountDTOs.Add(drinkCountDTO);
            }
        }
        
        return drinkCountDTOs;
    }

    public static void CountDrink(Drink drink)
    {
        using SqlConnection sqlConnection = new SqlConnection(@"Server=(localdb)\DrinksInfo;Database=drinksInfo;Trusted_Connection=True;");
        sqlConnection.Open();
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        sqlCommand.CommandText = @$"
            IF EXISTS(SELECT * FROM drinksSearchCount WHERE apiID = {drink.id})
                BEGIN
                    UPDATE drinksSearchCount SET count = count + 1 WHERE apiID = {drink.id}
                END
            ELSE
                BEGIN
                    INSERT INTO drinksSearchCount (apiID, name) VALUES ({drink.id}, '{drink.name}')
                END";
        sqlCommand.ExecuteNonQuery();
    }
}