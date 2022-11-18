using SampleDataAccess.Repository;

namespace SampleDataAccess.ProperSolution;

public interface IApplicationImageCacheStorage
{
    byte[] GetApplicationImage(ImageType imageType, Func<ImageType, byte[]> loaderFunc);
}