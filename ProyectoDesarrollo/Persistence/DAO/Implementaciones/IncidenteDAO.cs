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
    public class IncidenteDAO : IIncidenteDAO
    {
        public readonly DataBaseContext _context;

        public IncidenteDAO(DataBaseContext context)
        {
            _context = context;
        }


        //Get Incidentes
        public List<AdministradorDTO> GetIncidentesByAdministrador(string administrador)
        {
            try
            {
                var data = _context.Administradores
                   .Include(b => b.Incidente)
                   .Where(b => b.Id_Admin == administrador)
                   .Select(b => new AdministradorDTO
                   {
                       Id_Admin = b.Id,
                       Incidente = b.Incidente.Select(p => new IncidenteDTO
                       {
                           ID = p.ID,
                           Ubicacion = p.Ubicacion,
                           Fecha = p.Fecha,
                           VehiculoIncidenteTaller = p.VehiculoIncidenteTaller.Select(w => new VehiculoIncidenteTallerDTO
                           {
                               Id_Vehiculo = w.Id_Vehiculo,
                               Id_Pieza = w.Id_Pieza

                           }).ToList()

                       }).ToList()
                   });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new ProyectoException("Ha ocurrido un error al intentar consultar la lista de Incidentes: "
                , ex.Message, ex);
            }
        }


    }
}

