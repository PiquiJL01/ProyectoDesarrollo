using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class CotizacionDAO: DAO<Cotizacion>
{
    public readonly DataBaseContext _dataBaseContext;

    public CotizacionDAO(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }


    public override IEnumerable<Cotizacion> Get()
    {
        throw new NotImplementedException();
    }

    public override CotizacionDTO  GetCotizacionDTO(string Id)
    {
        var query = _dataBaseContext.Cotizaciones
            .Where(c => c.Id == Id)
            .Select(c => new CotizacionDTO
            {
                Id = c.Id,
                MontoTotal = c.MontoTotal,
                Id_Proveedor = c.Id_Proveedor,
                Id_Incidente = c.Id_Incidente,
                Id_Taller = c.Id_Taller,
            });
        return query.First();
    }

    public Task Add(CotizacionDTO cotizacionDTO)
    {
        Cotizacion cotizacion = new Cotizacion();
        cotizacion.Id = cotizacionDTO.Id;
        cotizacion.MontoTotal = cotizacionDTO.MontoTotal;
        cotizacion.Id_Proveedor = cotizacionDTO.Id_Proveedor;
        cotizacion.Id_Incidente = cotizacionDTO.Id_Incidente;
        cotizacion.Id_Taller = cotizacionDTO.Id_Taller;
        _dataBaseContext.Cotizaciones.Add(cotizacion);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task update(CotizacionDTO cotizacionDTO,string Id)
    {
        var itemToUpdate = _dataBaseContext.Cotizaciones.Find(Id);
        itemToUpdate.MontoTotal = cotizacionDTO.MontoTotal;
        _dataBaseContext.SaveChanges();

        return Task.CompletedTask;
     }

    public Task Delete(string Id)
    {
        var ItemToRemove = _dataBaseContext.Cotizaciones.Find(Id);
        _dataBaseContext.Cotizaciones.Remove(ItemToRemove);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;

    }
}