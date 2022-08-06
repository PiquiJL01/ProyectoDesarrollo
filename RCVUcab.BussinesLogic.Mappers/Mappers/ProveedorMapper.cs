using RCVUcab.Persistence.Mappers;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class ProveedorMapper
{
    public static ProveedorEntity DtoToEntity(ProveedorDTO proveedor)
    {
        if (proveedor == null)
        {
            return null;
        }

        var listCotizacion = new List<CotizacionEntity>();
        foreach (var cotizacion in proveedor.Cotizacion)
        {
            listCotizacion.Add(CotizacionMapper.DtoToEntity(cotizacion));
        }

        var listProveedorMarca = new List<ProveedorMarcaEntity>();
        foreach (var proveedorMarca in proveedor.ProveedorMarca)
        {
            listProveedorMarca.Add(ProveedorMarcaMapper.DtoToEntity(proveedorMarca));
        }

        return new ProveedorEntity
        {
            Address = proveedor.Address,
            Cotizacion = listCotizacion,
            ID = proveedor.Id_Proveedor,
            Name = proveedor.Name,
            ProveedorMarca = listProveedorMarca,
            Taller = TallerMapper.DtoToEntity(proveedor.Taller),
            TallerID = proveedor.TallerID
        };
    }

    public static ProveedorDTO EntityToDto(ProveedorEntity proveedor)
    {
        if (proveedor == null)
        {
            return null;
        }

        var listCotizacion = new List<CotizacionDTO>();
        foreach (var cotizacion in proveedor.Cotizacion)
        {
            listCotizacion.Add(CotizacionMapper.EntityToDto(cotizacion));
        }

        var listProveedorMarca = new List<ProveedorMarcaDTO>();
        foreach (var proveedorMarca in proveedor.ProveedorMarca)
        {
            listProveedorMarca.Add(ProveedorMarcaMapper.EntityToDto(proveedorMarca));
        }

        return new ProveedorDTO
        {
            Address = proveedor.Address,
            Cotizacion = listCotizacion,
            Id_Proveedor = proveedor.ID,
            Name = proveedor.Name,
            ProveedorMarca = listProveedorMarca,
            Taller = TallerMapper.EntityToDto(proveedor.Taller),
            TallerID = proveedor.TallerID
        };
    }
}