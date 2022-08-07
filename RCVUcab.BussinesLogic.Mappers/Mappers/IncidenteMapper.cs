using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class IncidenteMapper
{
    public static IncidenteEntity DtoToEntity(IncidenteDTO incidente)
    {
        return new IncidenteEntity
        {
            Administrador = UsuarioMapper.DtoToEntity(incidente.Administrador),
            Cotizacion = CotizacionMapper.ListDtoToEntities(incidente.Cotizacion),
            Fecha = incidente.Fecha,
            ID = incidente.ID,
            Id_Administrador = incidente.Id_Administrador,
            Id_Perito = incidente.Id_Perito,
            Perito = UsuarioMapper.DtoToEntity(incidente.Perito),
            Ubicacion = incidente.Ubicacion,
            VehiculoIncidenteTaller = VehiculoIncidenteTallerMapper.ListDtoToEntities(incidente.VehiculoIncidenteTaller)
        };
    }

    public static IncidenteDTO EntityToDto(IncidenteEntity incidente)
    {
        return new IncidenteDTO
        {
            Administrador = UsuarioMapper.EntityToDto(incidente.Administrador),
            Cotizacion = CotizacionMapper.ListEntityToDtos(incidente.Cotizacion),
            Fecha = incidente.Fecha,
            ID = incidente.ID,
            Id_Administrador = incidente.Id_Administrador,
            Id_Perito = incidente.Id_Perito,
            Perito = UsuarioMapper.EntityToDto(incidente.Perito),
            Ubicacion = incidente.Ubicacion,
            VehiculoIncidenteTaller = VehiculoIncidenteTallerMapper.ListEntityToDtos(incidente.VehiculoIncidenteTaller)
        };
    }

    public static List<IncidenteEntity> ListDtoToEntities(ICollection<IncidenteDTO> incidentes)
    {
        var list = new List<IncidenteEntity>();
        foreach (var incidenteDto in incidentes)
        {
            list.Add(DtoToEntity(incidenteDto));
        }
        return list;
    }

    public static List<IncidenteDTO> ListEntityToDtos(ICollection<IncidenteEntity> incidentes)
    {
        var list = new List<IncidenteDTO>();
        foreach (var incidenteEntity in incidentes)
        {
            list.Add(EntityToDto(incidenteEntity));
        }

        return list;
    }
}