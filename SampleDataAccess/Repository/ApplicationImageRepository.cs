using SampleDataAccess.Entities;

namespace SampleDataAccess.Repository;

internal sealed class ApplicationImageRepository : IApplicationImageRepository
{
    private readonly IImageDbContext _dbContext;

    public ApplicationImageRepository(IImageDbContext dbContext)
    {
        _dbContext = dbContext;
        Console.WriteLine($"{GetType()} instance #{GetHashCode()} created from thread: {Thread.CurrentThread.ManagedThreadId}");
    }

    public byte[] GetImage(ImageType imageType)
    {
        Console.WriteLine($"{GetType()}.{nameof(GetImage)} #{GetHashCode()}({imageType}) call start from thread: {Thread.CurrentThread.ManagedThreadId}");
        
        ApplicationImage? image = _dbContext.ApplicationImages.SingleOrDefault(i => i.ImageType == imageType);
        if (image == null)
        {
            throw new InvalidOperationException($"Missing image for {imageType}");
        }

        Console.WriteLine($"{GetType()}.{nameof(GetImage)} #{GetHashCode()}({imageType}) call end from thread: {Thread.CurrentThread.ManagedThreadId}");

        return image.ImageContent;
    }
}