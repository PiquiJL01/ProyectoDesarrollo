using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class PiezaCotizacionMapper
{
    public static PiezaCotizacionEntity DtoToEntity(PiezaCotizacionDTO piezaCotizacion)
    {
        return new PiezaCotizacionEntity
        {
            Cantidad = 0, //piezaCotizacion.Cantidad,
            Cotizacion = CotizacionMapper.DtoToEntity(piezaCotizacion.Cotizacion),
            Descuento = "", //piezaCotizacion.Descuento
            ID = piezaCotizacion.ID,
            Id_Cotizacion = piezaCotizacion.Id_Cotizacion,
            Id_Pieza = piezaCotizacion.Id_Pieza,
            Pieza = PiezaMapper.DtoToEntity(piezaCotizacion.Pieza),
            PiezaEstatus = "", //piezaCotizacion.Pieza
            Precio = piezaCotizacion.Precio,
            TiempoDeEntrega = "" //piezaCotizacion.TiempoEntrega
        };
    }

    public static PiezaCotizacionDTO EntityToDto(PiezaCotizacionEntity piezaCotizacion)
    {
        return new PiezaCotizacionDTO
        {
            Cotizacion = CotizacionMapper.EntityToDto(piezaCotizacion.Cotizacion),
            ID = piezaCotizacion.ID,
            Id_Cotizacion = piezaCotizacion.Id_Cotizacion,
            Id_Pieza = piezaCotizacion.Id_Pieza,
            Pieza = PiezaMapper.EntityToDto(piezaCotizacion.Pieza),
            Precio = piezaCotizacion.Precio
        };
    }

    public static List<PiezaCotizacionEntity> ListDtoToEntities(ICollection<PiezaCotizacionDTO> piezaCotizaciones)
    {
        var list = new List<PiezaCotizacionEntity>();
        foreach (var piezaCotizacionDto in piezaCotizaciones)
        {
            list.Add(DtoToEntity(piezaCotizacionDto));
        }

        return list;
    }

    public static List<PiezaCotizacionDTO> ListEntityToDtos(ICollection<PiezaCotizacionEntity> piezaCotizaciones)
    {
        var list = new List<PiezaCotizacionDTO>();
        foreach (var piezaCotizacionEntity in piezaCotizaciones)
        {
            list.Add(EntityToDto(piezaCotizacionEntity));
        }

        return list;
    }
}