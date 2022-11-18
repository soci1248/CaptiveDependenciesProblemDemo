using SampleDataAccess.Repository;

namespace SampleDataAccess.BogusSolution2;

public interface IApplicationImageCacheBogus2
{
    byte[] GetApplicationImage(ImageType imageType);
}