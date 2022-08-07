using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface IProveedorDAO : IDAO<ProveedorEntity>
    {
        public List<ProveedorEntity> GetProveedoresByID(string id);
    }
}