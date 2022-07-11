using System.Collections.Generic;

namespace RCVUcab.BussinesLogic.DTOs
{
    public class PeritoDTO
    {
        public string Id_Perito { get; set; }

        public List<IncidenteDTO> Incidente { get; set; }
    }
}

