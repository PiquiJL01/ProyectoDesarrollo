using RCVUcab.DataAccess.Entities;

namespace RCVUcab.DataAccess.DAOs.Interfaces
{
    public interface IPolizaDAO : IDAO<PolizaEntity>
    {
        public List<PolizaEntity> GetPolizasByID(string id);
    }
}