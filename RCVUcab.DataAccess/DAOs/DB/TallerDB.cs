using System;
using Microsoft.EntityFrameworkCore;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.DataAccess.DAOs.DB
{
    public class TallerDB
    {
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
        private IDataBaseContext _context = desing.CreateDbContext(null);

        public List<TallerDTO> Select()
        {
            try
            {
                var data = _context.Talleres
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



        public TallerDTO GetTalleresByID(string id)
        {
            try
            {
                var data = _context.Talleres
                 .Where(i => i.ID == id)
                 .Select(i => new TallerDTO
                 {
                     ID = id,
                     Name = i.Name,
                     Address = i.Address,
                     PhoneNumber = i.PhoneNumber,
                 }).ToList();

                return data.Single();

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
                var data = _context.ProveedoresMarcas
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


        public TallerDTO Select(string IdTaller)
        {
            var query = _context.Talleres
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

        public TallerDTO Insert(TallerEntity taller)
        {
            _context.Talleres.Add(taller);
            _context.DbContext.SaveChanges();

            var data = _context.Talleres
                .Where(i => i.ID == taller.ID)
                .Select(x => new TallerDTO
                {
                    ID = x.ID,
                    Name = x.Name,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                });
            return data.First();

            /*TallerEntity taller = new TallerEntity();
            taller.ID = tallerDto.ID;
            taller.Name = tallerDto.Name;
            taller.Address = tallerDto.Address;
            taller.PhoneNumber = tallerDto.PhoneNumber;
            _context.Talleres.Add(taller);
            _context.DbContext.SaveChanges();*/
        }

        public void Update(TallerDTO tallerDto)
        {
            var itemToUpdate = _context.Talleres.Find(tallerDto.ID);
            itemToUpdate.Name = tallerDto.Name;
            itemToUpdate.Address = tallerDto.Address;
            itemToUpdate.PhoneNumber = tallerDto.PhoneNumber;
            _context.Talleres.Update(itemToUpdate);
            _context.DbContext.SaveChanges();
        }

        public void Delete(TallerDTO tallerDto)
        {
            var itemToRemove = _context.Talleres.Find(tallerDto.ID);
            _context.Talleres.Remove(itemToRemove);
            _context.DbContext.SaveChanges();
        }
    }
}

