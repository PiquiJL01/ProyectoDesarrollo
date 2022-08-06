using System.Collections.Generic;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.Mappers;

public static class UsuarioMapper
{
    public static UsuarioEntity DtoToEntity(UsuarioDTO usuario)
    {
        if (usuario == null)
        {
            return null;
        }

        var listIncidente = new List<IncidenteEntity>();
        foreach (var incidente in usuario.Incidente)
        {
            listIncidente.Add(IncidenteMapper.DtoToEntity(incidente));
        }

        var listOrdenDeCompra = new List<OrdenDeCompraEntity>();
        foreach (var ordenDeCompra in usuario.OrdenDeCompra)
        {
            listOrdenDeCompra.Add(OrdenDeCompraMapper.DtoToEntity(ordenDeCompra));
        }

        var listPoliza = new List<PolizaEntity>();
        foreach (var poliza in usuario.Poliza)
        {
            listPoliza.Add(PolizaMapper.DtoToEntity(poliza));
        }

        return new UsuarioEntity
        {
            Apellido = usuario.Apellido,
            BirthDate = usuario.BirthDate,
            Direccion = usuario.Direccion,
            Email = usuario.Email,
            Id = usuario.Id,
            Incidente = listIncidente,
            Nombre = usuario.Nombre,
            OrdenDeCompra = listOrdenDeCompra,
            Poliza = listPoliza,
            Rol = usuario.Rol,
            Telefono = usuario.Telefono
        };
    }

    public static UsuarioDTO EntityToDto(UsuarioEntity usuario)
    {
        if (usuario == null)
        {
            return null;
        }

        var listIncidente = new List<IncidenteDTO>();
        foreach (var incidente in usuario.Incidente)
        {
            listIncidente.Add(IncidenteMapper.EntityToDto(incidente));
        }

        var listOrdenDeCompra = new List<OrdenDeCompraDTO>();
        foreach (var ordenDeCompra in usuario.OrdenDeCompra)
        {
            listOrdenDeCompra.Add(OrdenDeCompraMapper.EntityToDto(ordenDeCompra));
        }

        var listPoliza = new List<PolizaDTO>();
        foreach (var poliza in usuario.Poliza)
        {
            listPoliza.Add(PolizaMapper.EntityToDto(poliza));
        }

        return new UsuarioDTO
        {
            Apellido = usuario.Apellido,
            BirthDate = usuario.BirthDate,
            Direccion = usuario.Direccion,
            Email = usuario.Email,
            Id = usuario.Id,
            Incidente = listIncidente,
            Nombre = usuario.Nombre,
            OrdenDeCompra = listOrdenDeCompra,
            Poliza = listPoliza,
            Rol = usuario.Rol,
            Telefono = usuario.Telefono
        };
    }
}