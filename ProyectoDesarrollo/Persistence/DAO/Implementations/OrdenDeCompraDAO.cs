using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class OrdenDeCompraDAO: DAO<OrdenDeCompra>
{
    public readonly DataBaseContext _dataBaseContext;

    public OrdenDeCompraDAO(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }

    public override IEnumerable<OrdenDeCompra> Get()
    {
        throw new NotImplementedException();
    }

    public OrdenDeCompraDTO GetOrdenDeCompra(string ID)
    {
        var query = _dataBaseContext.OrdenesDeCompra
            .Where(o => o.ID == ID)
            .Select(o => new OrdenDeCompraDTO
            {
                ID = o.ID,
                Id_Administrador = o.Id_Administrador,
            });
        return query.First();
            }

    public Task Add(OrdenDeCompraDTO ordenDeCompraDTO) 
    {
        OrdenDeCompra ordenDeCompra = new OrdenDeCompra();
        ordenDeCompra.ID = ordenDeCompraDTO.ID;
        ordenDeCompra.Id_Administrador = ordenDeCompraDTO.Id_Administrador;
        _dataBaseContext.OrdenesDeCompra.Add(ordenDeCompra);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;

    }

    public Task  Update(OrdenDeCompraDTO ordenDeCompraDTO,string  ID)
    {
        var ItemToUpdate = _dataBaseContext.OrdenesDeCompra.Find(ID);
        ItemToUpdate.ID = ordenDeCompraDTO.ID;
        _dataBaseContext.SaveChanges();

        return Task.CompletedTask;
    }

    public Task Delete(string ID)
    {
        var ItemToRemove = _dataBaseContext.OrdenesDeCompra.Find(ID);
        _dataBaseContext.OrdenesDeCompra.Remove(ItemToRemove);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;

    }
}