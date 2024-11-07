using System.Text;
using SkiaSharp;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Services
{
    public static class ImageRenderer
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static void RenderImage(string imagePath)
        {
            // Load the image
            using var input = File.OpenRead(imagePath);
            using var original = SKBitmap.Decode(input);

            // Create a new bitmap to draw on
            using var bitmap = new SKBitmap(original.Width, original.Height);
            using var canvas = new SKCanvas(bitmap);

            // Draw the original image onto the canvas
            canvas.DrawBitmap(original, new SKPoint(0, 0));

            // Save the rendered image as a new file or process it further
            using var image = SKImage.FromBitmap(bitmap);
            using var imageData = image.Encode(SKEncodedImageFormat.Png, 100);

            // Specify the output path
            var outputPath = Path.Combine(Environment.CurrentDirectory, "output.png");
            using var output = File.OpenWrite(outputPath);
            imageData.SaveTo(output);

            Console.WriteLine($"Image saved to {outputPath}");
        }

        public static async Task<string> RenderImageFromUrl(string imageUrl)
        {
            var imagePath = Path.Combine(Environment.CurrentDirectory, "drink_image.png");

            using (var response = await _httpClient.GetAsync(imageUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    using (var input = await response.Content.ReadAsStreamAsync())
                    using (var output = File.OpenWrite(imagePath))
                    {
                        await input.CopyToAsync(output);
                    }
                    return imagePath;
                }
                else
                {
                    Console.WriteLine("Failed to download image.");
                    return null;
                }
            }
        }

        public static IRenderable RenderImageAsMarkup(string imagePath)
        {
            try
            {
                using var original = SKBitmap.Decode(imagePath);

                int maxWidth = 40;
                int maxHeight = 20;

                var width = Math.Min(original.Width, maxWidth);
                var height = Math.Min(original.Height, maxHeight);
                using var resized = original.Resize(new SKImageInfo(width, height), SKFilterQuality.Medium);

                var markupBuilder = new StringBuilder();

                // Build ANSI markup for each pixel
                for (int y = 0; y < resized.Height; y++)
                {
                    for (int x = 0; x < resized.Width; x++)
                    {
                        var pixel = resized.GetPixel(x, y);
                        var hexColor = ColorToHex(pixel);
                        markupBuilder.Append($"[#{hexColor}]\u2588[/]"); // Full block character
                    }
                    markupBuilder.AppendLine(); // New line after each row
                }

                return new Markup(markupBuilder.ToString());
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine("[red]Error rendering image:[/] " + ex.Message);
                return new Markup("[red]Image not available[/]");
            }
        }

        private static string ColorToHex(SKColor color)
        {
            return $"#{color.Red:X2}{color.Green:X2}{color.Blue:X2}";
        }
    }
}
