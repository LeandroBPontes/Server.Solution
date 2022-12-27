namespace Server.Domain.Entities;

public class Video
{
    private Video()
    {
    }

    public static Video New(
        string description,
        byte sizeInBytes
    ) => new Video()
    {
        Id = Guid.NewGuid(),
        Description = description,
        SizeInBytes = sizeInBytes
    };


    public Video Update(
        string description,
        byte sizeInBytes
    )
    {
        Description = description;
        SizeInBytes = sizeInBytes;

        return this;
    }

    public Guid Id { get; private set; }
    
    public string Description { get; private set; }
    
    public byte SizeInBytes { get; private set; }
  
}