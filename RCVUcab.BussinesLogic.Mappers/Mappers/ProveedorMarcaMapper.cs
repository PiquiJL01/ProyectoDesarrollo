using RCVUcab.Persistence.Mappers;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class ProveedorMarcaMapper
{
    public static ProveedorMarcaEntity DtoToEntity(ProveedorMarcaDTO proveedorMarca)
    {
        if (proveedorMarca == null)
        {
            return null;
        }

        return new ProveedorMarcaEntity
        {
            ID = proveedorMarca.ID,
            Id_Marca = proveedorMarca.Id_Marca,
            Id_Proveedor = proveedorMarca.Id_Proveedor,
            Id_Taller = proveedorMarca.Id_Taller,
            Marca = MarcaMapper.DtoToEntity(proveedorMarca.Marca),
            Proveedor = ProveedorMapper.DtoToEntity(proveedorMarca.Proveedor),
            Taller = TallerMapper.DtoToEntity(proveedorMarca.Taller)
        };
    }

    public static ProveedorMarcaDTO EntityToDto(ProveedorMarcaEntity proveedorMarca)
    {
        if (proveedorMarca == null)
        {
            return null;
        }

        return new ProveedorMarcaDTO
        {
            ID = proveedorMarca.ID,
            Id_Marca = proveedorMarca.Id_Marca,
            Id_Proveedor = proveedorMarca.Id_Proveedor,
            Id_Taller = proveedorMarca.Id_Taller,
            Marca = MarcaMapper.EntityToDto(proveedorMarca.Marca),
            Proveedor = ProveedorMapper.EntityToDto(proveedorMarca.Proveedor),
            Taller = TallerMapper.EntityToDto(proveedorMarca.Taller)
        };
    }
}