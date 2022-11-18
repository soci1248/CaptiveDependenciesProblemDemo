using System.Collections.Concurrent;
using SampleDataAccess.Repository;

namespace SampleDataAccess.ProperSolution;

internal sealed class ApplicationImageCacheStorage : IApplicationImageCacheStorage
{
    private readonly ConcurrentDictionary<ImageType, byte[]> _applicationImages = new();
    
    public ApplicationImageCacheStorage()
    {
            Console.WriteLine($"{GetType()} instance #{GetHashCode()} created from thread: {Thread.CurrentThread.ManagedThreadId}");
    }

    public byte[] GetApplicationImage(ImageType imageType, Func<ImageType, byte[]> loaderFunc)
    {
        if (loaderFunc == null) throw new ArgumentNullException(nameof(loaderFunc));

        Console.WriteLine($"{GetType()}.{nameof(GetApplicationImage)} #{GetHashCode()}({imageType}) " +
                          $"call from thread: {Thread.CurrentThread.ManagedThreadId}");

        if (loaderFunc == null) throw new ArgumentNullException(nameof(loaderFunc));
        return _applicationImages.GetOrAdd(imageType, loaderFunc);
    }
}