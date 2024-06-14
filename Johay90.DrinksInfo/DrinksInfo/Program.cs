using System.Configuration;

string? baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];

App app = new App(baseUrl);
await app.RunAsync();