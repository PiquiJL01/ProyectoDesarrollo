using RCVUcab.BussinesLogic.DTO.DTOs;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface ITallerDAO: IDAO<TallerDTO>
    {
        //public List<TallerDTO> GetTalleres();
        public List<TallerDTO> GetTalleresByID(string id);
        public List<ProveedorMarcaDTO> GetTalleresByBrand(string brand);
    }
}