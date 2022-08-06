using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.DataAccess.DAOs.Implementations
{

    public class PolizaDAO : DAO<PolizaDTO>, IPolizaDAO
    {
        public PolizaDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }

        public override List<PolizaDTO> Select()
        {
            try
            {
                var data = Context().Polizas
                    .Select(b => new PolizaDTO
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

        public List<PolizaDTO> GetPolizasByID(string id)
        {
            try
            {
                var data = Context().Polizas
                 .Where(i => i.ID == id)
                 .Select(i => new PolizaDTO
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

        public override PolizaDTO Select(string ID)
        {
            var query = Context().Polizas
                .Where(p => p.ID == ID)
                .Select(p => new PolizaDTO
                {
                    ID = p.ID,
                    Id_Admin = p.Id_Admin,
                    TipoPoliza = p.TipoPoliza
                });
            return query.First();

        }

        public override void Insert(PolizaDTO polizaDTO)
        {
            PolizaEntity poliza = new PolizaEntity();
            poliza.ID = polizaDTO.ID;
            poliza.Id_Admin = polizaDTO.Id_Admin;
            poliza.TipoPoliza = polizaDTO.TipoPoliza;
            Context().Polizas.Add(poliza);
            Context().SaveChanges();
        }

        public override void Update(PolizaDTO polizaDTO)
        {
            var itemToUpdate = Context().Polizas.Find(polizaDTO.ID);
            itemToUpdate.ID = polizaDTO.ID;
            itemToUpdate.Id_Admin = polizaDTO.Id_Admin;
            itemToUpdate.TipoPoliza = polizaDTO.TipoPoliza;

            Context().Polizas.Update(itemToUpdate);
            Context().SaveChanges();
        }

        public override void Delete(PolizaDTO polizaDto)
        {
            var itemToRemove = Context().Polizas.Find(polizaDto.ID);
            Context().Polizas.Remove(itemToRemove);
            Context().SaveChanges();
        }
    }
}