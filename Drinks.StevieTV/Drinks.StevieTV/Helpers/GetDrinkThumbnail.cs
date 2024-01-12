using System.Net;

namespace DrinksInfo.StevieTV.Helpers;

public static class GetDrinkThumbnail
{
    public static string SavedThumbnail(string url)
    {
        var filename = Path.GetTempPath() + Guid.NewGuid() + ".jpg";

        using var client = new WebClient();

        client.DownloadFile(new Uri(url), filename);

        return filename;
    }
}