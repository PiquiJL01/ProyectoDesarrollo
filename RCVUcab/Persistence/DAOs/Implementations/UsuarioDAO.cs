using System.Collections.Generic;
using System;
using System.Linq;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.Database;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.DAOs.Implementations
{

    public class UsuarioDAO : DAO<UsuarioDTO>
    {
        public UsuarioDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }

        public override List<UsuarioDTO> Select()
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
            UsuarioEntity usuario = new UsuarioEntity()
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
            var itemToUpdate = new UsuarioEntity()
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
}