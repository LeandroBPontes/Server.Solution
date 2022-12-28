using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Api._Config.Polices;
using Server.Domain.Contracts;
using Server.Domain.Enums;
using Server.Domain.Filters;
using Server.Domain.Projections;
using Server.Domain.Shared.Utils;
using Server.Domain.ViewModels;

namespace Server.Api.Controllers.Api;

[Authorize(AppPolice.Admin)]
[Microsoft.AspNetCore.Components.Route("api/recycler")]
public class RecyclerController : BaseController
{
    private readonly IServerRepository _serverRepository;

    public RecyclerController(IServerRepository serverRepository)
    {
        _serverRepository = serverRepository;
    }

    [HttpGet("proccess/{days:int}")]
    public Task<List<ServerVm>> CheckServerAvailableById([FromRoute] int days)
    {
        var where = _serverRepository.ForDays(days);

        return Task.FromResult(_serverRepository.ListAsNoTracking(where).ToVm().ToList());
    }

    [HttpGet("available/{id:guid}")]
    public async Task<bool> CheckServerAvailableById([FromRoute] Guid id)
    {
        if (id == Guid.Empty)
            return false;

        return (await _serverRepository.FindAsyncAsNoTracking(b => b.Id == id)).Status == EStatus.Running;
    }
}