using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using ProyectoDesarrollo.Persistence.DAO.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using ProyectoDesarrollo.Exceptions;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;


public class IncidenteDAO : IIncidenteDAO
{

    public readonly DataBaseContext _context;

    public IncidenteDAO(DataBaseContext context)
    {
        _context = context;
    }

    public IncidenteDAO(DataBaseContext dataBaseContext):base(dataBaseContext)
    {
    }

    public override List<IncidenteDTO> Select()
    {
        return new List<IncidenteDTO>();
    }

    public List<IncidenteDTO> GetIncidentesByID(string id)
    {
        try
        {
            var data = _context.Incidentes
                .Include(b => b.VehiculoIncidenteTaller)
                .Where(i => i.ID == id)
                .Select(i => new IncidenteDTO
                {
                    ID = i.ID,
                    Ubicacion = i.Ubicacion,
                    Fecha = i.Fecha,
                    Id_Perito = i.Id_Perito,
                    Id_Administrador = i.Id_Administrador,
                }).ToList();

            return data.ToList();
        }
        catch(Exception ex)
        {
            throw new ProyectoException("Ha ocurrido un error al intentar consultar la lista de proveedores para la marca: "
              + id, ex.Message, ex);
        }

    }

    public void Insert(IncidenteDTO incidenteDto)
    {
        Incidente incidente = new Incidente()
        {
            ID = incidenteDto.ID,
            Ubicacion = incidenteDto.Ubicacion,
            Fecha = incidenteDto.Fecha,
            Id_Perito = incidenteDto.Id_Perito,
            Id_Administrador = incidenteDto.Id_Administrador
        };
        _context.Incidentes.Add(incidente);
        _context.SaveChanges();
    }

    public void Update(IncidenteDTO incidenteDto)
    {
        var itemToUpdate = new Incidente()
        {
            Ubicacion = incidenteDto.Ubicacion,
            Fecha = incidenteDto.Fecha,
            Id_Perito = incidenteDto.Id_Perito,
            Id_Administrador = incidenteDto.Id_Administrador
        };
        _context.Incidentes.Update(itemToUpdate);
        _context.SaveChanges();
    }

    public void Delete(IncidenteDTO incidenteDto)
    {
        var itemToRemove = _context.Incidentes.Find(incidenteDto.ID);
        _context.Incidentes.Remove(itemToRemove);
        _context.SaveChanges();
    }
}