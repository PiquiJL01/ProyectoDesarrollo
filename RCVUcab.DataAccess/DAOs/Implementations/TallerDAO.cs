using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;
using RCVUcab.DataAccess.Exceptions;


namespace RCVUcab.DataAccess.DAOs.Implementations
{
    public class TallerDAO : DAO<TallerEntity>, ITallerDAO
    {
        public override List<TallerEntity> Select()
        {
            try
            {
                var data = Context().Talleres
                    .Select(b => new TallerEntity
                    {
                        ID = b.ID,
                        Name = b.Name,
                        Address = b.Address,
                        PhoneNumber = b.PhoneNumber,
                    }).ToList();

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Talleres: "
                    , ex.Message, ex);
            }
        }

        public List<TallerEntity> GetTalleresByID(string id)
        {
            try
            {
                   var data = Context().Talleres
                    .Where(i => i.ID == id)
                    .Select(i => new TallerEntity
                    {
                        ID = id,
                        Name = i.Name,
                        Address = i.Address,
                        PhoneNumber = i.PhoneNumber,
                    }).ToList();

                    return data.ToList();

            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Taller para el: "
                  + id, ex.Message, ex);
            }

        }

        public List<ProveedorMarcaEntity> GetTalleresByBrand(string marca)
        {
            try
            {
                var data = Context().ProveedoresMarcas
                   .Include(b => b.Taller)
                   .Where(b => b.Id_Marca == marca)
                   .Select(b => new ProveedorMarcaEntity()
                   {
                       Id_Marca = b.Id_Marca,
                       Taller = new TallerEntity
                       {
                           ID = b.Taller.ID,
                           Name = b.Taller.Name,

                       }
                   }).ToList();

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de talleres para la marca: "
              + marca, ex.Message, ex);
            }
        }

        public override TallerEntity Select(string IdTaller)
        {
            var query = Context().Talleres
                .Where(x => x.ID == IdTaller)
                .Select(x => new TallerEntity
                {
                    ID = x.ID,
                    Name = x.Name,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                });
            return query.First();
        }

        public override void Insert(TallerEntity taller)
        {
            Context().Talleres.Add(taller);
            Context().SaveChanges();
        }

        public TallerEntity InsertR(TallerEntity taller)
        {
            Context().Talleres.Add(taller);
            Context().SaveChanges();

            var query = Context().Talleres
                .Where(x => x.ID == taller.ID)
                .Select(x => new TallerEntity
                {
                    ID = x.ID,
                    Name = x.Name,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                });
            return query.First();
        }

        public override void Update(TallerEntity taller)
        {
            Context().Talleres.Update(taller);
            Context().SaveChanges();
        }

        public override void Delete(TallerEntity taller)
        {
            Context().Talleres.Remove(taller);
            Context().SaveChanges();
        }
    }
}