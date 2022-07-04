using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class CotizacionDAO: DAO<CotizacionDTO>
{

    public CotizacionDAO(DataBaseContext dataBaseContext):base(dataBaseContext)
    {
    }


    public override IEnumerable<CotizacionDTO> Select()
    {
        throw new NotImplementedException();
    }

    public override CotizacionDTO Select(string id)
    {
        var query = Context().Cotizaciones
            .Where(c => c.Id == id)
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

    public override void Insert(CotizacionDTO cotizacionDto)
    {
        Cotizacion cotizacion = new Cotizacion();
        IncidenteDAO incidente = new IncidenteDAO(Context());
        cotizacion.Id = cotizacionDto.Id;
        if (incidente.Select(cotizacionDto.Id_Incidente).Fecha.Year > 2020)
        {
            cotizacion.MontoTotal = cotizacionDto.MontoTotal * 0.5;
        }
        else
        {
            cotizacion.MontoTotal = cotizacionDto.MontoTotal;
        }
        cotizacion.Id_Proveedor = cotizacionDto.Id_Proveedor;
        cotizacion.Id_Incidente = cotizacionDto.Id_Incidente;
        cotizacion.Id_Taller = cotizacionDto.Id_Taller;
        Context().Cotizaciones.Add(cotizacion);
        Context().SaveChanges();
    }
    
    public override void Update(CotizacionDTO cotizacionDto)
    {
        var itemToUpdate = Context().Cotizaciones.Find(cotizacionDto.Id);
        itemToUpdate.MontoTotal = cotizacionDto.MontoTotal;

        Context().Cotizaciones.Update(itemToUpdate);
        Context().SaveChanges();
     }

    public override void Delete(CotizacionDTO cotizacionDto)
    {
        var ItemToRemove = Context().Cotizaciones.Find(cotizacionDto.Id);
        Context().Cotizaciones.Remove(ItemToRemove);
        Context().SaveChanges();
    }
}