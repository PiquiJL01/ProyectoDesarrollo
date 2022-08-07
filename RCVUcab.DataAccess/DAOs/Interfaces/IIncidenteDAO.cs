using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface IIncidenteDAO : IDAO<IncidenteEntity>
    {
        public List<IncidenteEntity> GetIncidentesByAdministrador(string administrador);
        public List<IncidenteEntity> GetIncidenteByID(string id);
    }
}