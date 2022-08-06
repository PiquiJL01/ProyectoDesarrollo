﻿using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class FacturaMapper
{
    public static FacturaEntity DtoToEntity(FacturaDTO factura)
    {
        if (factura == null)
        {
            return null;
        }

        return new FacturaEntity
        {
            ID = factura.ID,
            ID_OrdenDeCompra = OrdenDeCompraMapper.DtoToEntity(factura.ID_OrdenDeCompra)
        };
    }

    public static FacturaDTO EntityToDto(FacturaEntity factura)
    {
        if (factura == null)
        {
            return null;
        }

        return new FacturaDTO
        {
            ID = factura.ID,
            ID_OrdenDeCompra = OrdenDeCompraMapper.EntityToDto(factura.ID_OrdenDeCompra)
        };
    }
}