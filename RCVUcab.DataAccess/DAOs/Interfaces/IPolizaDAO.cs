using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface IPolizaDAO : IDAO<PolizaDTO>
    {
        public List<PolizaDTO> GetPolizasByID(string id);
    }
}