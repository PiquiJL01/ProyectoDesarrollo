using System;
using System.Collections.Generic;
using ProyectoDesarrollo.BussinesLogic.DTOs;

namespace ProyectoDesarrollo.Persistence.DAO.Interfaces
{
    public interface IAdministradorDAO
    {
        public List<UsuarioDTO> GetAdministradores();
    }
}

