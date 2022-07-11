using System.Collections.Generic;
using System;
using System.Linq;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.Database;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.DAOs.Implementations
{
    public class PiezaDAO : DAO<PiezaDTO>
    {

        public PiezaDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }

        public override List<PiezaDTO> Select()
        {
            throw new NotImplementedException();
        }

        public override PiezaDTO Select(string ID)
        {
            var query = Context().Piezas
                .Where(p => p.ID == ID)
                .Select(p => new PiezaDTO
                {
                    ID = p.ID,
                    Name = p.Name,
                    Description = p.Description,
                });

            return query.First();
        }

        public override void Insert(PiezaDTO piezaDto)
        {
            PiezaEntity pieza = new PiezaEntity();
            pieza.ID = piezaDto.ID;
            pieza.Name = piezaDto.Name;
            pieza.Description = piezaDto.Description;
            Context().Piezas.Add(pieza);
            Context().SaveChanges();
        }

        public override void Update(PiezaDTO piezaDto)
        {
            var itemToUpdate = Context().Piezas.Find(piezaDto.ID);
            itemToUpdate.Name = piezaDto.Name;
            itemToUpdate.Description = piezaDto.Description;

            Context().Piezas.Update(itemToUpdate);
            Context().SaveChanges();
        }

        public override void Delete(PiezaDTO piezaDto)
        {
            var itemToRemove = Context().Piezas.Find(piezaDto.ID);
            Context().Piezas.Remove(itemToRemove);
            Context().SaveChanges();
        }
    }
}