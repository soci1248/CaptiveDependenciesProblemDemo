using System.Collections.Concurrent;
using SampleDataAccess.Repository;

namespace SampleDataAccess.BogusSolution2;

public sealed class ApplicationImageCacheBogus2 : IApplicationImageCacheBogus2
{
    private readonly Func<IApplicationImageRepository> _applicationImageRepository;
    private readonly ConcurrentDictionary<ImageType, Lazy<byte[]>> _applicationImages = new();

    public ApplicationImageCacheBogus2(Func<IApplicationImageRepository> applicationImageRepository)
    {
        _applicationImageRepository = applicationImageRepository ?? throw new ArgumentNullException(nameof(applicationImageRepository));
        Console.WriteLine($"{GetType()} instance #{GetHashCode()} created from thread:  {Thread.CurrentThread.ManagedThreadId}");
    }

    public byte[] GetApplicationImage(ImageType imageType)
    {
        Console.WriteLine($"{GetType()}.{nameof(GetApplicationImage)} #{GetHashCode()}({imageType}) " +
                          $"call from thread: {Thread.CurrentThread.ManagedThreadId}");

        return _applicationImages.GetOrAdd(imageType, it => new Lazy<byte[]>(() =>
            _applicationImageRepository().GetImage(it)))
            .Value;
    }
}