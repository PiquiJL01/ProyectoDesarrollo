using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface ICotizacionDAO : IDAO<CotizacionEntity>
    {
        public List<IncidenteEntity> GetCotizacionesByIncidente(string incidente);
        public List<CotizacionEntity> GetCotizacionesByID(string id);
    }
}