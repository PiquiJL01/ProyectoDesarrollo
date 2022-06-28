using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class ProveedorDAO: DAO<Proveedor>
{
    public readonly DataBaseContext _dataBaseContext;

    public ProveedorDAO(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }


    public override IEnumerable<Proveedor> Get()
    {
        throw new NotImplementedException();
    }

    public ProveedorDTO GetProveedor(string Id_Proveedor)
    {
        var query = _dataBaseContext.Proveedores
            .Where(p => p.Id == Id_Proveedor)
            .Select(p => new ProveedorDTO { 
                Id_Proveedor = p.Id_Proveedor,
                Name = p.Name,
                Address = p.Address,
                TallerID = p.TallerID,
            });
        return query.First();
    }

    public Task  Add(ProveedorDTO proveedorDTO)
    {
        Proveedor proveedor = new Proveedor();
        proveedor.Id_Proveedor = proveedorDTO.Id_Proveedor;
        proveedor.Name = proveedorDTO.Name;
        proveedor.Address = proveedorDTO.Address;
        proveedor.TallerID = proveedorDTO.TallerID;
        _dataBaseContext.Proveedores.Add(proveedor);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task Update(ProveedorDTO proveedorDTO,string Id_Proveedor)
    {
        var ItemToUpdate = _dataBaseContext.Proveedores.Find(Id_Proveedor);
        ItemToUpdate.Name = proveedorDTO.Name;
        ItemToUpdate.Address = proveedorDTO.Address;
        ItemToUpdate.TallerID = proveedorDTO.TallerID;
        _dataBaseContext.SaveChanges();

        return  Task.CompletedTask;

    }

    public Task Delete(string Id_Proveedor)
    {
        var ItemToRemove  = _dataBaseContext.Proveedores.Find(Id_Proveedor);
        _dataBaseContext.Proveedores.Remove(ItemToRemove);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }
}