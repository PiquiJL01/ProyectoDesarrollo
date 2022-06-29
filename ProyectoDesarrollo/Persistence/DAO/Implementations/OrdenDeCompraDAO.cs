using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class OrdenDeCompraDAO: DAO<OrdenDeCompraDTO>
{
    public OrdenDeCompraDAO(DataBaseContext dataBaseContext):base(dataBaseContext)
    {
    }

    public override IEnumerable<OrdenDeCompraDTO> Select()
    {
        throw new NotImplementedException();
    }

    public override OrdenDeCompraDTO Select(String id)
    {
        var query = Context().OrdenesDeCompra
            .Where(o => o.ID == id)
            .Select(o => new OrdenDeCompraDTO
            {
                ID = o.ID,
                Id_Administrador = o.Id_Administrador,
            });
        return query.First();
            }

    public override void Insert(OrdenDeCompraDTO ordenDeCompraDto) 
    {
        OrdenDeCompra ordenDeCompra = new OrdenDeCompra();
        ordenDeCompra.ID = ordenDeCompraDto.ID;
        ordenDeCompra.Id_Administrador = ordenDeCompraDto.Id_Administrador;
        Context().OrdenesDeCompra.Add(ordenDeCompra);
        Context().SaveChanges();

    }

    public override  void Update(OrdenDeCompraDTO ordenDeCompraDto)
    {
        var itemToUpdate = Context().OrdenesDeCompra.Find(ordenDeCompraDto.ID);
        itemToUpdate.ID = ordenDeCompraDto.ID;

        Context().OrdenesDeCompra.Update(itemToUpdate);
        Context().SaveChanges();
    }

    public override void Delete(OrdenDeCompraDTO ordenDeCompraDto)
    {
        var itemToRemove = Context().OrdenesDeCompra.Find(ordenDeCompraDto.ID);
        Context().OrdenesDeCompra.Remove(itemToRemove);
        Context().SaveChanges();

    }
}