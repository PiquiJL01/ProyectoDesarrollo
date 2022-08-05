using System.Collections.Generic;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.Mappers;

public class QuotationDetailMapper
{
    public static QuotationDetailEntity MapDtoToEntity(QuotationDetailDTO dto)
    {
        var quotation = new QuotationDetailEntity
        {
            Quantity = dto.Quantity,
            Price = dto.Price,
            PartId = dto.PartId,
            ProviderPartType = dto.ProviderPartType,
            ProviderPartNumber = dto.ProviderPartNumber,
            PartName = dto.PartName,
            Discount = dto.Discount,
            Observation = dto.Observation
        };
        return quotation;
    }

    public static QuotationDetailDTO MapEntityToDto(QuotationDetailEntity entity)
    {
        var quotation = new QuotationDetailDTO
        {
            Quantity = entity.Quantity,
            Price = entity.Price,
            PartId = entity.PartId,
            ProviderPartType = entity.ProviderPartType,
            ProviderPartNumber = entity.ProviderPartNumber,
            PartName = entity.PartName,
            Discount = entity.Discount,
            Observation = entity.Observation
        };
        return quotation;
    }

    public static List<QuotationDetailDTO> MapListEntityToListDto(ICollection<QuotationDetailEntity> entity)
    {
        List<QuotationDetailDTO> list = new List<QuotationDetailDTO>();
        foreach (var quotationDetail in entity)
        {
            list.Add(MapEntityToDto(quotationDetail));
        }
        return list;
    }

    public static List<QuotationDetailEntity> MapListDtoToListEntity(ICollection<QuotationDetailDTO> dto)
    {
        List<QuotationDetailEntity> list = new List<QuotationDetailEntity>();
        foreach (var quotationDetail in dto)
        {
            list.Add(MapDtoToEntity(quotationDetail));
        }
        return list;
    }
}