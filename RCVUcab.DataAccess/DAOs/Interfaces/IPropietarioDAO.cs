using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface IPropietarioDAO : IDAO<PropietarioDTO>
    {
        public List<PropietarioDTO> GetPropietarioByID(string id);
    }
}