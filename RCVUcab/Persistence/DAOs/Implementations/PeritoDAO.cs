using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Implementations;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Persistence.Database;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.DAOs.Implementations
{
    public class PeritoDAO : DAO<PeritoDTO>, IPeritoDAO
    {
        public PeritoDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }

        public override List<PeritoDTO> Select()
        {
            throw new NotImplementedException();
        }

        public override PeritoDTO Select(string id)
        {
            var query = Context().Peritos
                .Where(p => p.Id == id)
                .Select(p => new PeritoDTO
                {
                    Id_Perito = p.Id_Perito
                });
            return query.First();

        }

        public override void Insert(PeritoDTO peritoDto)
        {
            PeritoEntity perito = new PeritoEntity();
            perito.Id_Perito = peritoDto.Id_Perito;
            Context().Peritos.Add(perito);
            Context().SaveChanges();
        }

        public override void Update(PeritoDTO peritoDto)
        {
            var itemToUpdate = Context().Peritos.Find(peritoDto.Id_Perito);
            itemToUpdate.Id_Perito = peritoDto.Id_Perito;

            Context().Peritos.Update(itemToUpdate);
            Context().SaveChanges();
        }

        public override void Delete(PeritoDTO peritoDto)
        {
            var ItemToRemove = Context().Peritos.Find(peritoDto.Id_Perito);
            Context().Peritos.Remove(ItemToRemove);
            Context().SaveChanges();
        }

        //Get Peritos
        public List<UsuarioDTO> GetPeritos()
        {
            try
            {
                var data = _dataBaseContext.Usuarios
                    .Where(b => b.Rol == RolName.Perito)
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
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Peritos: "
                    , ex.Message, ex);
            }
        }
    }
}