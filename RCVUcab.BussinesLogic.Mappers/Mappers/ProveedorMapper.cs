using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class ProveedorMapper
{
    public static ProveedorEntity DtoToEntity(ProveedorDTO proveedor)
    {
        return new ProveedorEntity
        {
            Address = proveedor.Address,
            //Cotizacion = CotizacionMapper.ListDtoToEntities(proveedor.Cotizacion),
            ID = proveedor.Id_Proveedor,
            Name = proveedor.Name,
            //ProveedorMarca = ProveedorMarcaMapper.ListDtoToEntities(proveedor.ProveedorMarca),
            //Taller = TallerMapper.DtoToEntity(proveedor.Taller),
            TallerID = proveedor.TallerID
        };
    }

    public static ProveedorDTO EntityToDto(ProveedorEntity proveedor)
    {
        return new ProveedorDTO
        {
            Address = proveedor.Address,
            //Cotizacion = CotizacionMapper.ListEntityToDtos(proveedor.Cotizacion),
            Id_Proveedor = proveedor.ID,
            Name = proveedor.Name,
            //ProveedorMarca = ProveedorMarcaMapper.ListEntityToDtos(proveedor.ProveedorMarca),
            //Taller = TallerMapper.EntityToDto(proveedor.Taller),
            TallerID = proveedor.TallerID
        };
    }

    public static List<ProveedorEntity> ListDtoToEntities(ICollection<ProveedorDTO> proveedores)
    {
        var list = new List<ProveedorEntity>();
        foreach (var proveedorDto in proveedores)
        {
            list.Add(DtoToEntity(proveedorDto));
        }

        return list;
    }

    public static List<ProveedorDTO> ListEntityToDtos(ICollection<ProveedorEntity> proveedores)
    {
        var list = new List<ProveedorDTO>();
        foreach (var proveedorEntity in proveedores)
        {
            list.Add(EntityToDto(proveedorEntity));
        }

        return list;
    }
}