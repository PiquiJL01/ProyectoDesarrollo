using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.BussinesLogic.DTOs
{
    public class PeritoDTO
    {
        public string Id_Perito { get; set; }

        public List<IncidenteDTO> Incidente { get; set; }
    }
}

