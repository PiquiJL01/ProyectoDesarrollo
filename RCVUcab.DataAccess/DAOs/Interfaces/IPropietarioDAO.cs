using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface IPropietarioDAO : IDAO<PropietarioEntity>
    {
        public List<PropietarioEntity> GetPropietarioByID(string id);
    }
}