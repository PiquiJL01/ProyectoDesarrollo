/*using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Persistence.Database;
using RCVUcab.Persistence.Entities;


namespace RCVUcab.DataAccess.DAOs.Implementations
{

    public class TallerDAO : DAO<TallerDTO>, ITallerDAO
    {
        public TallerDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }

        public override List<TallerDTO> Select()
        {
            try
            {
                var data = Context().Talleres
                    .Select(b => new TallerDTO
                    {
                        ID = b.ID,
                        Name = b.Name,
                        Address = b.Address,
                        PhoneNumber = b.PhoneNumber,
                    }).ToList();

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Talleres: "
                    , ex.Message, ex);
            }
        }


        
        public List<TallerDTO> GetTalleresByID(string id)
        {
            try
            {
                   var data = Context().Talleres
                    .Where(i => i.ID == id)
                    .Select(i => new TallerDTO
                    {
                        ID = id,
                        Name = i.Name,
                        Address = i.Address,
                        PhoneNumber = i.PhoneNumber,
                    }).ToList();

                    return data.ToList();

            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Taller para el: "
                  + id, ex.Message, ex);
            }

        }


        public List<ProveedorMarcaDTO> GetTalleresByBrand(string marca)
        {
            try
            {
                var data = Context().ProveedoresMarcas
                   .Include(b => b.Taller)
                   .Where(b => b.Id_Marca == marca)
                   .Select(b => new ProveedorMarcaDTO
                   {
                       Id_Marca = b.Id_Marca,
                       Taller = new TallerDTO
                       {
                           ID = b.Taller.ID,
                           Name = b.Taller.Name,

                       }
                   }).ToList();

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de talleres para la marca: "
              + marca, ex.Message, ex);
            }
        }


        public override TallerDTO Select(string IdTaller)
        {
            var query = Context().Talleres
                .Where(x => x.ID == IdTaller)
                .Select(x => new TallerDTO
                {
                    ID = x.ID,
                    Name = x.Name,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                });
            return query.First();
        }

        public override void Insert(TallerDTO tallerDto)
        {
            TallerEntity taller = new TallerEntity();
            taller.ID = tallerDto.ID;
            taller.Name = tallerDto.Name;
            taller.Address = tallerDto.Address;
            taller.PhoneNumber = tallerDto.PhoneNumber;
            Context().Talleres.Add(taller);
            Context().SaveChanges();
        }

        public override void Update(TallerDTO tallerDto)
        {
            var itemToUpdate = Context().Talleres.Find(tallerDto.ID);
            itemToUpdate.Name = tallerDto.Name;
            itemToUpdate.Address = tallerDto.Address;
            itemToUpdate.PhoneNumber = tallerDto.PhoneNumber;
            Context().Talleres.Update(itemToUpdate);
            Context().SaveChanges();
        }

        public override void Delete(TallerDTO tallerDto)
        {
            var itemToRemove = Context().Talleres.Find(tallerDto.ID);
            Context().Talleres.Remove(itemToRemove);
            Context().SaveChanges();
        }
    }
}*/