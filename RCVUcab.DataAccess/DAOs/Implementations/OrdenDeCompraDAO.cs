using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Entities;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.DataAccess.DAOs.Implementations
{

    public class OrdenDeCompraDAO : DAO<OrdenDeCompraEntity>, IOrdenDeCompraDAO
    {
        public override List<OrdenDeCompraEntity> Select()
        {
            try
            {
                var data = Context().OrdenesDeCompra
                    .Select(b => new OrdenDeCompraEntity
                    {
                        ID = b.ID,
                        Id_Administrador = b.Id_Administrador,

                    }).ToList();

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Talleres: "
                    , ex.Message, ex);
            }
        }


        public List<OrdenDeCompraEntity> GetOrdenesDeCompraByID(string id)
        {
            try
            {
                var data = Context().OrdenesDeCompra
                 .Where(i => i.ID == id)
                 .Select(i => new OrdenDeCompraEntity
                 {
                     ID = i.ID,
                     Id_Administrador = i.Id_Administrador,

                 }).ToList();

                return data.ToList();

            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Taller para el: "
                  + id, ex.Message, ex);
            }

        }

        public override OrdenDeCompraEntity Select(string id)
        {
            var query = Context().OrdenesDeCompra
                .Where(o => o.ID == id)
                .Select(o => new OrdenDeCompraEntity
                {
                    ID = o.ID,
                    Id_Administrador = o.Id_Administrador,
                });
            return query.First();
        }

        public override void Insert(OrdenDeCompraEntity ordenDeCompra)
        {
            Context().OrdenesDeCompra.Add(ordenDeCompra);
            Context().SaveChanges();

        }

        public override void Update(OrdenDeCompraEntity ordenDeCompra)
        {
            Context().OrdenesDeCompra.Update(ordenDeCompra);
            Context().SaveChanges();
        }

        public override void Delete(OrdenDeCompraEntity ordenDeCompra)
        {
            Context().OrdenesDeCompra.Remove(ordenDeCompra);
            Context().SaveChanges();

        }
    }
}