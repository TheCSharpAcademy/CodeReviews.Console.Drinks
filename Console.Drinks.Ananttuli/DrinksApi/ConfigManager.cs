using Microsoft.Extensions.Configuration;

namespace DrinksApi;

public class ConfigManager
{
    private static IConfiguration? _config;

    public static IConfiguration Config
    {
        get
        {
            if (_config == null)
            {
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false);

                _config = builder.Build();
            }

            return _config ?? throw new Exception("Invalid config");
        }

        set
        {
            _config = value;
        }
    }

    public static IConfiguration ApiRoutes()
    {
        return Config.GetSection("API_ROUTES");
    }
}