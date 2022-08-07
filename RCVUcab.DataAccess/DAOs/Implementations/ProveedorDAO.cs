using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.DataAccess.DAOs.Implementations
{

    public class ProveedorDAO : DAO<ProveedorEntity>, IProveedorDAO
    {
        public override List<ProveedorEntity> Select()
        {
            try
            {
                var data = Context().Proveedores
                    .Select(p => new ProveedorEntity
                    {
                        ID = p.ID,
                        Name = p.Name,
                        Address = p.Address,
                        TallerID = p.TallerID,

                    }).ToList();

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Proveedores: "
                    , ex.Message, ex);
            }
        }

        public List<ProveedorEntity> GetProveedoresByID(string id)
        {
            try
            {
                var data = Context().Proveedores
                 .Where(i => i.ID == id)
                 .Select(i => new ProveedorEntity
                 {
                     ID = id,
                     Name = i.Name,
                     Address = i.Address,
                     TallerID = i.TallerID,

                 }).ToList();

                return data.ToList();

            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Taller para el: "
                  + id, ex.Message, ex);
            }

        }

        public override ProveedorEntity Select(string Id_Proveedor)
        {
            var query = Context().Proveedores
                .Where(p => p.ID == Id_Proveedor)
                .Select(p => new ProveedorEntity
                {
                    ID = p.ID,
                    Name = p.Name,
                    Address = p.Address,
                    TallerID = p.TallerID,
                });
            return query.First();
        }

        public override void Insert(ProveedorEntity proveedor)
        {
            Context().Proveedores.Add(proveedor);
            Context().SaveChanges();
        }

        public override void Update(ProveedorEntity proveedor)
        {
            Context().Proveedores.Update(proveedor);
            Context().SaveChanges();
        }

        public override void Delete(ProveedorEntity proveedor)
        {
            Context().Proveedores.Remove(proveedor);
            Context().SaveChanges();
        }
    }
}