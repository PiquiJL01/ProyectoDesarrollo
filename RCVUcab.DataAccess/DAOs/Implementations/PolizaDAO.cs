using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.DataAccess.DAOs.Implementations
{

    public class PolizaDAO : DAO<PolizaEntity>, IPolizaDAO
    {
        public override List<PolizaEntity> Select()
        {
            try
            {
                var data = Context().Polizas
                    .Select(b => new PolizaEntity
                    {
                        ID = b.ID,
                        Id_Admin = b.Id_Admin,
                        TipoPoliza = b.TipoPoliza
                    }).ToList();

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Talleres: "
                    , ex.Message, ex);
            }
        }

        public List<PolizaEntity> GetPolizasByID(string id)
        {
            try
            {
                var data = Context().Polizas
                 .Where(i => i.ID == id)
                 .Select(i => new PolizaEntity
                 {
                     ID = id,
                     Id_Admin = i.Id_Admin,
                     TipoPoliza = i.TipoPoliza
                 }).ToList();

                return data.ToList();

            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Taller para el: "
                  + id, ex.Message, ex);
            }

        }

        public override PolizaEntity Select(string ID)
        {
            var query = Context().Polizas
                .Where(p => p.ID == ID)
                .Select(p => new PolizaEntity
                {
                    ID = p.ID,
                    Id_Admin = p.Id_Admin,
                    TipoPoliza = p.TipoPoliza
                });
            return query.First();

        }

        public override void Insert(PolizaEntity poliza)
        {
            Context().Polizas.Add(poliza);
            Context().SaveChanges();
        }

        public override void Update(PolizaEntity poliza)
        {
            Context().Polizas.Update(poliza);
            Context().SaveChanges();
        }

        public override void Delete(PolizaEntity poliza)
        {
            Context().Polizas.Remove(poliza);
            Context().SaveChanges();
        }
    }
}