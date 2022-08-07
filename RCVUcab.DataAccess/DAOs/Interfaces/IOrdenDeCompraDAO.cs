using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface IOrdenDeCompraDAO: IDAO<OrdenDeCompraEntity>
    {
        public List<OrdenDeCompraEntity> GetOrdenesDeCompraByID(string id);
    }
}