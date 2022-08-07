using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface IVehiculoDAO: IDAO<VehiculoEntity>
    {
        public List<VehiculoEntity> GetVehiculosByID(string id);
    }
}