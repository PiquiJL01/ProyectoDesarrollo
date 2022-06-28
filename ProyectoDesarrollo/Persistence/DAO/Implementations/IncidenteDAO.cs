using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;


public class IncidenteDAO: DAO<IncidenteDTO>
{

    public IncidenteDAO(DataBaseContext dataBaseContext):base(dataBaseContext)
    {
    }

    public override List<IncidenteDTO> Select()
    {
        throw new NotImplementedException();
     }

    public override IncidenteDTO Select(string id)
    {
        var data = Context().Incidentes
            .Where(i => i.ID == id)
            .Select(i => new IncidenteDTO

            {
                ID = i.ID,
                Ubicacion = i.Ubicacion,
                Fecha = i.Fecha,
                Id_Perito = i.Id_Perito,
                Id_Administrador = i.Id_Administrador,
            });
        return data.First();
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