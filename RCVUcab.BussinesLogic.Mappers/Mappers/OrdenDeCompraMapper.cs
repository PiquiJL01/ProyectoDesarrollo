using RCVUcab.Persistence.Mappers;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class OrdenDeCompraMapper
{
    public static OrdenDeCompraEntity DtoToEntity(OrdenDeCompraDTO ordenDeCompra)
    {
        if (ordenDeCompra == null)
        {
            return null;
        }

        return new OrdenDeCompraEntity
        {
            Administrador = UsuarioMapper.DtoToEntity(ordenDeCompra.Administrador),
            ID = ordenDeCompra.ID,
            Id_Administrador = ordenDeCompra.Id_Administrador,
            Id_Cotizacion = CotizacionMapper.DtoToEntity(ordenDeCompra.Id_Cotizacion)
        };
    }

    public static OrdenDeCompraDTO EntityToDto(OrdenDeCompraEntity ordenDeCompra)
    {
        if (ordenDeCompra == null)
        {
            return null;
        }

        return new OrdenDeCompraDTO
        {
            Administrador = UsuarioMapper.EntityToDto(ordenDeCompra.Administrador),
            ID = ordenDeCompra.ID,
            Id_Administrador = ordenDeCompra.Id_Administrador,
            Id_Cotizacion = CotizacionMapper.EntityToDto(ordenDeCompra.Id_Cotizacion)
        };
    }
}