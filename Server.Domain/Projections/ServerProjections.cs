using Server.Domain.ViewModels;

namespace Server.Domain.Projections;


public static class ServerProjection
{
    public static IQueryable<ServerVm> ToVm(this IQueryable<Entities.Server> query)
    {
        return query.Select(entity => new ServerVm
        {
            Id = entity.Id,
            IpPort = entity.IpPort,
            IpAddress = entity.IpAddress,
            Name = entity.Name
        });

    }

    public static IEnumerable<ServerVm> ToVm(this IEnumerable<Entities.Server> query)
    {
        return query.AsQueryable().ToVm();
    }

    public static ServerVm ToVm(this Entities.Server entity)
    {
        return new[] {entity}.AsQueryable().ToVm().FirstOrDefault();
    }
}