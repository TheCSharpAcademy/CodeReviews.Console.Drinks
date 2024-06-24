namespace DrinksInfo.StevieTV.Helpers;

public static class GetDrinkThumbnail
{
    public static string SavedThumbnail(string url)
    {
        var filename = Path.GetTempPath() + Guid.NewGuid() + ".jpg";

        using var client = new System.Net.WebClient();

        try
        {
            client.DownloadFile(new Uri(url), filename);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            filename = "";
        }

        return filename;
    }
}