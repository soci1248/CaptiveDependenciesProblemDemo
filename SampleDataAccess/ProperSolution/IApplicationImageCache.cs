using SampleDataAccess.Repository;

namespace SampleDataAccess.ProperSolution;

public interface IApplicationImageCache
{
    byte[] GetApplicationImage(ImageType imageType);
}