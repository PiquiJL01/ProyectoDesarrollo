using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RCVUcab.DataAccess.Database;

namespace RCVUcab.DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
    {
        public DataBaseContext CreateDbContext(string[]? args)
        {
            var builder = new DbContextOptionsBuilder<DataBaseContext>();
            var connectionString = "Server=localhost;Database=bdDesarrollo;User Id=sa;Password=<Anabel47*>;";
            builder.UseSqlServer(connectionString);
            return new DataBaseContext(builder.Options);
        }
    }
}

