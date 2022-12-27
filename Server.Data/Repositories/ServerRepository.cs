using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Server.Data.DataContext;
using Server.Data.Repositories.Base;
using Server.Domain.Contracts;
using Server.Domain.Filters;
using Server.Domain.Shared.Predicates;

namespace Server.Data.Repositories;
public class ServerRepository : Repository<Domain.Entities.Server>, IServerRepository
{
    public ServerRepository(DatabaseConfig context) : base(context)
    {
    }

    public Expression<Func<Domain.Entities.Server, bool>> Where(ServerFilter filter)
    {
        
        //FILTRAGEM
        
        var predicate =
            PredicateBuilder.True<Domain.Entities.Server>();
            
        predicate = filter.Id.HasValue
            ? predicate.And(x => x.Id == filter.Id)
            : predicate;

        predicate = string.IsNullOrEmpty(filter.Name) ?
            predicate :
            predicate.And(r => EF.Functions.Like(r.Name,  $"%{filter.Name}%"));
        
        predicate = filter.IpPort.HasValue
            ? predicate.And(x => x.IpPort == filter.IpPort)
            : predicate;
        
        predicate = string.IsNullOrEmpty(filter.IpAddress) ?
            predicate :
            predicate.And(r => EF.Functions.Like(r.IpAddress,  $"%{filter.IpAddress}%"));
        
        return predicate;
    }
    
    public Expression<Func<Domain.Entities.Server, bool>> ForDays(int days)
    {
        
        //FILTRAGEM POR DIAS
        
        var predicate =
            PredicateBuilder.True<Domain.Entities.Server>();
            
        predicate = days != null
            ? predicate.And(x => x.CreatedAt >=
                                 DateTime.Now.AddDays(-days))
            : predicate;
        
        
        return predicate;
    }
}