using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.Exceptions;
using ProyectoDesarrollo.Persistence.DAO.Interfaces;
using ProyectoDesarrollo.Persistence.Data;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;

public class CotizacionDAO: DAO<CotizacionDTO>, ICotizacionDAO
{

    public CotizacionDAO(DataBaseContext dataBaseContext):base(dataBaseContext)
    {
    }


    public override List<CotizacionDTO> Select()
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
        cotizacion.Id = cotizacionDto.Id;
        cotizacion.MontoTotal = cotizacionDto.MontoTotal;
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

    public List<IncidenteDTO> GetCotizacionesByIncidente(string incidente)
    {
        try
        {
            var data = _dataBaseContext.Incidentes
                .Include(b => b.Cotizacion)
                .Where(b => b.ID == incidente)
                .Select(b => new IncidenteDTO
                {
                    ID = b.ID,
                    Fecha = b.Fecha,
                    Cotizacion = b.Cotizacion.Select(p => new CotizacionDTO
                    {
                        Id = p.Id,
                        MontoTotal = p.MontoTotal,
                        Id_Proveedor = p.Id_Proveedor,
                        Id_Taller = p.Id_Taller,
                        PiezaCotizacion = p.PiezaCotizacion.Select(d => new PiezaCotizacionDTO
                        {
                            Id_Pieza = d.Id_Pieza,


                        }).ToList(),

                    }).ToList()
                });

            return data.ToList();
        }
        catch (Exception ex)
        {
            throw new ProyectoException("Ha ocurrido un error al intentar consultar la lista de Cotizaciones: "
                , ex.Message, ex);
        }
    }
}