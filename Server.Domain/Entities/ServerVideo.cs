namespace Server.Domain.Entities;

public class ServerVideo
{
    public Guid Id { get; private set; }

    public Guid VideoId { get; private set; }
    
    public Video Video{ get; private set; }

    public Guid ServerId { get; private set; }
    
    public Server Server{ get; private set; }
    
    public static ServerVideo New(
        Guid videoId,
        Guid serverId
    ) => new ServerVideo()
    {
        Id = Guid.NewGuid(),
        VideoId = videoId,
        ServerId = serverId
    };
    
}