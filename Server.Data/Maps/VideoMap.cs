using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Data.Extensions;
using Server.Domain.Entities;

namespace Server.Data.Maps;

internal class VideoMap: IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.ToTable("videos");
        
        builder.HasKey(x => x.Id);
        
        builder.MapUuid(x => x.Id, "id");
            
        builder.MapEnumAsVarchar(x => x.Status, "status", 100,true);

        builder.MapTimestamp(x => x.CreatedAt, "created_at");
        
        builder.MapTimestamp(x => x.UpdatedAt, "updated_at");
            
        builder.MapVarchar(x => x.Description, "description", true);

        builder.MapNumeric(x => x.SizeInBytes,1000, 2, "size_bytes");
        
    }
}
