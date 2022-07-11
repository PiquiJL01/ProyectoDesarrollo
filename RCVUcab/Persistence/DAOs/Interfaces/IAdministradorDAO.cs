using System.Collections.Generic;
using RCVUcab.BussinesLogic.DTOs;

namespace RCVUcab.Persistence.DAOs.Interfaces
{
    public interface IAdministradorDAO : IDAO<AdministradorDTO>
    {
        public List<UsuarioDTO> GetAdministradores();
    }
}

