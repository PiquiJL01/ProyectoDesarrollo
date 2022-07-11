using System.Collections.Generic;
using RCVUcab.BussinesLogic.DTOs;

namespace RCVUcab.Persistence.DAOs.Interfaces
{
    public interface IPeritoDAO
    {
        public List<UsuarioDTO> GetPeritos();
    }
}

