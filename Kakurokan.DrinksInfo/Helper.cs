namespace Kakurokan.DrinksInfo
{
    public static class Helper
    {
        public static HttpClient Client { get; set; }

        public static void Initialize()
        {
            Client = new()
            {
                BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/")
            };
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
