using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface IIncidenteDAO : IDAO<IncidenteDTO>
    {
        public List<IncidenteDTO> GetIncidentesByAdministrador(string administrador);
        public List<IncidenteDTO> GetIncidenteByID(string id);
    }
}