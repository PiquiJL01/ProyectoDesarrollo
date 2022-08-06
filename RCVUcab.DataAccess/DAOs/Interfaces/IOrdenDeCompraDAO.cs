using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface IOrdenDeCompraDAO: IDAO<OrdenDeCompraDTO>
    {
        public List<OrdenDeCompraDTO> GetOrdenesDeCompraByID(string id);
    }
}