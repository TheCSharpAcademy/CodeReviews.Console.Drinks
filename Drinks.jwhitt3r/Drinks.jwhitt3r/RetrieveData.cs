using System.Net.Http.Json;


namespace Drinks.jwhitt3r
{
    /// <summary>
    /// RetrieveData gathers all the data from an API of the users choice.
    /// </summary>
    class RetrieveData
    {
        /// <summary>
        /// The API URL that is provided by the creator
        /// </summary>
        public string ApiUrl { get; set; }
        /// <summary>
        /// The object structure that is used to place the returned data
        /// </summary>
        public List<Class1> items;

        /// <summary>
        /// Default constructor for the creation of the object.
        /// </summary>
        /// <param name="apiUrl">The API URL that is defined by the creator of the object</param>
        public RetrieveData(string apiUrl) 
        {
            this.ApiUrl = apiUrl;
            this.items = new List<Class1>();
        }

        /// <summary>
        /// ProcessAPIDataAsync deserializes the data returned from the API and places it into a 
        /// list constructed of the data that is defined by the user
        /// </summary>
        /// <param name="client">The HTTP Client that is defined by GetDataAsync</param>
        /// <param name="id">The ID of the object if provided by the user, this is empty by default</param>
        /// <returns>A task is returned to ensure that the program waits for the data to be returned</returns>
        public async Task<List<Class1>> ProcessApiDataAsync(HttpClient client, string id = "")
        {
            return await client.GetFromJsonAsync<List<Class1>>($"{this.ApiUrl}/{id}") ?? new();
        }

        /// <summary>
        /// Creates a connection with the appropriate headers to be used to send to the server
        /// </summary>
        /// <param name="userInput">an ID reference used for identifying an item from the API. It is null by default</param>
        /// <returns>Returns an Async task to ensure that the program waits for the data to be returned</returns>
        public async Task GetDataAsync(string userInput = "")
        {
            using HttpClient client = new();
            this.items = await ProcessApiDataAsync(client, userInput);
        }

        /// <summary>
        /// Allows the user search by ID for an object that is returned by the API
        /// </summary>
        /// <param name="userInput">The users ID input</param>
        /// <returns>A task is returned to ensure that the program waits for the data to be returned</returns>
        internal async Task SearchByID(string userInput)
        {
            await GetDataAsync(userInput);
        }
    }

}
