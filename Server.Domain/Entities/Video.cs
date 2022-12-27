using Server.Domain.Enums;

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
        SizeInBytes = sizeInBytes,
        CreatedAt = DateTime.UtcNow,
        Status = EStatus.NotRunning
    };


    public Video Update(
        string description,
        byte sizeInBytes,
        EStatus status
    )
    {
        Description = description;
        SizeInBytes = sizeInBytes;
        UpdatedAt = DateTime.UtcNow;
        Status = status;

        return this;
    }

    public Guid Id { get; private set; }

    public string Description { get; private set; }

    public byte SizeInBytes { get; private set; }
    
    public EStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    public DateTime UpdatedAt { get; private set; }
}