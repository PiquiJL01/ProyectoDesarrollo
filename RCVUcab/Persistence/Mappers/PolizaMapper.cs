using System.Collections.Generic;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.Mappers;

public static class PolizaMapper
{
    public static PolizaEntity DtoToEntity(PolizaDTO poliza)
    {
        if (poliza == null)
        {
            return null;
        }

        var list = new List<PropietarioEntity>();
        foreach (var propietario in poliza.Propietario)
        {
            list.Add(PropietarioMapper.DtoToEntity(propietario));
        }

        return new PolizaEntity
        {
            Administrador = UsuarioMapper.DtoToEntity(poliza.Administrador),
            ID = poliza.ID,
            Id_Admin = poliza.Id_Admin,
            Propietario = list,
            TipoPoliza = poliza.TipoPoliza
        };
    }

    public static PolizaDTO EntityToDto(PolizaEntity poliza)
    {
        if (poliza == null)
        {
            return null;
        }

        var list = new List<PropietarioDTO>();
        foreach (var propietario in poliza.Propietario)
        {
            list.Add(PropietarioMapper.EntityToDto(propietario));
        }

        return new PolizaDTO
        {
            Administrador = UsuarioMapper.entityToDto(poliza.Administrador),
            ID = poliza.ID,
            Id_Admin = poliza.Id_Admin,
            Propietario = list,
            TipoPoliza = poliza.TipoPoliza
        };
    }
}