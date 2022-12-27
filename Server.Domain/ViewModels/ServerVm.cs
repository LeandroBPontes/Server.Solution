namespace Server.Domain.ViewModels;

public class ServerVm
{
    public Guid Id { get; set; }
    public int IpPort { get; set; }
    public string IpAddress { get; set; }
    public string Name { get; set; }
}