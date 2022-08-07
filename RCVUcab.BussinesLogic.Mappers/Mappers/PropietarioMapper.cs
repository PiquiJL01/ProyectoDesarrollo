using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class PropietarioMapper
{
    public static PropietarioEntity DtoToEntity(PropietarioDTO propietario)
    {
        return new PropietarioEntity
        {
            CedulaRif = propietario.CedulaRif,
            Direccion = propietario.Direccion,
            FechaNacimiento = propietario.FechaNacimiento,
            Id_Poliza = propietario.Id_Poliza,
            //Poliza = PolizaMapper.DtoToEntity(propietario.Poliza),
            PrimerApellido = propietario.PrimerApellido,
            PrimerNombre = propietario.PrimerNombre,
            SegundoApellido = propietario.SegundoApellido,
            SegundoNombre = propietario.SegundoNombre,
            //Vehiculo = VehiculoMapper.ListDtoToEntities(propietario.Vehiculo)
        };
    }

    public static PropietarioDTO EntityToDto(PropietarioEntity propietario)
    {
        return new PropietarioDTO
        {
            CedulaRif = propietario.CedulaRif,
            Direccion = propietario.Direccion,
            FechaNacimiento = propietario.FechaNacimiento,
            Id_Poliza = propietario.Id_Poliza,
            //Poliza = PolizaMapper.EntityToDto(propietario.Poliza),
            PrimerApellido = propietario.PrimerApellido,
            PrimerNombre = propietario.PrimerNombre,
            SegundoApellido = propietario.SegundoApellido,
            SegundoNombre = propietario.SegundoNombre,
            //Vehiculo = VehiculoMapper.ListEntityToDtos(propietario.Vehiculo)
        };
    }

    public static List<PropietarioEntity> ListDtoToEntities(ICollection<PropietarioDTO> propietarios)
    {
        var list = new List<PropietarioEntity>();
        foreach (var propietarioDto in propietarios)
        {
            list.Add(DtoToEntity(propietarioDto));
        }

        return list;
    }

    public static List<PropietarioDTO> ListEntityToDtos(ICollection<PropietarioEntity> propietarios)
    {
        var list = new List<PropietarioDTO>();
        foreach (var propietarioEntity in propietarios)
        {
            list.Add(EntityToDto(propietarioEntity));
        }

        return list;
    }
}