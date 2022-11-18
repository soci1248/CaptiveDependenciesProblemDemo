using SampleDataAccess.Repository;

namespace SampleDataAccess.ProperSolution2;

public sealed class ApplicationImageCache2 : IApplicationImageCache2
{
    private readonly Func<IApplicationImageRepository> _applicationImageRepository;
    private readonly Func<IApplicationImageCacheStorage2> _storage;

    public ApplicationImageCache2(Func<IApplicationImageRepository> applicationImageRepository, Func<IApplicationImageCacheStorage2> storage)
    {
        _applicationImageRepository = applicationImageRepository ?? throw new ArgumentNullException(nameof(applicationImageRepository));
        _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        Console.WriteLine($"{GetType()} instance #{GetHashCode()} created from thread:  {Thread.CurrentThread.ManagedThreadId}");
    }

    public byte[] GetApplicationImage(ImageType imageType)
    {
        Console.WriteLine($"{GetType()}.{nameof(GetApplicationImage)} #{GetHashCode()}({imageType}) " +
                          $"call from thread: {Thread.CurrentThread.ManagedThreadId}");

        return _storage().GetApplicationImage(imageType, 
            kt => new Lazy<byte[]>(() => _applicationImageRepository().GetImage(kt)));
    }
}