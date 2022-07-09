using System;
using System.Collections.Generic;
using ProyectoDesarrollo.BussinesLogic.DTOs;

namespace ProyectoDesarrollo.Persistence.DAO.Interfaces
{
    public interface ITallerDAO
    {
        public List<TallerDTO> GetTalleres();
    }
}
}

