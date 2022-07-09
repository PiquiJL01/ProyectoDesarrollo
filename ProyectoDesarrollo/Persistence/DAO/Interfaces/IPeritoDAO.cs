using System;
using System.Collections.Generic;
using ProyectoDesarrollo.BussinesLogic.DTOs;

namespace ProyectoDesarrollo.Persistence.DAO.Interfaces
{
    public interface IPeritoDAO
    {
        public List<UsuarioDTO> GetPeritos();
    }
}

