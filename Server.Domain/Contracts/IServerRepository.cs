using System.Linq.Expressions;
using Server.Domain.Filters;

namespace Server.Domain.Contracts;

public interface IServerRepository: IRepository<Entities.Server>
{
    Expression<Func<Entities.Server, bool>> Where(ServerFilter filter);
}
