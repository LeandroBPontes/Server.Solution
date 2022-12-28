using Server.Data.DataContext;
using Server.Data.Repositories.Base;
using Server.Domain.Contracts;
using Server.Domain.Entities;

namespace Server.Data.Repositories;

internal class ServerVideoRepository: Repository<ServerVideo>, IServerVideoRepository
{
    public ServerVideoRepository(DatabaseConfig context) : base(context)
    {
    }
}