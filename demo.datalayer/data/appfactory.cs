using demo.datalayer.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class AppDbContextFactory : IDesignTimeDbContextFactory<appdbcontext>
{
    public appdbcontext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<appdbcontext>();

      
        var connectionString = "Server=.;Database=YourDbName;Trusted_Connection=True;TrustServerCertificate=True;";

        optionsBuilder.UseSqlServer(connectionString);

        return new appdbcontext(optionsBuilder.Options);
    }
}


