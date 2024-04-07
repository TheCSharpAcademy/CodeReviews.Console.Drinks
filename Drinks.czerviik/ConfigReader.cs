using Microsoft.Extensions.Configuration;

namespace drinks_info;

public class ConfigReader
{
    public IConfigurationRoot Configuration { get; }

    public ConfigReader()
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }

#nullable enable
    public string GetConnectionString()
    {
        string? configString = Configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(configString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection'is not configured.");
        }
        return configString;
    }
}