using RCVUcab.BussinesLogic.DTO.DTOs;
using RCVUcab.DataAccess.Entities;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface ITallerDAO: IDAO<TallerEntity>
    {
        //public List<TallerDTO> GetTalleres();
        public List<TallerEntity> GetTalleresByID(string id);
        public List<ProveedorMarcaEntity> GetTalleresByBrand(string brand);
        public TallerEntity InsertR(TallerEntity taller);
    }
}