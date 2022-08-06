using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface IProveedorDAO : IDAO<ProveedorDTO>
    {
        public List<ProveedorDTO> GetProveedoresByID(string id);
    }
}