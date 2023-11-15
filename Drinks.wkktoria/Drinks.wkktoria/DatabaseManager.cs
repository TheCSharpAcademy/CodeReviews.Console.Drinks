using System.Data;
using Microsoft.Data.SqlClient;

namespace Drinks.wkktoria;

internal class DatabaseManager
{
    private readonly SqlConnection _connection;
    private readonly string _databaseName;

    internal DatabaseManager(string connectionString, string databaseName)
    {
        _connection = new SqlConnection(connectionString);
        _databaseName = databaseName;
    }

    internal void Initialize()
    {
        try
        {
            _connection.Open();

            var query = $"""
                         IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = @databaseName)
                         BEGIN
                            CREATE DATABASE {_databaseName}
                         END

                         USE {_databaseName}

                         IF OBJECT_ID('Favorites', 'U') IS NULL
                         BEGIN
                            CREATE TABLE Favorites(
                                Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                                Name NVARCHAR(100) NOT NULL,
                                Category NVARCHAR(50) NOT NULL
                            )
                         END

                         IF OBJECT_ID('Searched', 'U') IS NULL
                         BEGIN
                            CREATE TABLE Searched(
                                Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                                Name NVARCHAR(100) NOT NULL,
                                Category NVARCHAR(50) NOT NULL,
                                Count INT NOT NULL
                            )
                         END
                         """;
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@databaseName", _databaseName);

            command.ExecuteNonQuery();
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to initialize database.");
        }
        finally
        {
            if (_connection.State == ConnectionState.Open) _connection.Close();
        }
    }
}