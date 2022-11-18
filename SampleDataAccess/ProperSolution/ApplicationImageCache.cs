using SampleDataAccess.Repository;

namespace SampleDataAccess.ProperSolution;

public sealed class ApplicationImageCache : IApplicationImageCache
{
    private readonly Func<IApplicationImageRepository> _applicationImageRepository;
    private readonly Func<IApplicationImageCacheStorage> _storage;

    public ApplicationImageCache(Func<IApplicationImageRepository> applicationImageRepository, Func<IApplicationImageCacheStorage> storage)
    {
        _applicationImageRepository = applicationImageRepository ?? throw new ArgumentNullException(nameof(applicationImageRepository));
        _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        Console.WriteLine($"{GetType()} instance #{GetHashCode()} created from thread:  {Thread.CurrentThread.ManagedThreadId}");
    }

    public byte[] GetApplicationImage(ImageType imageType)
    {
        Console.WriteLine($"{GetType()}.{nameof(GetApplicationImage)} #{GetHashCode()}({imageType}) " +
                          $"call from thread: {Thread.CurrentThread.ManagedThreadId}");

        return _storage().GetApplicationImage(imageType, kt => _applicationImageRepository().GetImage(kt));
    }
}