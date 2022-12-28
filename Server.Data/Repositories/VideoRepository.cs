using Server.Data.DataContext;
using Server.Data.Repositories.Base;
using Server.Domain.Contracts;
using Server.Domain.Entities;

namespace Server.Data.Repositories;

internal class VideoRepository: Repository<Video>, IVideoRepository
{
    public VideoRepository(DatabaseConfig context) : base(context)
    {
    }
}