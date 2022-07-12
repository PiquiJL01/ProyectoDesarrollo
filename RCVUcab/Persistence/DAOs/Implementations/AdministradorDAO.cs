using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Persistence.Database;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.DAOs.Implementations
{
    public class AdministradorDAO : DAO<AdministradorDTO>, IAdministradorDAO
    {

        public AdministradorDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
        }


        public override List<AdministradorDTO> Select()
        {
            throw new NotImplementedException();
        }

        //Get Administradores
        public List<UsuarioDTO> GetAdministradores()
        {
            try
            {
                var data = _dataBaseContext.Usuarios
                    .Where(b => b.Rol == Entities.RolName.Administrador)
                    .Select(b => new UsuarioDTO
                    {
                        Id = b.Id,
                        Nombre = b.Nombre,
                        Apellido = b.Apellido,
                        Telefono = b.Telefono,
                        Email = b.Email,
                        Direccion = b.Direccion,
                        BirthDate = b.BirthDate
                    });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de administradores: "
                    , ex.Message, ex);
            }
        }

        public override AdministradorDTO Select(String id)
        {
            var query = Context().Administradores
                .Where(x => x.Id == id)
                .Select(x => new AdministradorDTO
                {
                    Id_Admin = x.Id,
                });
            return query.First();
        }

        public override void Insert(AdministradorDTO administradorDto)
        {
            AdministradorEntity administrador = new AdministradorEntity();
            administrador.Id = administradorDto.Id_Admin;
            Context().Add(administrador);
            Context().SaveChanges();
        }

        public override void Delete(AdministradorDTO administradorDto)
        {
            var itemToUpdate = Context().Administradores.Find(administradorDto.Id_Admin);
            Context().Administradores.Remove(itemToUpdate);

            Context().Administradores.Update(itemToUpdate);
            Context().SaveChanges();
        }

        public override void Update(AdministradorDTO administradorDto)
        {
            throw new NotImplementedException();
        }
    }
}