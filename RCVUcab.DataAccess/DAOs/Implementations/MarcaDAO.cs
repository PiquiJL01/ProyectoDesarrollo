using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.DataAccess.DAOs.Implementations
{
    public class MarcaDAO : DAO<MarcaEntity>, IMarcaDAO
    {
        public override List<MarcaEntity> Select()
        {
            throw new NotImplementedException();
        }

        public override MarcaEntity Select(string name)
        {
            var query = Context().Marcas
                .Where(m => m.Name == name)
                .Select(m => new MarcaEntity
                {
                    Name = m.Name
                });
            return query.First();
        }

        public override void Insert(MarcaEntity marca)
        {
            Context().Marcas.Add(marca);
            Context().SaveChanges();
        }

        public override void Update(MarcaEntity marca)
        {
            Context().Marcas.Update(marca);
            Context().SaveChanges();
        }

        public override void Delete(MarcaEntity marca)
        {
            Context().Marcas.Remove(marca);
            Context().SaveChanges();
        }
    }
}