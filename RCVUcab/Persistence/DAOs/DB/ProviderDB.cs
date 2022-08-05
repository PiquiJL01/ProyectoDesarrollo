using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.Database;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.DAOs.DB;

public class ProviderDB : IProviderDB
{
    private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
    private IProviderDBContext _context = desing.CreateDbContext(null);

    public BrandDTO GetProvidersByBrand(string brand)
    {
        try
        {
            var data = _context.Brands
               .Include(b => b.Providers)
               .Where(b => b.Name == brand.ToUpper())
               .Select(b => new BrandDTO
               {
                   Id = b.Id,
                   Name = b.Name,
                   Providers = b.Providers.Select(p => new ProviderDTO
                   {
                       Id = p.Id,
                       FullName = p.Name + " " + p.LastName,
                       Address = p.Address
                   }).ToList()
               });

            return data.Single();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public QuotationDTO CreateProviderQuotation(QuotationEntity quotation)
    {
        try
        {
            _context.Quotation.Add(quotation);
            _context.DbContext.SaveChanges();

            var data = _context.Quotation
            .Include(q => q.Quotations)
            .Where(x => x.InvitationId == quotation.InvitationId && x.ProviderId == quotation.ProviderId)
            .Select(p => new QuotationDTO
            {
                InvitationId = p.InvitationId,
                ProviderId = p.ProviderId,
                QuotationNumber = p.QuotationNumber,
                WorkshopAddress = p.WorkshopAddress,
                WorkshopName = p.WorkshopName,
                WorkshopPhone = p.WorkshopPhone,
                WorkshopProviderId = p.WorkshopProviderId,
                Observation = p.Observation,
                Parts = p.Quotations.Select(u => new QuotationDetailDTO
                {
                    Id = u.Id,
                    Quantity = u.Quantity,
                    Price = u.Price,
                    PartId = u.PartId,
                    ProviderPartType = u.ProviderPartType,
                    ProviderPartNumber = u.ProviderPartNumber,
                    PartName = u.PartName,
                    Discount = u.Discount,
                    Observation = u.Observation
                }).ToList()
            });

            return data.First();
        }
        catch (Exception)
        {
            throw;
        }
    }
}