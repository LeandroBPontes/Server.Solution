using Server.Domain.AppServices.Commands;
using Server.Domain.Contracts;
using Server.Domain.Contracts.UnitOfWork;
using Server.Domain.Projections;
using Server.Domain.ViewModels;

namespace Server.Domain.AppServices;

public class UpdateServerAppService : BaseAppService, IUpdateServerAppService
{
    private readonly IServerRepository _serverRepository;

    public UpdateServerAppService(IUnitOfWork uow, IServerRepository serverRepository) : base(uow)
    {
        _serverRepository = serverRepository;
    }


    public async Task<ServerVm> Update(UpdateServerCommand command)
    {
        var server = await _serverRepository.FindAsync(s => s.Id == command.Id);

        if (server is not null)

            server.Update(command.IpPort, command.IpAddress, command.Name, command.Role);

        return await CommitAsync()
            ? server.ToVm()
            : null;
    }
}

public interface IUpdateServerAppService
{
    Task<ServerVm> Update(UpdateServerCommand command);
}