using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class PiezaMapper
{
    public static PiezaEntity DtoToEntity(PiezaDTO pieza)
    {
        if (pieza == null)
        {
            return null;
        }

        var listPiezaCotizacion = new List<PiezaCotizacionEntity>();
        foreach (var piezaCotizacion in pieza.PiezaCotizacion)
        {
            listPiezaCotizacion.Add(PiezaCotizacionMapper.DtoToEntity(piezaCotizacion));
        }
        
        var listPiezaMarca = new List<PiezaMarcaEntity>();
        foreach (var piezaMarca in pieza.PiezaMarca)
        {
            listPiezaMarca.Add(PiezaMarcaMapper.DtoToEntity(piezaMarca));
        }

        var listVehiculoIncidenteTaller = new List<VehiculoIncidenteTallerEntity>();
        foreach (var vehiculoIncidenteTaller in pieza.VehiculoIncidenteTaller)
        {
            listVehiculoIncidenteTaller.Add(VehiculoIncidenteTallerMapper.DtoToEntity(vehiculoIncidenteTaller));
        }

        return new PiezaEntity
        {
            Description = pieza.Description,
            ID = pieza.ID,
            Name = pieza.Name,
            PiezaCotizacion = listPiezaCotizacion,
            PiezaMarca = listPiezaMarca,
            VehiculoIncidenteTaller = listVehiculoIncidenteTaller
        };
    }

    public static PiezaDTO EntityToDto(PiezaEntity pieza)
    {
        if (pieza == null)
        {
            return null;
        }

        var listPiezaCotizacion = new List<PiezaCotizacionDTO>();
        foreach (var piezaCotizacion in pieza.PiezaCotizacion)
        {
            listPiezaCotizacion.Add(PiezaCotizacionMapper.EntityToDto(piezaCotizacion));
        }

        var listPiezaMarca = new List<PiezaMarcaDTO>();
        foreach (var piezaMarca in pieza.PiezaMarca)
        {
            listPiezaMarca.Add(PiezaMarcaMapper.EntityToDto(piezaMarca));
        }

        var listVehiculoIncidenteTaller = new List<VehiculoIncidenteTallerDTO>();
        foreach (var vehiculoIncidenteTaller in pieza.VehiculoIncidenteTaller)
        {
            listVehiculoIncidenteTaller.Add(VehiculoIncidenteTallerMapper.EntityToDto(vehiculoIncidenteTaller));
        }

        return new PiezaDTO
        {
            Description = pieza.Description,
            ID = pieza.ID,
            Name = pieza.Name,
            PiezaCotizacion = listPiezaCotizacion,
            PiezaMarca = listPiezaMarca,
            VehiculoIncidenteTaller = listVehiculoIncidenteTaller
        };
    }
}