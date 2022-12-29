using Server.Domain.Enums;

namespace Server.Domain.Entities;

public class Server
{
    private Server()
    {
    }

    public static Server New(
        int ipPort,
        string ipAddress,
        string name,
        string role
    ) => new Server()
    {
        Id = Guid.NewGuid(),
        IpPort = ipPort,
        IpAddress = ipAddress,
        Name = name,
        Role = role,
        Status = EStatus.NotRunning,
        CreatedAt  = DateTime.UtcNow
    };


    public Server Update(
        int ipPort,
        string ipAddress,
        string name,
        string role,
        EStatus status
    )
    {
        IpPort = ipPort;
        IpAddress = ipAddress;
        Name = name;
        Role = role;
        Status = status;
        UpdatedAt = DateTime.UtcNow;

        return this;
    }

    public Guid Id { get; private set; }
    public int IpPort { get; private set; }
    public string IpAddress { get; private set; }
    public string Name { get; private set; }
    public string Role { get; private set; }
    public EStatus Status { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    public DateTime UpdatedAt { get; private set; }
    
    public ICollection<ServerVideo> ServersVideos { get; private set; } = new List<ServerVideo>();
}