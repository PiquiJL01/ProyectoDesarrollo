using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class UsuarioDAO: DAO<Usuario>
{
    public readonly DataBaseContext _dataBaseContext;

    public TallerDAO(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }
    public override IEnumerable<Usuario> Get()
    {
        throw new NotImplementedException();
    }

    public  UsuarioDTO GetUsuario(string Id)
    {
        var query = _dataBaseContext.Usuarios
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
        
    }

    public Task Add(UsuarioDTO usuarioDTO)

    {
        Usuario  usuario=new Usuario();
        usuario.Id = usuarioDTO.Id;
        usuario.Nombre = usuarioDTO.Nombre; 
        usuario.Apellido = usuarioDTO.Apellido;
        usuario.Telefono = usuarioDTO.Telefono;
        usuario.Email = usuarioDTO.Email;
        usuario.Direccion = usuarioDTO.Direccion;
        usuario.BirthDate = usuarioDTO.BirthDate;
        usuario.Rol = (RolName)usuarioDTO.Rol;
        _dataBaseContext.Usuarios.Add(usuario);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task Update( UsuarioDTO  usuarioDTO,string  Id)
    {
        var ItemToUpdate = _dataBaseContext.Usuarios.Find(Id);
        ItemToUpdate.Id = Id;
        ItemToUpdate.Nombre = usuarioDTO.Nombre;    
        ItemToUpdate.Apellido = usuarioDTO.Apellido;    
        ItemToUpdate.Telefono = usuarioDTO.Telefono;
        ItemToUpdate.Email = usuarioDTO.Email;
        ItemToUpdate.Direccion = usuarioDTO.Direccion;
        ItemToUpdate.BirthDate = usuarioDTO.BirthDate;
        ItemToUpdate.Rol = (RolName)usuarioDTO.Rol;
        _dataBaseContext.SaveChanges();

        return  Task.CompletedTask;

    }

    public Task Delete(string Id)
    {
        var ItemToRemove =_dataBaseContext.Usuarios.Find(Id);
        _dataBaseContext.Usuarios.Remove(ItemToRemove);
        _dataBaseContext.SaveChanges();

        return Task.CompletedTask;
    }
}