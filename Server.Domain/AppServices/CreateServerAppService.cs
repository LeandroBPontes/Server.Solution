using Server.Domain.AppServices.Commands;
using Server.Domain.Contracts;
using Server.Domain.Contracts.UnitOfWork;
using Server.Domain.Projections;
using Server.Domain.ViewModels;

namespace Server.Domain.AppServices;

public class CreateServerAppService : BaseAppService, ICreateServerAppService
{
   
    private readonly IServerRepository _serverRepository;
        
    public CreateServerAppService(IUnitOfWork uow, IServerRepository serverRepository) : base(uow)
    {
        _serverRepository = serverRepository;
    }
    
        
    public async Task<ServerVm> Create(CreateServerCommand command)
    {
        
        var server = Entities.Server.New(command.IpPort, command.IpAddress, command.Name, command.Role);

        await _serverRepository.AddAsync(server);

        return await CommitAsync()
            ? server.ToVm()
            : null;
    }
}

public interface ICreateServerAppService
{
    Task<ServerVm> Create(CreateServerCommand command);
}
