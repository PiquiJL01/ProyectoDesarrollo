using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class VehiculoMapper
{
    public static VehiculoEntity DtoToEntity(VehiculoDTO vehiculo)
    {
        if (vehiculo == null)
        {
            return null;
        }

        var list = new List<VehiculoIncidenteTallerEntity>();
        foreach (var vehiculoIncidenteTaller in vehiculo.VehiculoIncidenteTaller)
        {
            list.Add(VehiculoIncidenteTallerMapper.DtoToEntity(vehiculoIncidenteTaller));
        }

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
            VehiculoIncidenteTaller = list
        };
    }

    public static VehiculoDTO EntityToDto(VehiculoEntity vehiculo)
    {
        if (vehiculo == null)
        {
            return null;
        }

        var list = new List<VehiculoIncidenteTallerDTO>();
        foreach (var vehiculoIncidenteTaller in vehiculo.VehiculoIncidenteTaller)
        {
            list.Add(VehiculoIncidenteTallerMapper.EntityToDto(vehiculoIncidenteTaller));
        }

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
            VehiculoIncidenteTaller = list
        };
    }
}