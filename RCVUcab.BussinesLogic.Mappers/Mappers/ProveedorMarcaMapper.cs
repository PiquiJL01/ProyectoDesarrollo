using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class ProveedorMarcaMapper
{
    public static ProveedorMarcaEntity DtoToEntity(ProveedorMarcaDTO proveedorMarca)
    {
        return new ProveedorMarcaEntity
        {
            ID = proveedorMarca.ID,
            Id_Marca = proveedorMarca.Id_Marca,
            Id_Proveedor = proveedorMarca.Id_Proveedor,
            Id_Taller = proveedorMarca.Id_Taller,
            //Marca = MarcaMapper.DtoToEntity(proveedorMarca.Marca),
            //Proveedor = ProveedorMapper.DtoToEntity(proveedorMarca.Proveedor),
            //Taller = TallerMapper.DtoToEntity(proveedorMarca.Taller)
        };
    }

    public static ProveedorMarcaDTO EntityToDto(ProveedorMarcaEntity proveedorMarca)
    {
        return new ProveedorMarcaDTO
        {
            ID = proveedorMarca.ID,
            Id_Marca = proveedorMarca.Id_Marca,
            Id_Proveedor = proveedorMarca.Id_Proveedor,
            Id_Taller = proveedorMarca.Id_Taller,
            //Marca = MarcaMapper.EntityToDto(proveedorMarca.Marca),
            //Proveedor = ProveedorMapper.EntityToDto(proveedorMarca.Proveedor),
            //Taller = TallerMapper.EntityToDto(proveedorMarca.Taller)
        };
    }

    public static List<ProveedorMarcaEntity> ListDtoToEntities(ICollection<ProveedorMarcaDTO> proeveedorMarcas)
    {
        var list = new List<ProveedorMarcaEntity>();
        foreach (var proveedorMarcaDto in proeveedorMarcas)
        {
            list.Add(DtoToEntity(proveedorMarcaDto));
        }
        return list;
    }

    public static List<ProveedorMarcaDTO> ListEntityToDtos(ICollection<ProveedorMarcaEntity> proveedorMarcas)
    {
        var list = new List<ProveedorMarcaDTO>();
        foreach (var proveedorMarcaEntity in proveedorMarcas)
        {
            list.Add(EntityToDto(proveedorMarcaEntity));
        }

        return list;
    }
}