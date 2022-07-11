using System.Collections.Generic;
using RCVUcab.BussinesLogic.DTOs;

namespace RCVUcab.Persistence.DAOs.Interfaces
{
    public interface ICotizacionDAO
    {
        public List<IncidenteDTO> GetCotizacionesByIncidente(string incidente);
    }
}

