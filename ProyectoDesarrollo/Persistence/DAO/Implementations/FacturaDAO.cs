using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class FacturaDAO: DAO<Factura>
{
    public readonly DataBaseContext _dataBaseContext;

    public FacturaDAO(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }

    public List<FacturaDTO> VerRegistrosFactura(string factura)
    {
        try
        {
            var data = _dataBaseContext.Facturas
               .Where(a => a.ID == factura)
               .Select(a => new FacturaDTO
               {
                  ID = a.ID,
               });

            return data.ToList();
        }
        catch (Exception ex)
        {
            throw new ExcepcionesProyecto("Ha ocurrido un error al intentar consultar la lista de facturas" + Factura , ex.Message, ex);
        }

    }

    public override IEnumerable<Factura> Get()
    {
        throw new NotImplementedException();
    }

    public  FacturaDAO Get(string ID)
    {
        var query = _dataBaseContext.Administradores
            .Where(x => x.Id == ID)
            .Select(x => new FacturaDTO
        {
        ID = x.Id,
     });
        return query.First();
    }

    public Task Add(FacturaDTO facturaDTO)
    {
        Factura factura = new Factura();
        factura.ID = facturaDTO.ID;
        _dataBaseContext.Facturas.Add(factura);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    //public Task Update(FacturaDTO facturaDTO,string ID)
    //{
    //    var ItemToUpdate = _dataBaseContext.Find(ID);
    //    ItemToUpdate.ID = facturaDTO.ID;
    //    _dataBaseContext.SaveChanges();
    //    return Task.CompletedTask;
    //}

    public  Task Delete(string ID)
    {
        var ItemToRemove = _dataBaseContext.Find(ID);
        _dataBaseContext.Facturas.Remove(ItemToRemove);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }
}