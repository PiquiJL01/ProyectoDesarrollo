using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class OrdenDeCompraMapper
{
    public static OrdenDeCompraEntity DtoToEntity(OrdenDeCompraDTO ordenDeCompra)
    {
        return new OrdenDeCompraEntity
        {
            //Administrador = UsuarioMapper.DtoToEntity(ordenDeCompra.Administrador),
            ID = ordenDeCompra.ID,
            Id_Administrador = ordenDeCompra.Id_Administrador,
            //Id_Cotizacion = CotizacionMapper.DtoToEntity(ordenDeCompra.Id_Cotizacion)
        };
    }

    public static OrdenDeCompraDTO EntityToDto(OrdenDeCompraEntity ordenDeCompra)
    {
        return new OrdenDeCompraDTO
        {
            //Administrador = UsuarioMapper.EntityToDto(ordenDeCompra.Administrador),
            ID = ordenDeCompra.ID,
            Id_Administrador = ordenDeCompra.Id_Administrador,
            //Id_Cotizacion = CotizacionMapper.EntityToDto(ordenDeCompra.Id_Cotizacion)
        };
    }

    public static List<OrdenDeCompraEntity> ListDtoToEntity(ICollection<OrdenDeCompraDTO> ordenesDeCompra)
    {
        var list = new List<OrdenDeCompraEntity>();
        foreach (var ordenDeCompraDto in ordenesDeCompra)
        {
            list.Add(DtoToEntity(ordenDeCompraDto));
        }

        return list;
    }

    public static List<OrdenDeCompraDTO> ListEntityToDtos(ICollection<OrdenDeCompraEntity> ordnesDeCompra)
    {
        var list = new List<OrdenDeCompraDTO>();
        foreach (var ordenDeCompraEntity in ordnesDeCompra)
        {
            list.Add(EntityToDto(ordenDeCompraEntity));
        }

        return list;
    }
}