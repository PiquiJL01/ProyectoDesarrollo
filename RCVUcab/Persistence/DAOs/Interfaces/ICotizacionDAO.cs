using System.Collections.Generic;
using RCVUcab.BussinesLogic.DTOs;

namespace RCVUcab.Persistence.DAOs.Interfaces
{
    public interface ICotizacionDAO : IDAO<CotizacionDTO>
    {
        public List<IncidenteDTO> GetCotizacionesByIncidente(string incidente);
        public List<CotizacionDTO> GetCotizacionesByID(string id);
    }
}

