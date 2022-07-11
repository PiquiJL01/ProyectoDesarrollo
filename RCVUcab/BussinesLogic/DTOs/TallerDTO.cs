using System.Collections.Generic;

namespace RCVUcab.BussinesLogic.DTOs
{
    public class TallerDTO
    {
        public string Id_Taller { get; set; } = null!;
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

        public ProveedorDTO Proveedor { get; set; }

        public virtual List<CotizacionDTO> CotizacionT { get; set; }

        public virtual List<VehiculoIncidenteTallerDTO> VehiculoIncidenteTaller { get; set; }
    }
}

