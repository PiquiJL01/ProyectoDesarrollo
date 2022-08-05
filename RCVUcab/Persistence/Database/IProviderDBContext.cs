using Microsoft.EntityFrameworkCore;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.Database;

public interface IProviderDBContext
{
    DbContext DbContext
    {
        get;
    }


    DbSet<ProviderEntity> Providers
    {
        get; set;
    }

    DbSet<BrandEntity> Brands
    {
        get; set;
    }

    DbSet<QuotationEntity> Quotation
    {
        get; set;
    }

    DbSet<QuotationDetailEntity> QuotationDetail
    {
        get; set;
    }
}