using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Data.Extensions;
using Server.Domain.Entities;

namespace Server.Data.Maps;

internal class ServerVideoMap: IEntityTypeConfiguration<ServerVideo>
{
    public void Configure(EntityTypeBuilder<ServerVideo> builder)
    {
        builder.ToTable("servers_videos");
        
        builder.HasKey(x => x.Id);

        builder.MapUuid(x => x.Id, "id");

        builder.MapUuid(x => x.VideoId, "video_id");

        builder.MapUuid(x => x.ServerId, "server_id");

        builder.HasOne(x => x.Server)
            .WithMany(x => x.ServersVideos)
            .HasForeignKey(x => x.ServerId)
            .OnDelete(DeleteBehavior.Cascade);

    
        builder.HasOne(x => x.Video)
            .WithMany(x => x.ServersVideos)
            .HasForeignKey(x => x.VideoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}