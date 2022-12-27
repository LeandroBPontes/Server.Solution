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
        Role = role
    };


    public Server Update(
        int ipPort,
        string ipAddress,
        string name,
        string role
    )
    {
        IpPort = ipPort;
        IpAddress = ipAddress;
        Name = name;
        Role = Role;

        return this;
    }

    public Guid Id { get; private set; }
    public int IpPort { get; private set; }
    public string IpAddress { get; private set; }
    public string Name { get; private set; }
    public string Role { get; private set; }
}