
public interface IDrinksService
{
    Task<T> GetAsync<T>(string endpoint);
}