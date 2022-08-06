using System.Collections.Generic;
using System.ComponentModel;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.Mappers;

public static class IncidenteMapper
{
    public static IncidenteEntity DtoToEntity(IncidenteDTO incidente)
    {
        if (incidente == null)
        {
            return null;
        }

        var listCotizacion = new List<CotizacionEntity>();
        foreach (var cotizacionDto in incidente.Cotizacion)
        {
            listCotizacion.Add(CotizacionMapper.DtoToEntity(cotizacionDto));
        }

        var listVehiculoIncidenteTaller = new List<VehiculoIncidenteTallerEntity>();
        foreach (var vehiculoIncidenteTaller in incidente.VehiculoIncidenteTaller)
        {
            listVehiculoIncidenteTaller.Add(VehiculoIncidenteTallerMapper.DtoToEntity(vehiculoIncidenteTaller));
        }

        return new IncidenteEntity
        {
            Administrador = UsuarioMapper.DtoToEntity(incidente.Administrador),
            Cotizacion = listCotizacion,
            Fecha = incidente.Fecha,
            ID = incidente.ID,
            Id_Administrador = incidente.Id_Administrador,
            Id_Perito = incidente.Id_Perito,
            Perito = UsuarioMapper.DtoToEntity(incidente.Perito),
            Ubicacion = incidente.Ubicacion,
            VehiculoIncidenteTaller = listVehiculoIncidenteTaller
        };
    }

    public static IncidenteDTO EntityToDto(IncidenteEntity incidente)
    {
        if (incidente == null)
        {
            return null;
        }

        var listCotizacion = new List<CotizacionDTO>();
        foreach (var cotizacion in incidente.Cotizacion)
        {
            listCotizacion.Add(CotizacionMapper.EntityToDto(cotizacion));
        }

        var listVehiculoIncidenteTaller = new List<VehiculoIncidenteTallerDTO>();
        foreach (var vehiculoIncidenteTaller in incidente.VehiculoIncidenteTaller)
        {
            listVehiculoIncidenteTaller.Add(VehiculoIncidenteTallerMapper.EntityToDto(vehiculoIncidenteTaller));
        }

        return new IncidenteDTO
        {
            Administrador = UsuarioMapper.EntityToDto(incidente.Administrador),
            Cotizacion = listCotizacion,
            Fecha = incidente.Fecha,
            ID = incidente.ID,
            Id_Administrador = incidente.Id_Administrador,
            Id_Perito = incidente.Id_Perito,
            Perito = UsuarioMapper.EntityToDto(incidente.Perito),
            Ubicacion = incidente.Ubicacion,
            VehiculoIncidenteTaller = listVehiculoIncidenteTaller
        };
    }
}