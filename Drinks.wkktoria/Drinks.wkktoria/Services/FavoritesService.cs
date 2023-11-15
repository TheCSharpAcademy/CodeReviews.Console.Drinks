using System.Data;
using Drinks.wkktoria.Models.Dtos;
using Microsoft.Data.SqlClient;

namespace Drinks.wkktoria.Services;

internal class FavoritesService
{
    private readonly SqlConnection _connection;
    private readonly string _databaseName;

    internal FavoritesService(string connectionString, string databaseName)
    {
        _connection = new SqlConnection(connectionString);
        _databaseName = databaseName;
    }

    internal List<FavoriteDto> GetAll()
    {
        var favorites = new List<FavoriteDto>();

        try
        {
            _connection.Open();

            var query = $"""
                         USE {_databaseName}

                         Select Name, Category FROM Favorites
                         """;
            var command = new SqlCommand(query, _connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
                while (reader.Read())
                    favorites.Add(new FavoriteDto
                    {
                        Name = reader.GetString(0),
                        Category = reader.GetString(1)
                    });
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to get favorites.");
        }
        finally
        {
            if (_connection.State == ConnectionState.Open) _connection.Close();
        }

        return favorites;
    }

    internal bool Add(FavoriteDto drink)
    {
        var added = false;

        try
        {
            _connection.Open();

            var query = $"""
                         USE {_databaseName}

                         INSERT INTO Favorites(Name, Category) VALUES(@name, @category)
                         """;
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", drink.Name);
            command.Parameters.AddWithValue("@category", drink.Category);

            added = command.ExecuteNonQuery() == 1;
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to add drink to favorites.");
        }
        finally
        {
            if (_connection.State == ConnectionState.Open) _connection.Close();
        }

        return added;
    }

    internal bool Delete(FavoriteDto drink)
    {
        var deleted = false;

        try
        {
            _connection.Open();

            var query = $"""
                         USE {_databaseName}

                         DELETE FROM Favorites WHERE Name = @name AND Category = @category
                         """;
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", drink.Name);
            command.Parameters.AddWithValue("@category", drink.Category);

            deleted = command.ExecuteNonQuery() == 1;
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to delete drink from favorites.");
        }
        finally
        {
            if (_connection.State == ConnectionState.Open) _connection.Close();
        }

        return deleted;
    }
}