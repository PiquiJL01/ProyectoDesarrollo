using System.Collections.Generic;
using RCVUcab.BussinesLogic.DTOs;

namespace RCVUcab.Persistence.DAOs.Interfaces
{
    public interface IProveedorDAO : IDAO<ProveedorDTO>
    {
        public List<ProveedorDTO> GetProveedoresByID(string id);
    }
}

