using System.Collections.Generic;
using System;
using System.Linq;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.Database;
using RCVUcab.Persistence.Entities;
using RCVUcab.Persistence.DAOs.Interfaces;

namespace RCVUcab.Persistence.DAOs.Implementations
{
    public class MarcaDAO : DAO<MarcaDTO>, IMarcaDAO
    {
        public MarcaDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
        }

        public override List<MarcaDTO> Select()
        {
            throw new NotImplementedException();
        }

        public override MarcaDTO Select(string name)
        {
            var query = Context().Marcas
                .Where(m => m.Name == name)
                .Select(m => new MarcaDTO
                {
                    Name = m.Name
                });
            return query.First();
        }

        public override void Insert(MarcaDTO marcaDto)
        {
            MarcaEntity marca = new MarcaEntity();
            marca.Name = marcaDto.Name;
            Context().Marcas.Add(marca);
            Context().SaveChanges();
        }

        public override void Update(MarcaDTO marcaDto)
        {
            var itemToUpdate = Context().Marcas.Find(marcaDto.Name);
            itemToUpdate.Name = marcaDto.Name;

            Context().Marcas.Update(itemToUpdate);
            Context().SaveChanges();
        }

        public override void Delete(MarcaDTO marcaDto)
        {
            var itemToRemove = Context().Marcas.Find(marcaDto.Name);
            Context().Marcas.Remove(itemToRemove);
            Context().SaveChanges();
        }
    }
}