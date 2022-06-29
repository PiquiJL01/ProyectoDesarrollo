using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class ProveedorDAO: IIncidenteDAO<ProveedorDTO>
{
    public ProveedorDAO(DataBaseContext dataBaseContext):base(dataBaseContext)
    {

    }


    public override IEnumerable<ProveedorDTO> Select()
    {
        throw new NotImplementedException();
    }

    public override ProveedorDTO Select(string Id_Proveedor)
    {
        var query = Context().Proveedores
            .Where(p => p.Id == Id_Proveedor)
            .Select(p => new ProveedorDTO { 
                Id_Proveedor = p.Id_Proveedor,
                Name = p.Name,
                Address = p.Address,
                TallerID = p.TallerID,
            });
        return query.First();
    }

    public override void Insert(ProveedorDTO proveedorDto)
    {
        Proveedor proveedor = new Proveedor();
        proveedor.Id_Proveedor = proveedorDto.Id_Proveedor;
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
        var itemToRemove  = Context().Proveedores.Find(proveedorDto.Id_Proveedor);
        Context().Proveedores.Remove(itemToRemove);
        Context().SaveChanges();
    }
}