using System.Collections.Generic;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.Mappers;

public static class ProviderMapper
{
    public static ProviderEntity MapDtoToEntity(ProviderDTO dto)
    {
        var provider = new ProviderEntity
        {
            Name = dto.FullName.Split(" ")[0],
            LastName = dto.FullName.Split(" ")[1],
            Address = dto.Address
        };
        return provider;
    }



    public static ProviderDTO MapEntityToDto(ProviderEntity entity)
    {
        var provider = new ProviderDTO
        {
            Id = entity.Id,
            FullName = entity.Name + " " + entity.LastName,
            Address = entity.Address
        };
        return provider;
    }

    public static List<ProviderDTO> MapListEntityToListDto(ICollection<ProviderEntity>? providers)
    {
        List<ProviderDTO> list = new List<ProviderDTO>();
        foreach (var provider in providers)
        {
            list.Add(MapEntityToDto(provider));
        }
        return list;
    }
}