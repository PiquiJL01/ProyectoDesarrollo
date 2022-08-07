using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class TallerMapper
{
    public static TallerEntity DtoToEntity(TallerDTO taller)
    {
        return new TallerEntity
        {
            Address = taller.Address,
            //CotizacionT = CotizacionMapper.ListDtoToEntities(taller.CotizacionT),
            ID = taller.ID,
            Name = taller.Name,
            PhoneNumber = taller.PhoneNumber,
            //Proveedor = ProveedorMapper.DtoToEntity(taller.Proveedor),
            //ProveedorMarca = ProveedorMarcaMapper.ListDtoToEntities(taller.ProveedorMarca),
            VehiculoIncidenteTaller = VehiculoIncidenteTallerMapper.ListDtoToEntities(taller.VehiculoIncidenteTaller)
        };
    }

    public static TallerDTO EntityToDto(TallerEntity taller)
    {
        return new TallerDTO
        {
            Address = taller.Address,
            //CotizacionT = CotizacionMapper.ListEntityToDtos(taller.CotizacionT),
            ID = taller.ID,
            Name = taller.Name,
            PhoneNumber = taller.PhoneNumber,
            //Proveedor = ProveedorMapper.EntityToDto(taller.Proveedor),
            //ProveedorMarca = ProveedorMarcaMapper.ListEntityToDtos(taller.ProveedorMarca),
            //VehiculoIncidenteTaller = VehiculoIncidenteTallerMapper.ListEntityToDtos(taller.VehiculoIncidenteTaller)
        };
    }

    public static List<TallerEntity> ListDtoToEntities(ICollection<TallerDTO> talleres)
    {
        var list = new List<TallerEntity>();
        foreach (var tallerEntity in talleres)
        {
            list.Add(DtoToEntity(tallerEntity));
        }

        return list;
    }

    public static List<TallerDTO> ListEntityToDtos(ICollection<TallerEntity> talleres)
    {
        var list = new List<TallerDTO>();
        foreach (var tallerEntity in talleres)
        {
            list.Add(EntityToDto(tallerEntity));
        }

        return list;
    }
}