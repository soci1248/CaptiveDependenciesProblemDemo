using SampleDataAccess.Repository;

namespace SampleDataAccess.Entities;

public class ApplicationImage
{
    public ApplicationImage(int id, ImageType imageType, byte[] imageContent)
    {
        Id = id;
        ImageContent = imageContent;
        ImageType = imageType;
    }

    public int Id { get; set; }
    public byte[] ImageContent { get; set; }
    public ImageType ImageType { get; set; }
}