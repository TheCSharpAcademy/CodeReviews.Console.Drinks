namespace DrinksApi;

public class Response<T>(bool success, T data, string? message = null)
{
    public bool Success { get; } = success;

    public T Data { get; } = data;

    public string? Message = message;

    public void Deconstruct(out bool success, out T data)
    {
        success = Success;
        data = Data;
    }
}