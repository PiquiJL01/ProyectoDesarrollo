using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RCVUcab.DataAccess.Database;

namespace RCVUcab.DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
    {
        private string ConexionJoselyn = "Server=localhost;Database=bdDesarrollo;User Id=sa;Password=<Anabel47*>;";

        private string ConexionJose =
            "Server=(localdb)\\mssqllocaldb;Database=bdDesarrollo;Trusted_Connection=True;MultipleActiveResultSets=true";

        public DataBaseContext CreateDbContext(string[]? args)
        {
            var builder = new DbContextOptionsBuilder<DataBaseContext>();
            builder.UseSqlServer(ConexionJoselyn);
            return new DataBaseContext(builder.Options);
        }
    }
}

