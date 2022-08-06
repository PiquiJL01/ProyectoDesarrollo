using System.Collections.Generic;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.DAOs.Implementations;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.Mappers;

public static class CotizacionMapper
{
    public static CotizacionEntity DtoToEntity(CotizacionDTO cotizacion)
    {
        if (cotizacion == null)
        {
            return null;
        }

        var list = new List<PiezaCotizacionEntity>();
        foreach (var piezaCotizacionEntity in cotizacion.PiezaCotizacion)
        {
            list.Add(PiezaCotizacionMapper.DtoToEntity(piezaCotizacionEntity));
        }

        return new CotizacionEntity
        {
            Id = cotizacion.Id,
            Id_Incidente = cotizacion.Id_Incidente,
            Id_Proveedor = cotizacion.Id_Proveedor,
            Id_Taller = cotizacion.Id_Taller,
            Incidente = IncidenteMapper.DtoToEntity(cotizacion.Incidente),
            MontoTotal = cotizacion.MontoTotal,
            PiezaCotizacion = list,
            Proveedor = ProveedorMapper.DtoToEntity(cotizacion.Proveedor),
            Taller = TallerMapper.DtoToEntity(cotizacion.Taller)
        };
    }

    public static CotizacionDTO EntityToDto(CotizacionEntity cotizacion)
    {
        if (cotizacion == null)
        {
            return null;
        }

        var list = new List<PiezaCotizacionDTO>();
        foreach (var piezaCotizacionEntity in cotizacion.PiezaCotizacion)
        {
            list.Add(PiezaCotizacionMapper.EntityToDto(piezaCotizacionEntity));
        }

        return new CotizacionDTO
        {
            Id = cotizacion.Id,
            Id_Incidente = cotizacion.Id_Incidente,
            Id_Proveedor = cotizacion.Id_Proveedor,
            Id_Taller = cotizacion.Id_Taller,
            Incidente = IncidenteMapper.EntityToDto(cotizacion.Incidente),
            MontoTotal = cotizacion.MontoTotal,
            PiezaCotizacion = list,
            Proveedor = ProveedorMapper.EntityToDto(cotizacion.Proveedor),
            Taller = TallerMapper.EntityToDto(cotizacion.Taller)
        };
    }
}