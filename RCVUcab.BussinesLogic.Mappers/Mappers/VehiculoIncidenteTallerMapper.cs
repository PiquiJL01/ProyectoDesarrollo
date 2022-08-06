using RCVUcab.Persistence.Mappers;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class VehiculoIncidenteTallerMapper
{
    public static VehiculoIncidenteTallerEntity DtoToEntity(VehiculoIncidenteTallerDTO vehiculoIncidenteTaller)
    {
        if (vehiculoIncidenteTaller == null)
        {
            return null;
        }

        return new VehiculoIncidenteTallerEntity
        {
            FechaEntrega = vehiculoIncidenteTaller.FechaEntrega,
            ID = vehiculoIncidenteTaller.ID,
            Id_Incidente = vehiculoIncidenteTaller.Id_Incidente,
            Id_Pieza = vehiculoIncidenteTaller.Id_Pieza,
            Id_Taller = vehiculoIncidenteTaller.Id_Taller,
            Id_Vehiculo = vehiculoIncidenteTaller.Id_Vehiculo,
            Incidente = IncidenteMapper.DtoToEntity(vehiculoIncidenteTaller.Incidente),
            Pieza = PiezaMapper.DtoToEntity(vehiculoIncidenteTaller.Pieza),
            Taller = TallerMapper.DtoToEntity(vehiculoIncidenteTaller.Taller),
            Vehiculo = VehiculoMapper.DtoToEntity(vehiculoIncidenteTaller.Vehiculo)
        };
    }

    public static VehiculoIncidenteTallerDTO EntityToDto(VehiculoIncidenteTallerEntity vehiculoIncidenteTaller)
    {
        if (vehiculoIncidenteTaller == null)
        {
            return null;
        }

        return new VehiculoIncidenteTallerDTO()
        {
            FechaEntrega = vehiculoIncidenteTaller.FechaEntrega,
            ID = vehiculoIncidenteTaller.ID,
            Id_Incidente = vehiculoIncidenteTaller.Id_Incidente,
            Id_Pieza = vehiculoIncidenteTaller.Id_Pieza,
            Id_Taller = vehiculoIncidenteTaller.Id_Taller,
            Id_Vehiculo = vehiculoIncidenteTaller.Id_Vehiculo,
            Incidente = IncidenteMapper.EntityToDto(vehiculoIncidenteTaller.Incidente),
            Pieza = PiezaMapper.EntityToDto(vehiculoIncidenteTaller.Pieza),
            Taller = TallerMapper.EntityToDto(vehiculoIncidenteTaller.Taller),
            Vehiculo = VehiculoMapper.EntityToDto(vehiculoIncidenteTaller.Vehiculo)
        };
    }
}