using System.Collections.Generic;
using RCVUcab.BussinesLogic.DTOs;

namespace RCVUcab.Persistence.DAOs.Interfaces
{
    public interface IIncidenteDAO
    {
        public List<AdministradorDTO> GetIncidentesByAdministrador(string administrador);
    }
}

