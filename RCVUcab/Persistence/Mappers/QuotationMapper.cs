using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.Mappers;

public class QuotationMapper
{
    public static QuotationEntity MapDtoToEntity(QuotationDTO dto)
    {
        var quotation = new QuotationEntity
        {
            QuotationNumber = dto.QuotationNumber,
            ProviderId = dto.ProviderId,
            WorkshopPhone = dto.WorkshopPhone,
            WorkshopAddress = dto.WorkshopAddress,
            WorkshopName = dto.WorkshopName,
            WorkshopProviderId = dto.WorkshopProviderId,
            Observation = dto.Observation,
            SellerName = dto.SellerName,
            InvitationId = dto.InvitationId,
            Quotations = QuotationDetailMapper.MapListDtoToListEntity(dto.Parts)
        };
        return quotation;
    }

    public static QuotationDTO MapEntityToDto(QuotationEntity entity)
    {
        var quotation = new QuotationDTO
        {
            QuotationNumber = entity.QuotationNumber,
            ProviderId = entity.ProviderId,
            WorkshopPhone = entity.WorkshopPhone,
            WorkshopAddress = entity.WorkshopAddress,
            WorkshopName = entity.WorkshopName,
            WorkshopProviderId = entity.WorkshopProviderId,
            Observation = entity.Observation,
            SellerName = entity.SellerName,
            InvitationId = entity.InvitationId,
            Parts = QuotationDetailMapper.MapListEntityToListDto(entity.Quotations)
        };
        return quotation;
    }
}