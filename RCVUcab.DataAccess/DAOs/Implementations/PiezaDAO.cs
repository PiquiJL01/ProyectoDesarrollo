using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.DataAccess.DAOs.Implementations
{
    public class PiezaDAO : DAO<PiezaEntity>, IPiezaDAO
    {
        public override List<PiezaEntity> Select()
        {
            throw new NotImplementedException();
        }

        public override PiezaEntity Select(string ID)
        {
            var query = Context().Piezas
                .Where(p => p.ID == ID)
                .Select(p => new PiezaEntity
                {
                    ID = p.ID,
                    Name = p.Name,
                    Description = p.Description,
                });

            return query.First();
        }

        public override void Insert(PiezaEntity pieza)
        {
            Context().Piezas.Add(pieza);
            Context().SaveChanges();
        }

        public override void Update(PiezaEntity pieza)
        {
            Context().Piezas.Update(pieza);
            Context().SaveChanges();
        }

        public override void Delete(PiezaEntity pieza)
        {
            Context().Piezas.Remove(pieza);
            Context().SaveChanges();
        }
    }
}