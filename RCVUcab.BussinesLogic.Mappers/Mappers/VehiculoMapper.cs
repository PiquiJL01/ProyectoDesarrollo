using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class VehiculoMapper
{
    public static VehiculoEntity DtoToEntity(VehiculoDTO vehiculo)
    {
        return new VehiculoEntity
        {
            Año = vehiculo.Año,
            Color = vehiculo.Color,
            Estado = vehiculo.Estado,
            Id_Marca = vehiculo.Id_Marca,
            Id_Propietario = vehiculo.Id_Propietario,
            Marca = MarcaMapper.DtoToEntity(vehiculo.Marca),
            Modelo = vehiculo.Modelo,
            NumeroDeEjes = vehiculo.NumeroDeEjes,
            NumeroDePuestos = vehiculo.NumeroDePuestos,
            Peso = vehiculo.Peso,
            Placa = vehiculo.Placa,
            Propietario = PropietarioMapper.DtoToEntity(vehiculo.Propietario),
            SerialCarroceria = vehiculo.SerialCarroceria,
            Tipo = vehiculo.Tipo,
            VehiculoIncidenteTaller = VehiculoIncidenteTallerMapper.ListDtoToEntities(vehiculo.VehiculoIncidenteTaller)
        };
    }

    public static VehiculoDTO EntityToDto(VehiculoEntity vehiculo)
    {
        return new VehiculoDTO
        {
            Año = vehiculo.Año,
            Color = vehiculo.Color,
            Estado = vehiculo.Estado,
            Id_Marca = vehiculo.Id_Marca,
            Id_Propietario = vehiculo.Id_Propietario,
            Marca = MarcaMapper.EntityToDto(vehiculo.Marca),
            Modelo = vehiculo.Modelo,
            NumeroDeEjes = vehiculo.NumeroDeEjes,
            NumeroDePuestos = vehiculo.NumeroDePuestos,
            Peso = vehiculo.Peso,
            Placa = vehiculo.Placa,
            Propietario = PropietarioMapper.EntityToDto(vehiculo.Propietario),
            SerialCarroceria = vehiculo.SerialCarroceria,
            Tipo = vehiculo.Tipo,
            VehiculoIncidenteTaller = VehiculoIncidenteTallerMapper.ListEntityToDtos(vehiculo.VehiculoIncidenteTaller)
        };
    }

    public static List<VehiculoEntity> ListDtoToEntities(ICollection<VehiculoDTO> vehiculos)
    {
        var list = new List<VehiculoEntity>();
        foreach (var vehiculoDto in vehiculos)
        {
            list.Add(DtoToEntity(vehiculoDto));
        }

        return list;
    }

    public static List<VehiculoDTO> ListEntityToDtos(ICollection<VehiculoEntity> vehiculos)
    {
        var list = new List<VehiculoDTO>();
        foreach (var vehiculoEntity in vehiculos)
        {
            list.Add(EntityToDto(vehiculoEntity));
        }

        return list;
    }
}