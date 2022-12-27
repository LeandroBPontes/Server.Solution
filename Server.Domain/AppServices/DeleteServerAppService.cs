using Server.Domain.AppServices.Commands;
using Server.Domain.Contracts;
using Server.Domain.Contracts.UnitOfWork;

namespace Server.Domain.AppServices;

public class DeleteServerAppService: BaseAppService, IDeleteServerAppService
{
    private readonly IServerRepository _serverRepository;

    public DeleteServerAppService(IUnitOfWork uow, IServerRepository serverRepository) : base(uow)
    {
        _serverRepository = serverRepository;
    }


    public async Task<bool> Delete(Guid id)
    {
        var server = await _serverRepository.FindAsync(s => s.Id == id);

        if (server is not null)
            _serverRepository.Remove(server);

        return await CommitAsync();
    }
}

public interface IDeleteServerAppService
{
    Task<bool> Delete(Guid id);
}

