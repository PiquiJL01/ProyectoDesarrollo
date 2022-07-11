using System;
using System.Collections.Generic;

namespace RCVUcab.BussinesLogic.DTOs
{
    public class IncidenteDTO
    {
        public string ID { get; set; }
        public string Ubicacion { get; set; }

        public DateTime Fecha { get; set; }
        public string Id_Perito { get; set; }
        public string Id_Administrador { get; set; }

        public List<VehiculoIncidenteTallerDTO> VehiculoIncidenteTaller { get; set; }

        public List<CotizacionDTO> Cotizacion { get; set; }

        public PeritoDTO Perito { get; set; }
        public AdministradorDTO Administrador { get; set; }
    }
}

