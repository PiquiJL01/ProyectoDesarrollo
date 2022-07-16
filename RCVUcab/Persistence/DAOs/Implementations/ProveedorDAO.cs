using System.Collections.Generic;
using System;
using System.Linq;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Persistence.Database;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.DAOs.Implementations
{

    public class ProveedorDAO : DAO<ProveedorDTO>, IProveedorDAO
    {
        public ProveedorDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }


        public override List<ProveedorDTO> Select()
        {
            throw new NotImplementedException();
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