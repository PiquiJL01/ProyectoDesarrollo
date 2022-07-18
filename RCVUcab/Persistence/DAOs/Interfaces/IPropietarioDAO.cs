using System.Collections.Generic;
using RCVUcab.BussinesLogic.DTOs;

namespace RCVUcab.Persistence.DAOs.Interfaces
{
    public interface IPropietarioDAO : IDAO<PropietarioDTO>
    {
        public List<PropietarioDTO> GetPropietarioByID(string id);
    }
}

