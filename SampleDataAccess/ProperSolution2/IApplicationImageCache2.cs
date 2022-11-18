using SampleDataAccess.Repository;

namespace SampleDataAccess.ProperSolution2;

public interface IApplicationImageCache2
{
    byte[] GetApplicationImage(ImageType imageType);
}