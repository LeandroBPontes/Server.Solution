using Server.Domain.AppServices.Commands;
using Server.Domain.Contracts;
using Server.Domain.Contracts.UnitOfWork;
using Server.Domain.Entities;
using Server.Domain.Projections;
using Server.Domain.ViewModels;

namespace Server.Domain.AppServices;

public class CreateServerAppService : BaseAppService, ICreateServerAppService
{
    private readonly IServerRepository _serverRepository;
    private readonly IServerVideoRepository _videoServerRepository;
    private readonly IVideoRepository _videoRepository;

    public CreateServerAppService(IUnitOfWork uow, IServerRepository serverRepository,
        IServerVideoRepository videoServerRepository, IVideoRepository videoRepository) : base(uow)
    {
        _serverRepository = serverRepository;
        _videoServerRepository = videoServerRepository;
        _videoRepository = videoRepository;
    }


    public async Task<ServerVm> Create(CreateServerCommand command)
    {
        var server = Entities.Server.New(command.IpPort, command.IpAddress, command.Name, command.Role);

        await _serverRepository.AddAsync(server);

        return await CommitAsync()
            ? server.ToVm()
            : null;
    }

    public async Task<VideoVm> AddVideo(AddVideoServerCommand command)
    {
        //adiciona o video
        var video = Video.New(command.Description, command.SizeInBytes);

        if (video is not null)
        {
            await _videoRepository.AddAsync(video);

            //atualiza a referencia
            var serverVideo = ServerVideo.New(video.Id, command.ServerId);
            await _videoServerRepository.AddAsync(serverVideo);
        }

        return await CommitAsync()
            ? video.ToVm()
            : null;
    }
}

public interface ICreateServerAppService
{
    Task<ServerVm> Create(CreateServerCommand command);
    Task<VideoVm> AddVideo(AddVideoServerCommand command);
}