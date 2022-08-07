using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class PolizaMapper
{
    public static PolizaEntity DtoToEntity(PolizaDTO poliza)
    {
        return new PolizaEntity
        {
            //Administrador = UsuarioMapper.DtoToEntity(poliza.Administrador),
            ID = poliza.ID,
            Id_Admin = poliza.Id_Admin,
            //Propietario = PropietarioMapper.ListDtoToEntities(poliza.Propietario),
            TipoPoliza = poliza.TipoPoliza
        };
    }

    public static PolizaDTO EntityToDto(PolizaEntity poliza)
    {
        return new PolizaDTO
        {
            //Administrador = UsuarioMapper.EntityToDto(poliza.Administrador),
            ID = poliza.ID,
            Id_Admin = poliza.Id_Admin,
            //Propietario = PropietarioMapper.ListEntityToDtos(poliza.Propietario),
            TipoPoliza = poliza.TipoPoliza
        };
    }

    public static List<PolizaEntity> ListDtoToEntities(ICollection<PolizaDTO> polizas)
    {
        var list = new List<PolizaEntity>();
        foreach (var polizaDto in polizas)
        {
            list.Add(DtoToEntity(polizaDto));
        }

        return list;
    }

    public static List<PolizaDTO> ListEntityToDtos(ICollection<PolizaEntity> polizas)
    {
        var list = new List<PolizaDTO>();
        foreach (var polizaEntity in polizas)
        {
            list.Add(EntityToDto(polizaEntity));
        }

        return list;
    }
}