using System;
using System.Collections.Generic;
using ProyectoDesarrollo.BussinesLogic.DTOs;

namespace ProyectoDesarrollo.Persistence.DAO.Interfaces
{
    public interface IIncidenteDAO
    {
        public List<IncidenteDTO> GetIncidentesByID(string id);
        //IncidenteDTO Select(string id);
        void Insert(IncidenteDTO incidenteDto);
        void Update(IncidenteDTO incidenteDto);
        void Delete(IncidenteDTO incidenteDto);

    }
}

