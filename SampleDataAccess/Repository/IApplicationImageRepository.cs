namespace SampleDataAccess.Repository;

public interface IApplicationImageRepository
{
    byte[] GetImage(ImageType imageType);
}