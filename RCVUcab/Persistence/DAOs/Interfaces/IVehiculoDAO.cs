using System.Collections.Generic;
using RCVUcab.BussinesLogic.DTOs;

namespace RCVUcab.Persistence.DAOs.Interfaces
{
    public interface IVehiculoDAO: IDAO<VehiculoDTO>
    {
        public List<VehiculoDTO> GetVehiculosByID(string id);
    }
}

