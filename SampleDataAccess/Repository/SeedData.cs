using SampleDataAccess.Entities;

namespace SampleDataAccess.Repository;

public static class SeedData
{
    private static readonly string[] ImageUrls =
    {
        "https://images.freeimages.com/images/large-previews/a11/fall-pic-vermont-country-road-1568190.jpg",
        "https://images.freeimages.com/images/large-previews/532/pumpkin-patch-1492976.jpg",
        "https://images.freeimages.com/images/large-previews/8a5/shooting-the-sunset-1381775.jpg"
    };

    private static readonly HttpClient HttpClient = new();

    public static void Initialize(ImageDbContext context)
    {
        if (context.ApplicationImages.Any())
        {
            return;
        }

        context.ApplicationImages.AddRange(ImageUrls.Select((imageUrl, i) 
            => new ApplicationImage(0, (ImageType)i, DownloadImage(imageUrl))));

        context.SaveChanges();
    }

    private static byte[] DownloadImage(string imageUrl)
    {
        return HttpClient.GetByteArrayAsync(imageUrl).Result;
    }
}