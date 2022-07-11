using System.Collections.Generic;

namespace RCVUcab.BussinesLogic.DTOs
{
    public class AdministradorDTO
    {
            public string Id_Admin { get; set; }

            public List<PolizaDTO> Poliza { get; set; }
            public List<IncidenteDTO> Incidente { get; set; }
            public List<OrdenDeCompraDTO> OrdenDeCompra { get; set; }
    }
}

