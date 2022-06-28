using System.Collections.Generic;
using ProyectoDesarrollo.Persistence.DataBase;
using ProyectoDesarrollo.Persistence.Entidades;
using System;
using ProyectoDesarrollo.BussinesLogic.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace ProyectoDesarrollo.Persistence.DAO.Implementations;


public class IncidenteDAO: DAO<Incidente>
{
    public readonly DataBaseContext _dataBaseContext;

    public IncidenteDAO(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }
    public List<IncidenteDTO> VerRegistrosFactura(string incidente)
    {
            var data = _dataBaseContext.Incidentes
               .Where(i => i.ID == incidente)
               .Select(i => new IncidenteDTO

               {
                   ID = i.ID,
                   Ubicacion = i.Ubicacion,
                   Fecha = i.Fecha,
                   Id_Perito = i.Id_Perito,
                   Id_Administrador = i.Id_Administrador,
               });

            return data.ToList();
     }
    public override IEnumerable<Incidente> Get()
    {
        throw new NotImplementedException();
    }

    public IncidenteDTO GetIncidente(string ID)
    {
        var query = _dataBaseContext.Incidentes
               .Where(i => i.ID == ID)
               .Select(i => new IncidenteDTO

               {
                   ID = i.ID,
                   Ubicacion = i.Ubicacion,
                   Fecha = i.Fecha,
                   Id_Perito = i.Id_Perito,
                   Id_Administrador = i.Id_Administrador,
               });
        return query.First();
    }

    public Task Add(IncidenteDTO incidenteDTO)
    {
        Incidente incidente = new Incidente();
        incidente.ID = incidenteDTO.ID;
        incidente.Ubicacion = incidenteDTO.Ubicacion;
        incidente.Fecha = incidenteDTO.Fecha;
        incidente.Id_Perito = incidenteDTO.Id_Perito;
        incidente.Id_Administrador = incidenteDTO.Id_Administrador;
        return Task.CompletedTask;
    }
    public Task update(IncidenteDTO  incidenteDTO, string ID)
    {
        var itemToUpdate = _dataBaseContext.Find(ID);
        itemToUpdate.ID = incidenteDTO.ID;
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task Delete(string ID)
    {
        var ItemToRemove = _dataBaseContext.Incidentes.Find(ID);
        _dataBaseContext.Incidentes.Remove(ItemToRemove);
        _dataBaseContext.SaveChanges();
        return Task.CompletedTask;
    }
}