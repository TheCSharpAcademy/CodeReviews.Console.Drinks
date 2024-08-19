namespace DrinksInfo;
internal class Program
{
    static async Task Main(string[] args)
    {
        int options = 1;
        do
        {
            string value = await View.DisplayMainMenu();
            Console.Clear();
            string key = await View.DisplayDrinkMenu(value);
            Console.Clear();
            await View.DisplayDrinkDetail(key);
            Console.WriteLine();
            options = View.Again();
            Console.Clear();
        } while (options == 0);
    }
}
