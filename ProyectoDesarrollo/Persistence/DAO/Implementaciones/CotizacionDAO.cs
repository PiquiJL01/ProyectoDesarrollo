using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Exceptions;
using ProyectoDesarrollo.Persistence.DAO.Interfaces;
using ProyectoDesarrollo.Persistence.DataBase;

namespace ProyectoDesarrollo.Persistence.DAO.Implementaciones
{
    public class CotizacionDAO : ICotizacionDAO
    {
        public readonly DataBaseContext _context;

        public CotizacionDAO(DataBaseContext context)
        {
            _context = context;
        }


        //Get Cotizaciones
        public List<IncidenteDTO> GetCotizacionesByIncidente(string incidente)
        {
            try
            {
                var data = _context.Incidentes
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
}

