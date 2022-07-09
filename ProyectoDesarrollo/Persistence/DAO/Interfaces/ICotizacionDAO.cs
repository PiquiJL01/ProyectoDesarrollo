using System;
using System.Collections.Generic;
using ProyectoDesarrollo.BussinesLogic.DTOs;

namespace ProyectoDesarrollo.Persistence.DAO.Interfaces
{
    public interface ICotizacionDAO
    {
        public List<IncidenteDTO> GetCotizacionesByIncidente(string incidente);
    }
}

