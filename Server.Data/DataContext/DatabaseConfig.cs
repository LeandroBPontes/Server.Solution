using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Server.Data.DataContext;

public class DatabaseConfig : IdentityDbContext 
{

    public DatabaseConfig(DbContextOptions<DatabaseConfig> options) : base(options) {

    }
    public DatabaseConfig() {

    }

    public DbSet<Domain.Entities.Server> Servers { get; set; }
    
    
}

