using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.DataAccess.DAOs.Implementations
{
    public class FacturaDAO : DAO<FacturaDTO>, IFacturaDAO
    {
        public FacturaDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
        }

        public List<FacturaDTO> VerRegistrosFactura(string factura)
        {
            var data = Context().Facturas
                .Where(a => a.ID == factura)
                .Select(a => new FacturaDTO
                {
                    ID = a.ID,
                });

            return data.ToList();
        }

        public override List<FacturaDTO> Select()
        {
            throw new NotImplementedException();
        }

        public override FacturaDTO Select(string ID)
        {
            var query = Context().Usuarios
                .Where(x => x.Id == ID)
                .Select(x => new FacturaDTO
                {
                    ID = x.Id,
                });
            return query.First();
        }

        public override void Insert(FacturaDTO facturaDto)
        {
            FacturaEntity factura = new FacturaEntity();
            factura.ID = facturaDto.ID;
            Context().Facturas.Add(factura);
            Context().SaveChanges();
        }

        public override void Update(FacturaDTO facturaDto)
        {
            var itemToUpdate = Context().Facturas.Find(facturaDto.ID);
            itemToUpdate.ID = facturaDto.ID;

            Context().Facturas.Update(itemToUpdate);
            Context().SaveChanges();
        }

        public override void Delete(FacturaDTO facturaDto)
        {
            var itemToRemove = Context().Facturas.Find(facturaDto.ID);
            Context().Facturas.Remove(itemToRemove);
            Context().SaveChanges();
        }
    }
}