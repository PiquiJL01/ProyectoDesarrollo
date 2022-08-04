using System;
using Microsoft.EntityFrameworkCore;
using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Database;
using RCVUcab.DataAccess.Entities;
using RCVUcab.DataAccess.Exceptions;

namespace RCVUcab.DataAccess.DAOs.DB
{
    public class ProveedorDB
    {
        private static DesignTimeDbContextFactory desing = new DesignTimeDbContextFactory();
        private IDataBaseContext _context = desing.CreateDbContext(null);

        public List<ProveedorDTO> Select()
        {
            try
            {
                var data = _context.Proveedores
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
                var data = _context.Proveedores
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

        public ProveedorDTO Select(string Id_Proveedor)
        {
            var query = _context.Proveedores
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

        public void Insert(ProveedorDTO proveedorDto)
        {
            ProveedorEntity proveedor = new ProveedorEntity();
            proveedor.ID = proveedorDto.Id_Proveedor;
            proveedor.Name = proveedorDto.Name;
            proveedor.Address = proveedorDto.Address;
            proveedor.TallerID = proveedorDto.TallerID;
            _context.Proveedores.Add(proveedor);
            _context.DbContext.SaveChanges();
        }

        public void Update(ProveedorDTO proveedorDTO)
        {
            var ItemToUpdate = _context.Proveedores.Find(proveedorDTO.Id_Proveedor);
            ItemToUpdate.Name = proveedorDTO.Name;
            ItemToUpdate.Address = proveedorDTO.Address;
            ItemToUpdate.TallerID = proveedorDTO.TallerID;
            _context.Proveedores.Update(ItemToUpdate);
            _context.DbContext.SaveChanges();
        }

        public void Delete(ProveedorDTO proveedorDto)
        {
            var itemToRemove = _context.Proveedores.Find(proveedorDto.Id_Proveedor);
            _context.Proveedores.Remove(itemToRemove);
            _context.DbContext.SaveChanges();
        }
    }
}

