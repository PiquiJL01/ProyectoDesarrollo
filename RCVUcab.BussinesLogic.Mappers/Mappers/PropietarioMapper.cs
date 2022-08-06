using System.Collections.Generic;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.BussinesLogic.Mappers.Mappers;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.Mappers;

public static class PropietarioMapper
{
    public static PropietarioEntity DtoToEntity(PropietarioDTO propietario)
    {
        if (propietario == null)
        {
            return null;
        }

        var list = new List<VehiculoEntity>();
        foreach (var vehiculo in propietario.Vehiculo)
        {
            list.Add(VehiculoMapper.DtoToEntity(vehiculo));
        }

        return new PropietarioEntity
        {
            CedulaRif = propietario.CedulaRif,
            Direccion = propietario.Direccion,
            FechaNacimiento = propietario.FechaNacimiento,
            Id_Poliza = propietario.Id_Poliza,
            Poliza = PolizaMapper.DtoToEntity(propietario.Poliza),
            PrimerApellido = propietario.PrimerApellido,
            PrimerNombre = propietario.PrimerNombre,
            SegundoApellido = propietario.SegundoApellido,
            SegundoNombre = propietario.SegundoNombre,
            Vehiculo = list
        };
    }

    public static PropietarioDTO EntityToDto(PropietarioEntity propietario)
    {
        if (propietario == null)
        {
            return null;
        }

        var list = new List<VehiculoDTO>();
        foreach (var vehiculo in propietario.Vehiculo)
        {
            list.Add(VehiculoMapper.EntityToDto(vehiculo));
        }

        return new PropietarioDTO
        {
            CedulaRif = propietario.CedulaRif,
            Direccion = propietario.Direccion,
            FechaNacimiento = propietario.FechaNacimiento,
            Id_Poliza = propietario.Id_Poliza,
            Poliza = PolizaMapper.EntityToDto(propietario.Poliza),
            PrimerApellido = propietario.PrimerApellido,
            PrimerNombre = propietario.PrimerNombre,
            SegundoApellido = propietario.SegundoApellido,
            SegundoNombre = propietario.SegundoNombre,
            Vehiculo = list
        };
    }
}