﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Persistence.Database;
using RCVUcab.Persistence.Entities;

namespace RCVUcab.Persistence.DAOs.Implementations
{
    public class IncidenteDAO : DAO<IncidenteDTO>, IIncidenteDAO
    {
        public IncidenteDAO(DataBaseContext context) : base(context)
        {

        }

        public override List<IncidenteDTO> Select()
        {
            return new List<IncidenteDTO>();
        }

        public override IncidenteDTO Select(string id)
        {
            throw new NotImplementedException();
        }

        public List<IncidenteDTO> GetIncidenteByID(string id)
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
            catch (Exception ex)
            {
                throw new RCVException(
                    id, ex.Message, ex);
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

        //Get Incidentes
        public List<AdministradorDTO> GetIncidentesByAdministrador(string administrador)
        {
            try
            {
                var data = _dataBaseContext.Administradores
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
                            VehiculoIncidenteTaller = p.VehiculoIncidenteTaller.Select(w =>
                                new VehiculoIncidenteTallerDTO
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
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de Incidentes: "
                    , ex.Message, ex);
            }
        }
    }
}