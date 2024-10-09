public static class ErrorHandling
{
    public static void HandleApiError(Exception ex)
    {
        Console.WriteLine("There was an error fetching data from the API.");
        Console.WriteLine($"Error: {ex.Message}");
    }

    public static void HandleInvalidInput()
    {
        Console.WriteLine("Invalid input, please try again.");
    }
}
