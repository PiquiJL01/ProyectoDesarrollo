using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.BussinesLogic.Mappers.Mappers;

public static class UsuarioMapper
{
    public static UsuarioEntity DtoToEntity(UsuarioDTO usuario)
    {
        return new UsuarioEntity
        {
            Apellido = usuario.Apellido,
            BirthDate = usuario.BirthDate,
            Direccion = usuario.Direccion,
            Email = usuario.Email,
            Id = usuario.Id,
            //Incidente = IncidenteMapper.ListDtoToEntities(usuario.Incidente),
            Nombre = usuario.Nombre,
            //OrdenDeCompra = OrdenDeCompraMapper.ListDtoToEntity(usuario.OrdenDeCompra),
            //Poliza = PolizaMapper.ListDtoToEntities(usuario.Poliza),
            Rol = usuario.Rol,
            Telefono = usuario.Telefono
        };
    }

    public static UsuarioDTO EntityToDto(UsuarioEntity usuario)
    {
        return new UsuarioDTO
        {
            Apellido = usuario.Apellido,
            BirthDate = usuario.BirthDate,
            Direccion = usuario.Direccion,
            Email = usuario.Email,
            Id = usuario.Id,
            //Incidente = IncidenteMapper.ListEntityToDtos(usuario.Incidente),
            Nombre = usuario.Nombre,
            //OrdenDeCompra = OrdenDeCompraMapper.ListEntityToDtos(usuario.OrdenDeCompra),
            //Poliza = PolizaMapper.ListEntityToDtos(usuario.Poliza),
            Rol = usuario.Rol,
            Telefono = usuario.Telefono
        };
    }

    public static List<UsuarioEntity> ListDtoToEntities(ICollection<UsuarioDTO> usuarios)
    {
        var list = new List<UsuarioEntity>();
        foreach (var usuarioDto in usuarios)
        {
            list.Add(DtoToEntity(usuarioDto));
        }

        return list;
    }

    public static List<UsuarioDTO> ListEntityToDtos(ICollection<UsuarioEntity> usuarios)
    {
        var list = new List<UsuarioDTO>();
        foreach (var usuarioEntity in usuarios)
        {
            list.Add(EntityToDto(usuarioEntity));
        }

        return list;
    }
}