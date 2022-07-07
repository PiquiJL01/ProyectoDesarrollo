using System;
using System.Collections.Generic;
using ProyectoDesarrollo.BussinesLogic.DTOs;

namespace ProyectoDesarrollo.Persistence.DAO.Interfaces
{
    public interface IIncidenteDAO
    {
        public List<IncidenteDTO> GetIncidenteByID(string id);
        //IncidenteDTO Select(string id);
        void Insert(IncidenteDTO incidenteDto);
        void Update(IncidenteDTO incidenteDto);
        void Delete(IncidenteDTO incidenteDto);
        IEnumerable<IncidenteDTO> Select();
        IEnumerable<IncidenteDTO> Select(string id);
        //List<IncidenteDTO> GetIncidentesById(string id);
        public List<IncidenteDTO> DeleteIncidente(string id);

    }
}

