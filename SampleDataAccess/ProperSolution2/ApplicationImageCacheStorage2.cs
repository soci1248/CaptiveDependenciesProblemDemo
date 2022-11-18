using System.Collections.Concurrent;
using SampleDataAccess.Repository;

namespace SampleDataAccess.ProperSolution2;

internal sealed class ApplicationImageCacheStorage2 : IApplicationImageCacheStorage2
{
    private readonly ConcurrentDictionary<ImageType, Lazy<byte[]>> _applicationImages = new();
    
    public ApplicationImageCacheStorage2()
    {
            Console.WriteLine($"{GetType()} instance #{GetHashCode()} created from thread: {Thread.CurrentThread.ManagedThreadId}");
    }

    public byte[] GetApplicationImage(ImageType imageType, Func<ImageType, Lazy<byte[]>> loaderFunc)
    {
        if (loaderFunc == null) throw new ArgumentNullException(nameof(loaderFunc));

        Console.WriteLine($"{GetType()}.{nameof(GetApplicationImage)} #{GetHashCode()}({imageType}) " +
                          $"call from thread: {Thread.CurrentThread.ManagedThreadId}");

        if (loaderFunc == null) throw new ArgumentNullException(nameof(loaderFunc));
        return _applicationImages.GetOrAdd(imageType, loaderFunc).Value;
    }
}