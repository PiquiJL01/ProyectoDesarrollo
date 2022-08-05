using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.Mappers;

public static class BrandMapper
{
    public static BrandDTO MapEntityToDto(BrandEntity entity)
    {
        var quotation = new BrandDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Providers = ProviderMapper.MapListEntityToListDto(entity.Providers)
        };
        return quotation;
    }
}