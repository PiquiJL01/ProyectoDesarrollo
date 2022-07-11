using Microsoft.EntityFrameworkCore;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.Database
{
    public interface IRCVDbContext
    {
        DbContext DbContext
        {
            get;
        }

        DbSet<ProviderEntityEntity> Providers
        {
            get; set;
        }

        DbSet<BrandEntity> Brands
        {
            get; set;
        }
    }
}
