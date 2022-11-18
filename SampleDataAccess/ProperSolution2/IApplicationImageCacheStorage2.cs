using SampleDataAccess.Repository;

namespace SampleDataAccess.ProperSolution2;

public interface IApplicationImageCacheStorage2
{
    byte[] GetApplicationImage(ImageType imageType, Func<ImageType, Lazy<byte[]>> loaderFunc);
}