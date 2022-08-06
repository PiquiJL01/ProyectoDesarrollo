using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface IVehiculoDAO: IDAO<VehiculoDTO>
    {
        public List<VehiculoDTO> GetVehiculosByID(string id);
    }
}