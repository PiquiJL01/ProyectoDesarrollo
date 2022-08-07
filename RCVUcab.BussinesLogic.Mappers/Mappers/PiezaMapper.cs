using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class PiezaMapper
{
    public static PiezaEntity DtoToEntity(PiezaDTO pieza)
    {
        return new PiezaEntity
        {
            Description = pieza.Description,
            ID = pieza.ID,
            Name = pieza.Name,
            PiezaCotizacion = PiezaCotizacionMapper.ListDtoToEntities(pieza.PiezaCotizacion),
            PiezaMarca = PiezaMarcaMapper.ListDtoToEntities(pieza.PiezaMarca),
            VehiculoIncidenteTaller = VehiculoIncidenteTallerMapper.ListDtoToEntities(pieza.VehiculoIncidenteTaller)
        };
    }

    public static PiezaDTO EntityToDto(PiezaEntity pieza)
    {
        return new PiezaDTO
        {
            Description = pieza.Description,
            ID = pieza.ID,
            Name = pieza.Name,
            PiezaCotizacion = PiezaCotizacionMapper.ListEntityToDtos(pieza.PiezaCotizacion),
            PiezaMarca = PiezaMarcaMapper.ListEntityToDtos(pieza.PiezaMarca),
            VehiculoIncidenteTaller = VehiculoIncidenteTallerMapper.ListEntityToDtos(pieza.VehiculoIncidenteTaller)
        };
    }

    public static List<PiezaEntity> ListDtoToEntities(ICollection<PiezaDTO> piezas)
    {
        var list = new List<PiezaEntity>();
        foreach (var piezaDto in piezas)
        {
            list.Add(DtoToEntity(piezaDto));
        }

        return list;
    }

    public static List<PiezaDTO> ListEntityToDtos(ICollection<PiezaEntity> piezas)
    {
        var list = new List<PiezaDTO>();
        foreach (var piezaEntity in piezas)
        {
            list.Add(EntityToDto(piezaEntity));
        }

        return list;
    }
}