using Server.Domain.Shared.Utils;

namespace Server.Domain.Filters;
public class ServerFilter : Pagination
{
    public Guid? Id { get; set; }
    public int? IpPort { get; set; }
    public string IpAddress { get; set; }
    public string Name { get; set; }
  
}