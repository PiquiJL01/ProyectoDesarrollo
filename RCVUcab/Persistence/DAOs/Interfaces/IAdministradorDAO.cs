using System.Collections.Generic;
using RCVUcab.BussinesLogic.DTOs;

namespace RCVUcab.Persistence.DAOs.Interfaces
{
    public interface IAdministradorDAO : IDAO<UsuarioDTO>
    {
        public List<UsuarioDTO> GetAdministradores();
    }
}

