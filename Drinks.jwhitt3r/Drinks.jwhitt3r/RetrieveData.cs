using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Drinks.jwhitt3r
{
    /// <summary>
    /// RetrieveData gathers all the data from an API of the users choice.
    /// </summary>
    class RetrieveData
    {
        public string ApiUrl { get; set; }
        public List<Program.DataRecord> items;
        public RetrieveData(string apiUrl) 
        {
            this.ApiUrl = apiUrl;
            this.items = new List<Program.DataRecord>();
            
        }

        public async Task<List<Program.DataRecord>> ProcessApiDataAsync(HttpClient client, string id = "")
        {
            await using Stream stream =
                await client.GetStreamAsync($"{this.ApiUrl}/{id}");
            var items =
                await JsonSerializer.DeserializeAsync<List<Program.DataRecord>>(stream);
            return items ?? new();
        }

        public async Task GetDataAsync(string userInput = "")
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

            this.items = await ProcessApiDataAsync(client, userInput);
        }

        internal async Task SearchByID(string userInput)
        {
            await GetDataAsync(userInput);
        }
    }

}
