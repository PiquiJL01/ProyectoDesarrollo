using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.DAOs.Interfaces;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.DataAccess.DAOs.Implementations
{

    public class ProveedorDAO : DAO<ProveedorDTO>, IProveedorDAO
    {
        public ProveedorDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }


        public override List<ProveedorDTO> Select()
        {
            try
            {
                var data = Context().Proveedores
                    .Select(p => new ProveedorDTO
                    {
                        Id_Proveedor = p.ID,
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

        public List<ProveedorDTO> GetProveedoresByID(string id)
        {
            try
            {
                var data = Context().Proveedores
                 .Where(i => i.ID == id)
                 .Select(i => new ProveedorDTO
                 {
                     Id_Proveedor = id,
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

        public override ProveedorDTO Select(string Id_Proveedor)
        {
            var query = Context().Proveedores
                .Where(p => p.ID == Id_Proveedor)
                .Select(p => new ProveedorDTO
                {
                    Id_Proveedor = p.ID,
                    Name = p.Name,
                    Address = p.Address,
                    TallerID = p.TallerID,
                });
            return query.First();
        }

        public override void Insert(ProveedorDTO proveedorDto)
        {
            ProveedorEntity proveedor = new ProveedorEntity();
            proveedor.ID = proveedorDto.Id_Proveedor;
            proveedor.Name = proveedorDto.Name;
            proveedor.Address = proveedorDto.Address;
            proveedor.TallerID = proveedorDto.TallerID;
            Context().Proveedores.Add(proveedor);
            Context().SaveChanges();
        }

        public override void Update(ProveedorDTO proveedorDTO)
        {
            var ItemToUpdate = Context().Proveedores.Find(proveedorDTO.Id_Proveedor);
            ItemToUpdate.Name = proveedorDTO.Name;
            ItemToUpdate.Address = proveedorDTO.Address;
            ItemToUpdate.TallerID = proveedorDTO.TallerID;
            Context().Proveedores.Update(ItemToUpdate);
            Context().SaveChanges();
        }

        public override void Delete(ProveedorDTO proveedorDto)
        {
            var itemToRemove = Context().Proveedores.Find(proveedorDto.Id_Proveedor);
            Context().Proveedores.Remove(itemToRemove);
            Context().SaveChanges();
        }
    }
}