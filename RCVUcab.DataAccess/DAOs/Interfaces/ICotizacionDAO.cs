using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface ICotizacionDAO : IDAO<CotizacionDTO>
    {
        public List<IncidenteDTO> GetCotizacionesByIncidente(string incidente);
        public List<CotizacionDTO> GetCotizacionesByID(string id);
    }
}