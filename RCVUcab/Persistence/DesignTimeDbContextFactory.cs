using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RCVUcab.Persistence.Database;

namespace RCVUcab.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProviderDBContext>
{
    private string ConexionJoselyn = "Server=localhost;Database=bdDesarrollo;User Id=sa;Password=<Anabel47*>;";

    private string ConexionJose =
        "Server=(localdb)\\mssqllocaldb;Database=bdDesarrollo;Trusted_Connection=True;MultipleActiveResultSets=true";


    public ProviderDBContext CreateDbContext(string[]? args)
    {
        var builder = new DbContextOptionsBuilder<ProviderDBContext>();
        builder.UseSqlServer(ConexionJoselyn);
        return new ProviderDBContext(builder.Options);
    }
}
