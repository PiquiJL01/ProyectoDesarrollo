using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class UsuarioDAO: DAO<UsuarioDTO>
{
    public UsuarioDAO(DataBaseContext dataBaseContext):base(dataBaseContext)
    {

    }
    public override IEnumerable<UsuarioDTO> Select()
    {
        throw new NotImplementedException();
    }

    public override UsuarioDTO Select(string Id)
    {
        var query = Context().Usuarios
            .Where(u => u.Id == Id)
            .Select(u => new UsuarioDTO
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Telefono = u.Telefono,
                Email = u.Email,
                Direccion = u.Direccion,
                BirthDate = u.BirthDate,
                Rol = (UsuarioDTO.RolName)u.Rol
            });
        return query.First();
    }

    public override void Insert(UsuarioDTO usuarioDto)

    {
        Usuario usuario = new Usuario
        {
            Id = usuarioDto.Id,
            Nombre = usuarioDto.Nombre,
            Apellido = usuarioDto.Apellido,
            Telefono = usuarioDto.Telefono,
            Email = usuarioDto.Email,
            Direccion = usuarioDto.Direccion,
            BirthDate = usuarioDto.BirthDate,
            Rol = (RolName)usuarioDto.Rol
        };

        Context().Usuarios.Add(usuario);
        Context().SaveChanges();
    }

    public override void Update(UsuarioDTO usuarioDTO)
    {
        var itemToUpdate = new Usuario
        {
            Id = usuarioDTO.Id,
            Nombre = usuarioDTO.Nombre,
            Apellido = usuarioDTO.Apellido,
            Telefono = usuarioDTO.Telefono,
            Email = usuarioDTO.Email,
            Direccion = usuarioDTO.Direccion,
            BirthDate = usuarioDTO.BirthDate,
            Rol = (RolName)usuarioDTO.Rol
        };

        Context().Usuarios.Update(itemToUpdate);
        Context().SaveChanges();
    }

    public override void Delete(UsuarioDTO usuario)
    {
        var itemToRemove = Context().Usuarios.Find(usuario.Id);
        Context().Usuarios.Remove(itemToRemove);
        Context().SaveChanges();
    }
}