using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data;

public class ApplicatioContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=FacturationSchad;User ID=sa;Password=P@ssword1;MultipleActiveResultSets=True;Connect Timeout=100;Encrypt=False;");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
