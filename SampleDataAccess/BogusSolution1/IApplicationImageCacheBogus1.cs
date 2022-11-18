using SampleDataAccess.Repository;

namespace SampleDataAccess.BogusSolution1;

public interface IApplicationImageCacheBogus1
{
    byte[] GetApplicationImage(ImageType imageType);
}