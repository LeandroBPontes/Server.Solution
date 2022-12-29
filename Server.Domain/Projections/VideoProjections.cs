using Server.Domain.Entities;
using Server.Domain.ViewModels;

namespace Server.Domain.Projections;

public static class VideoProjections
{
    public static IQueryable<VideoVm> ToVm(this IQueryable<Video> query)
    {
        return query.Select(entity => new VideoVm
        {
            Id = entity.Id,
            Description = entity.Description,
            SizeInBytes = entity.SizeInBytes
        });

    }

    public static IEnumerable<VideoVm> ToVm(this IEnumerable<Video> query){
    
        return query.AsQueryable().ToVm();
    }

    public static VideoVm ToVm(this Video entity)
    {
        return new[] {entity}.AsQueryable().ToVm().FirstOrDefault();
    }
}