using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Api._Config.Polices;
using Server.Domain.AppServices;
using Server.Domain.AppServices.Commands;
using Server.Domain.Contracts;
using Server.Domain.Enums;
using Server.Domain.Filters;
using Server.Domain.Projections;
using Server.Domain.Shared.Utils;
using Server.Domain.ViewModels;

namespace Server.Api.Controllers.Api;

[Authorize(AppPolice.Admin)]
[Route("api/server")]
public class ServerController : BaseController
{
    private readonly IServerRepository _serverRepository;

    public ServerController(IServerRepository serverRepository)
    {
        _serverRepository = serverRepository;
    }

    [HttpGet]
    public async Task<PagedList<ServerVm>> Get([FromQuery] ServerFilter filter)
    {
        var where = _serverRepository.Where(filter);

        var servers = new PagedList<ServerVm>(
            _serverRepository.ListAsNoTracking(where, filter).ToVm(),
            await _serverRepository.CountAsync(where),
            filter.PageSize
        );

        return servers;
    }

    [HttpGet("{id:guid}")]
    public async Task<ServerVm> GetById([FromRoute] Guid id)
    {
        if (id == Guid.Empty)
            return null;

        var server = await _serverRepository.FindAsyncAsNoTracking(b => b.Id == id);

        return server == null ? null : server.ToVm();
    }

    [HttpPost]
    public async Task<ServerVm> Create([FromServices] ICreateServerAppService appService,
        [FromBody] CreateServerCommand command)
    {
        return command == null
            ? null
            : await appService.Create(command);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ServerVm> Update(
        [FromServices] IUpdateServerAppService service, [FromBody] UpdateServerCommand command, [FromRoute] Guid id)
    {
        if (id == Guid.Empty) return null;

        command.Id = id;

        return await service.Update(command);
    }
    
    [HttpPut("{id:guid}/video")]
    public async Task<ServerVm> InsertVideo(
        [FromServices] IUpdateServerAppService service, [FromBody] UpdateServerCommand command, [FromRoute] Guid id)
    {
        if (id == Guid.Empty) return null;

        command.Id = id;

        return await service.Update(command);
    }

    [HttpDelete("{id:guid}")]
    public async Task<bool> Remove([FromRoute] Guid id, [FromServices] IDeleteServerAppService appService)
    {
        if (id == Guid.Empty)
            return false;

        return await appService.Delete(id);
    }
    
    [HttpGet("available/{id:guid}")]
    public async Task<bool> CheckServerAvailableById([FromRoute] Guid id)
    {
        if (id == Guid.Empty)
            return false;

        return (await _serverRepository.FindAsyncAsNoTracking(b => b.Id == id)).Status == EStatus.Running;
        
    }
}