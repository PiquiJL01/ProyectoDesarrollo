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

    public class TallerDAO : DAO<TallerDTO>, ITallerDAO
    {
        public TallerDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }

        public override List<TallerDTO> Select()
        {
            throw new NotImplementedException();
        }

        //Get Talleres
        public List<TallerDTO> GetTalleres()
        {
            try
            {
                var data = _dataBaseContext.Talleres
                    .Include(b => b.ID)
                    .Select(b => new TallerDTO
                    {
                        Id_Taller = b.ID,
                        Name = b.Name,
                        Address = b.Address,
                        PhoneNumber = b.PhoneNumber,
                    });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Talleres: "
                    , ex.Message, ex);
            }
        }

        public override TallerDTO Select(string Id_Taller)
        {
            var query = Context().Talleres
                .Where(x => x.ID == Id_Taller)
                .Select(x => new TallerDTO
                {
                    Id_Taller = x.ID,
                    Name = x.Name,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                });
            return query.First();
        }

        public override void Insert(TallerDTO tallerDto)
        {
            TallerEntity taller = new TallerEntity();
            taller.ID = tallerDto.Id_Taller;
            taller.Name = tallerDto.Name;
            taller.Address = tallerDto.Address;
            taller.PhoneNumber = tallerDto.PhoneNumber;
            Context().Talleres.Add(taller);
            Context().SaveChanges();
        }

        public override void Update(TallerDTO tallerDto)
        {
            var itemToUpdate = Context().Talleres.Find(tallerDto.Id_Taller);
            itemToUpdate.Name = tallerDto.Name;
            itemToUpdate.Address = tallerDto.Address;
            itemToUpdate.PhoneNumber = tallerDto.PhoneNumber;
            Context().Talleres.Update(itemToUpdate);
            Context().SaveChanges();
        }

        public override void Delete(TallerDTO tallerDto)
        {
            var itemToRemove = Context().Talleres.Find(tallerDto.Id_Taller);
            Context().Talleres.Remove(itemToRemove);
            Context().SaveChanges();
        }
    }
}