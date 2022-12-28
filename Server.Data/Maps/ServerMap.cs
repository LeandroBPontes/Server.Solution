using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Data.Extensions;


namespace Server.Data.Maps;

internal class ServerMap : IEntityTypeConfiguration<Domain.Entities.Server>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Server> builder)
    {
        builder.ToTable("servers");
        
        builder.HasKey(x => x.Id);
        
        builder.MapUuid(x => x.Id, "id");
            
        builder.MapEnumAsVarchar(x => x.Status, "status", 100,true);

        builder.MapTimestamp(x => x.CreatedAt, "created_at");
        
        builder.MapTimestamp(x => x.UpdatedAt, "updated_at");
            
        builder.MapVarchar(x => x.Name, "name", true);
        
        builder.MapVarchar(x => x.Role, "role", true);
        
        builder.MapVarchar(x => x.IpAddress, "name", true);
        
        builder.MapInt(x => x.IpPort, "ip_port");
        
    }
}
