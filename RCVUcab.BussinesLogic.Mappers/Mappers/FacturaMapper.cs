using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class FacturaMapper
{
    public static FacturaEntity DtoToEntity(FacturaDTO factura)
    {
        return new FacturaEntity
        {
            ID = factura.ID,
            //ID_OrdenDeCompra = OrdenDeCompraMapper.DtoToEntity(factura.ID_OrdenDeCompra)
        };
    }

    public static FacturaDTO EntityToDto(FacturaEntity factura)
    {
        return new FacturaDTO
        {
            ID = factura.ID,
            //ID_OrdenDeCompra = OrdenDeCompraMapper.EntityToDto(factura.ID_OrdenDeCompra)
        };
    }

    public static List<FacturaEntity> ListDtoToEntities(ICollection<FacturaDTO> facturas)
    {
        var list = new List<FacturaEntity>();
        foreach (var facturaDto in facturas)
        {
            list.Add(DtoToEntity(facturaDto));
        }
        return list;
    }

    public static List<FacturaDTO> ListentityToDtos(ICollection<FacturaEntity> facturas)
    {
        var list = new List<FacturaDTO>();
        foreach (var facturaEntity in facturas)
        {
            list.Add(EntityToDto(facturaEntity));
        }

        return list;
    }
}