using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class CotizacionMapper
{
    public static CotizacionEntity DtoToEntity(CotizacionDTO cotizacion)
    {
        return new CotizacionEntity
        {
            Id = cotizacion.Id,
            Id_Incidente = cotizacion.Id_Incidente,
            Id_Proveedor = cotizacion.Id_Proveedor,
            Id_Taller = cotizacion.Id_Taller,
            Incidente = IncidenteMapper.DtoToEntity(cotizacion.Incidente),
            MontoTotal = cotizacion.MontoTotal,
            PiezaCotizacion = PiezaCotizacionMapper.ListDtoToEntities(cotizacion.PiezaCotizacion),
            Proveedor = ProveedorMapper.DtoToEntity(cotizacion.Proveedor),
            Taller = TallerMapper.DtoToEntity(cotizacion.Taller)
        };
    }

    public static CotizacionDTO EntityToDto(CotizacionEntity cotizacion)
    {
        return new CotizacionDTO
        {
            Id = cotizacion.Id,
            Id_Incidente = cotizacion.Id_Incidente,
            Id_Proveedor = cotizacion.Id_Proveedor,
            Id_Taller = cotizacion.Id_Taller,
            Incidente = IncidenteMapper.EntityToDto(cotizacion.Incidente),
            MontoTotal = cotizacion.MontoTotal,
            PiezaCotizacion = PiezaCotizacionMapper.ListEntityToDtos(cotizacion.PiezaCotizacion),
            Proveedor = ProveedorMapper.EntityToDto(cotizacion.Proveedor),
            Taller = TallerMapper.EntityToDto(cotizacion.Taller)
        };
    }

    public static List<CotizacionEntity> ListDtoToEntities(ICollection<CotizacionDTO> cotizaciones)
    {
        var list = new List<CotizacionEntity>();
        foreach (var CotizacionEntity in cotizaciones)
        {
            list.Add(DtoToEntity(CotizacionEntity));
        }

        return list;
    }

    public static List<CotizacionDTO> ListEntityToDtos(ICollection<CotizacionEntity> cotizaciones)
    {
        var list = new List<CotizacionDTO>();
        foreach (var CotizacionEntity in cotizaciones)
        {
            list.Add(EntityToDto(CotizacionEntity));
        }

        return list;
    }
}