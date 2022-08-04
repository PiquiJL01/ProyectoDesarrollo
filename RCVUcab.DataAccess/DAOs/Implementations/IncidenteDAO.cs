/*using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Persistence.Database;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.DataAccess.DAOs.Implementations
{
    public class IncidenteDAO : DAO<IncidenteDTO>, IIncidenteDAO
    {
        public IncidenteDAO(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }

        public override List<IncidenteDTO> Select()
        {
            try
            {
                var data = Context().Incidentes
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
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Talleres: "
                    , ex.Message, ex);
            }
        }

        public override IncidenteDTO Select(string id)
        {
            var query = Context().Incidentes
                .Where(i => i.ID == id)
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

        public List<IncidenteDTO> GetIncidenteByID(string id)
        {
            try
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

                 }).ToList();

                return data.ToList();

            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar el Taller para el: "
                  + id, ex.Message, ex);
            }

        }

        public override void Insert(IncidenteDTO incidenteDto)
        {
            IncidenteEntity incidente = new IncidenteEntity()
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
            var itemToUpdate = new IncidenteEntity()
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

        //Get Incidentes - PROBADO
        public List<IncidenteDTO> GetIncidentesByAdministrador(string administrador)
        {
            try
            {
                var data = _dataBaseContext.Incidentes
                    .Where(b => b.Id_Administrador == administrador)
                    .Select(b => new IncidenteDTO
                    {
                        Id_Administrador = administrador,
                        ID = b.ID,
                        Ubicacion = b.Ubicacion,
                        Fecha = b.Fecha,
                        Id_Perito = b.Id_Perito
                    });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Incidentes: "
                    , ex.Message, ex);
            }
        }
    }
}*/