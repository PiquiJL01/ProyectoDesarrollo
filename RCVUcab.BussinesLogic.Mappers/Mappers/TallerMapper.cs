using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class TallerMapper
{
    public static TallerEntity DtoToEntity(TallerDTO taller)
    {
        if (taller == null)
        {
            return null;
        }

        var listCotizacion = new List<CotizacionEntity>();
        foreach (var cotizacion in taller.CotizacionT)
        {
            listCotizacion.Add(CotizacionMapper.DtoToEntity(cotizacion));
        }

        var listProveedorMarca = new List<ProveedorMarcaEntity>();
        foreach (var proveedorMarca in taller.ProveedorMarca)
        {
            listProveedorMarca.Add(ProveedorMarcaMapper.DtoToEntity(proveedorMarca));
        }

        var listVehiculoIncidentetaller = new List<VehiculoIncidenteTallerEntity>();
        foreach (var vehiculoIncidenteTaller in taller.VehiculoIncidenteTaller)
        {
            listVehiculoIncidentetaller.Add(VehiculoIncidenteTallerMapper.DtoToEntity(vehiculoIncidenteTaller));
        }

        return new TallerEntity
        {
            Address = taller.Address,
            CotizacionT = listCotizacion,
            ID = taller.ID,
            Name = taller.Name,
            PhoneNumber = taller.PhoneNumber,
            Proveedor = ProveedorMapper.DtoToEntity(taller.Proveedor),
            ProveedorMarca = listProveedorMarca,
            VehiculoIncidenteTaller = listVehiculoIncidentetaller
        };
    }

    public static TallerDTO EntityToDto(TallerEntity taller)
    {
        if (taller == null)
        {
            return null;
        }

        var listCotizacion = new List<CotizacionDTO>();
        foreach (var cotizacion in taller.CotizacionT)
        {
            listCotizacion.Add(CotizacionMapper.EntityToDto(cotizacion));
        }

        var listProveedorMarca = new List<ProveedorMarcaDTO>();
        foreach (var proveedorMarca in taller.ProveedorMarca)
        {
            listProveedorMarca.Add(ProveedorMarcaMapper.EntityToDto(proveedorMarca));
        }

        var listVehiculoIncidentetaller = new List<VehiculoIncidenteTallerDTO>();
        foreach (var vehiculoIncidenteTaller in taller.VehiculoIncidenteTaller)
        {
            listVehiculoIncidentetaller.Add(VehiculoIncidenteTallerMapper.EntityToDto(vehiculoIncidenteTaller));
        }

        return new TallerDTO
        {
            Address = taller.Address,
            CotizacionT = listCotizacion,
            ID = taller.ID,
            Name = taller.Name,
            PhoneNumber = taller.PhoneNumber,
            Proveedor = ProveedorMapper.EntityToDto(taller.Proveedor),
            ProveedorMarca = listProveedorMarca,
            VehiculoIncidenteTaller = listVehiculoIncidentetaller
        };
    }
}