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


public class IncidenteDAO : DAO<IncidenteDTO>
{
    public IncidenteDAO(DataBaseContext context):base(context)
    {

    }

    public override IEnumerable<IncidenteDTO> Select()
    {
        return new List<IncidenteDTO>();
    }

    public override IncidenteDTO Select(string id)
    {
        throw new NotImplementedException();
    }

    public List<IncidenteDTO> GetIncidentesByID(string id)
    {
        try
        {
            var data = Context().Incidentes
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

    public override void Insert(IncidenteDTO incidenteDto)
    {
        Incidente incidente = new Incidente()
        {
            ID = incidenteDto.ID,
            Ubicacion = incidenteDto.Ubicacion,
            Fecha = incidenteDto.Fecha,
            Id_Perito = incidenteDto.Id_Perito,
            Id_Administrador = incidenteDto.Id_Administrador
        };
        Context().Incidentes.Add(incidente);
        Context().SaveChanges();
    }

    public override void Update(IncidenteDTO incidenteDto)
    {
        var itemToUpdate = new Incidente()
        {
            Ubicacion = incidenteDto.Ubicacion,
            Fecha = incidenteDto.Fecha,
            Id_Perito = incidenteDto.Id_Perito,
            Id_Administrador = incidenteDto.Id_Administrador
        };
        Context().Incidentes.Update(itemToUpdate);
        Context().SaveChanges();
    }

    public override void Delete(IncidenteDTO incidenteDto)
    {
        var itemToRemove = Context().Incidentes.Find(incidenteDto.ID);
        Context().Incidentes.Remove(itemToRemove);
        Context().SaveChanges();
    }
}