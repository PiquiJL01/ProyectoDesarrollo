using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.DataAccess.DAOs.Implementations
{
    public class FacturaDAO : DAO<FacturaEntity>, IFacturaDAO
    {
        public List<FacturaEntity> VerRegistrosFactura(string factura)
        {
            var data = Context().Facturas
                .Where(a => a.ID == factura)
                .Select(a => new FacturaEntity
                {
                    ID = a.ID,
                });

            return data.ToList();
        }

        public override List<FacturaEntity> Select()
        {
            throw new NotImplementedException();
        }

        public override FacturaEntity Select(string ID)
        {
            var query = Context().Usuarios
                .Where(x => x.Id == ID)
                .Select(x => new FacturaEntity
                {
                    ID = x.Id,
                });
            return query.First();
        }

        public override void Insert(FacturaEntity factura)
        {
            Context().Facturas.Add(factura);
            Context().SaveChanges();
        }

        public override void Update(FacturaEntity factura)
        {
            var itemToUpdate = Context().Facturas.Find(factura.ID);
            itemToUpdate.ID = factura.ID;

            Context().Facturas.Update(itemToUpdate);
            Context().SaveChanges();
        }

        public override void Delete(FacturaEntity factura)
        {
            var itemToRemove = Context().Facturas.Find(factura.ID);
            Context().Facturas.Remove(itemToRemove);
            Context().SaveChanges();
        }
    }
}