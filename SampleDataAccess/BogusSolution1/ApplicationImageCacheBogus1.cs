using System.Collections.Concurrent;
using SampleDataAccess.Repository;

namespace SampleDataAccess.BogusSolution1;

public sealed class ApplicationImageCacheBogus1 : IApplicationImageCacheBogus1
{
    private readonly Func<IApplicationImageRepository> _applicationImageRepository;
    private readonly ConcurrentDictionary<ImageType, byte[]> _applicationImages = new();

    public ApplicationImageCacheBogus1(Func<IApplicationImageRepository> applicationImageRepository)
    {
        _applicationImageRepository = applicationImageRepository ?? throw new ArgumentNullException(nameof(applicationImageRepository));
        Console.WriteLine($"{GetType()} instance #{GetHashCode()} created from thread: {Thread.CurrentThread.ManagedThreadId}");
    }

    public byte[] GetApplicationImage(ImageType imageType)
    {
        Console.WriteLine($"{GetType()}.{nameof(GetApplicationImage)} #{GetHashCode()}({imageType}) " +
                          $"call from thread: {Thread.CurrentThread.ManagedThreadId}");

        return _applicationImages.GetOrAdd(imageType, it => _applicationImageRepository().GetImage(it));
    }
}