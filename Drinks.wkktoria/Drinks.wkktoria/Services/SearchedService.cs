using System.Data;
using Drinks.wkktoria.Models.Dtos;
using Microsoft.Data.SqlClient;

namespace Drinks.wkktoria.Services;

internal class SearchedService
{
    private readonly SqlConnection _connection;
    private readonly string _databaseName;

    internal SearchedService(string connectionString, string databaseName)
    {
        _connection = new SqlConnection(connectionString);
        _databaseName = databaseName;
    }

    internal List<SearchedDto> GetAll()
    {
        var searched = new List<SearchedDto>();

        try
        {
            _connection.Open();

            var query = $"""
                         USE {_databaseName}

                         Select Name, Category, Count FROM Searched
                         """;
            var command = new SqlCommand(query, _connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
                while (reader.Read())
                    searched.Add(new SearchedDto
                    {
                        Name = reader.GetString(0),
                        Category = reader.GetString(1),
                        Count = reader.GetInt32(2)
                    });
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to get searched drinks.");
        }
        finally
        {
            if (_connection.State == ConnectionState.Open) _connection.Close();
        }

        return searched;
    }

    internal void Add(SearchedDto searched)
    {
        try
        {
            _connection.Open();

            var query = $"""
                         USE {_databaseName}

                         INSERT INTO Searched(Name, Category, Count) VALUES(@name, @category, 1)
                         """;
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", searched.Name);
            command.Parameters.AddWithValue("@category", searched.Category);

            command.ExecuteNonQuery();
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to add drink to searched.");
        }
        finally
        {
            if (_connection.State == ConnectionState.Open) _connection.Close();
        }
    }

    internal void Update(SearchedDto searched)
    {
        try
        {
            _connection.Open();

            var query = $"""
                         USE {_databaseName}

                         UPDATE Searched SET Count = @count WHERE Name = @name AND Category = @category
                         """;
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@count", searched.Count);
            command.Parameters.AddWithValue("@name", searched.Name);
            command.Parameters.AddWithValue("@category", searched.Category);

            command.ExecuteNonQuery();
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to update searched.");
        }
        finally
        {
            if (_connection.State == ConnectionState.Open) _connection.Close();
        }
    }
}